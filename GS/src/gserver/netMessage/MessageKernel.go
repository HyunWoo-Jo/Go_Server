package netMessage

import (
	"fmt"
	"net"
)

var (
	Msg = make(chan string)
	Sub = make(chan SubEvent)
	Con = make(chan net.Conn)
)

type SubEvent struct {
	Msg  string
	Conn net.Conn
}

func OnKernel() {
	fmt.Println("Kernel On")
	for {
		select {
		case str := <-read:
			conn := <-Con
			s := Decoposit(str)
			switch s[1] {
			case "msg":
				Msg <- str
				break
			case "sub":
				sub := SubEvent{str, conn}
				Sub <- sub
				break
			}

			break
		}
	}
}
