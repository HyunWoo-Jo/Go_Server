package netMessage

import (
	"fmt"
	"net"
)

func SendMessage(userConn net.Conn, message string) {

	fmt.Println("send :", message)
	_, err := userConn.Write([]byte(message))
	if err != nil {
		fmt.Println("send err ", err)
	}
	fmt.Println(len([]byte(message)))
}
