package gchat

import (
	"NetMessage"
	"fmt"
	"net"
)

func Accept() {
	ln, err := net.Listen("tcp", ":7000")
	fmt.Println("Start")
	if err != nil {
		fmt.Println(err)
		return
	}

	defer ln.Close()
	for {
		conn, err := ln.Accept()
		if err != nil {
			fmt.Println(err)
			continue
		}
		defer conn.Close()
		go NetMessage.ReadMessage(conn)
		go NetMessage.OnKernel()
		select {
		case re := <-NetMessage.Msg:
			msg := re[0] + ": " + re[1]
			BroadcastMsg(conn, msg)
		}
	}
	fmt.Println("서버 종료")
}

func BroadcastMsg(conn net.Conn, msg string) {
	NetMessage.SendMessage(conn, msg)
}
