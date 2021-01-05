package netMessage

import (
	"fmt"
	"net"
)

func SendMessage(userConn net.Conn, message string) {
	fmt.Println("send : ", message)
	userConn.Write([]byte(message))
}
