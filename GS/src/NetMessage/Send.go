package NetMessage

import (
	"encoding/ascii85"
	"fmt"
	"net"
)

func SendMessage(userConn net.Conn, message string) {
	data := make([]byte, 4096)
	fmt.Println("send : ", message)
	ascii85.Encode(data, []byte(message))
	userConn.Write([]byte(message))
}
