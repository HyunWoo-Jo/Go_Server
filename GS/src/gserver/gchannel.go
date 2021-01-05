package gserver

import (
	"fmt"
	"gserver/netMessage"
	"net"
	"strconv"
)

type GSocket struct {
	id   int
	name string
	conn net.Conn
}

type MainChannel struct {
	users     map[int]GSocket
	userCount int
}

var (
	Mchannel = MainChannel{}
)

func Subscribe(str string, conn net.Conn) {

	strs := netMessage.Decoposit(str)
	socket := GSocket{}
	socket.id, _ = strconv.Atoi(strs[0])
	socket.name = strs[1]
	socket.conn = conn
	Mchannel.users[socket.id] = socket
	fmt.Println("구독 완료")
}

func OnChannel() {
	Mchannel.users = make(map[int]GSocket)
	fmt.Println("Channel On")
	for {
		select {
		case sub := <-netMessage.Sub:
			Subscribe(sub.Msg, sub.Conn)
			break
		}
	}
}
