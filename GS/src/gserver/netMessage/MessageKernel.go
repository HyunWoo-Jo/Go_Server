package netMessage

import (
	"fmt"
	"net"
)

var (
	Msg      = make(chan MsgEvent)
	Sub      = make(chan MsgEvent)
	Cancel   = make(chan MsgEvent)
	Position = make(chan MsgEvent)
)

type MsgEvent struct {
	Msg  string
	Conn net.Conn
}

func OnKernel() {
	fmt.Println("Kernel On")
	for {
		select {
		case msg := <-read:
			s := Decoposit(msg.Msg)
			switch s[1] {
			case "msg":
				Msg <- msg
				break
			case "position":
				Position <- msg
				break
			case "sub":
				Sub <- msg
				break
			case "cancel":
				fmt.Println("Cancel")
				Cancel <- msg
				break

			}
			break
		}
	}
}
