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
			broadcastMsg(msg)
		}
	}
	fmt.Println("서버 종료")
}

func broadcastMsg(msg string) {

	for _, soc := range Mchannel.users {
		netMessage.SendMessage(soc.conn, msg)
	}
}
