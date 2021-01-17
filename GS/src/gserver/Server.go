package gserver

import (
	"fmt"
	"gserver/netMessage"
	"net"
)

func OnServer() {
	ln, err := net.Listen("tcp", ":7000")
	if err != nil {
		fmt.Println(err)
		return
	}
	defer ln.Close()

	go OnChannel()           // 채널 실행
	go netMessage.OnKernel() // 메시지를 분배할 터널 커널 실행
	go OnAccept(ln)          //접근실행
	go OnChat()
	go OnPosition()

	s := ""
	for {
		fmt.Println("Server Close = gos -off")
		fmt.Scanln(&s)
		if s == "gos -off" {
			break
		}
	}
	fmt.Println("Server Close")
}
