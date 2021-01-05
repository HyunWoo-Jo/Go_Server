package gserver

import (
	"fmt"
	"gserver/netMessage"
	"net"
)

// 접속에 성공하면 Subsription 에 net.conn 을 전송
func OnAccept(ln net.Listener) {
	fmt.Println("Aceept On")
	for {
		conn, err := ln.Accept()
		if err != nil {
			fmt.Println(err)
			continue
		}
		go netMessage.ReadMessage(conn)
	}
}
