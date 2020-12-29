package gserver

import (
	"net"
	"sync"
)

type GSocket struct {
	id   int
	port int
	name string
	conn net.Conn
}
type GChannel struct {
	users []GSocket
	sync.Mutex
}

func UserAppend(user GSocket) {

}
