package gserver

import (
	"container/list"
	"fmt"
	"gserver/netMessage"
)

var (
	li = list.New()
)

func OnChat() {
	for {
		select {
		case msg := <-netMessage.Msg:
			broadcastMsg(msg.Msg)
		}
	}
	fmt.Println("서버 종료")
}

func broadcastMsg(msg string) {
	Mchannel.Lock()
	for _, soc := range Mchannel.users {
		netMessage.SendMessage(soc.conn, msg)
	}
	Mchannel.Unlock()
}
