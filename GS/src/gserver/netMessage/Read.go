package netMessage

import (
	"fmt"
	"net"
)

var (
	read = make(chan string)
)

func ReadMessage(userConn net.Conn) {
	for {
		data := make([]byte, 4096)
		message, err := userConn.Read(data)
		if err != nil {
			println(err)
			return
		}
		fmt.Println("Read : ", string(data[:message]))
		read <- string(data[:message])
		Con <- userConn
	}
}
