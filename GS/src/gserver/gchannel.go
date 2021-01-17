package gserver

import (
	"fmt"
	"gserver/netMessage"
	"net"
	"strconv"
	"sync"
)

type GSocket struct {
	id   int
	name string
	conn net.Conn
}

type MainChannel struct {
	users     map[int]GSocket
	userCount int
	sync.Mutex
}

var (
	Mchannel   = MainChannel{}
	connFindId map[net.Conn]int
)

func Subscribe(str string, conn net.Conn) {

	strs := netMessage.Decoposit(str)
	socket := GSocket{}
	socket.id, _ = strconv.Atoi(strs[0])
	socket.name = strs[1]
	socket.conn = conn
	Mchannel.users[socket.id] = socket
	connFindId[conn] = socket.id
	fmt.Println("구독 완료")
	for userId, _ := range Mchannel.users {
		fmt.Println(userId)
		user := strconv.Itoa(userId) + ":sub:1;"
		go broadcastMsg(user)
	}

}

func Cancel(conn net.Conn) {
	val, exists := connFindId[conn]
	if exists {
		Mchannel.users[val].conn.Close()
		delete(connFindId, conn)
		delete(Mchannel.users, val)
		fmt.Println("구독 취소")
		str := strconv.Itoa(val) + ":cancel:1;"
		go broadcastMsg(str)
	}
}

func OnChannel() {
	Mchannel.users = make(map[int]GSocket)
	connFindId = make(map[net.Conn]int)
	fmt.Println("Channel On")
	for {
		select {
		case sub := <-netMessage.Sub:
			Subscribe(sub.Msg, sub.Conn)
			break
		case cancel := <-netMessage.Cancel:
			Cancel(cancel.Conn)
			break
		}
	}
}
