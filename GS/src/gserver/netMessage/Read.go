package netMessage

import (
	"fmt"
	"net"
)

var (
	read = make(chan MsgEvent)
)

func ReadMessage(userConn net.Conn) {
	for {
		data := make([]byte, 4096)
		message, err := userConn.Read(data)
		if err != nil {
			fmt.Println("Read Err", err)
			cancel := MsgEvent{"err:cancel", userConn}
			read <- cancel
			return
		}
		fmt.Printf("Read : %s Size: %d\n", string(data[:message]), len(string(data[:message])))
		read <- MsgEvent{string(data[:message]), userConn}
	}
}
