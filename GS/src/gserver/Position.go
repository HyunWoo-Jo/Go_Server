package gserver

import (
	"gserver/netMessage"
)

func OnPosition() {
	for {
		select {
		case pos := <-netMessage.Position:
			go broadcastMsg(pos.Msg)
			break
		}
	}
}
