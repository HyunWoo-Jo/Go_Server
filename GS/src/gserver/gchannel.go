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

var MainChannel = struct {
	users     map[int]GSocket
	userCount int
	sync.Mutex
}{users: make(map[int]GSocket)}

var (
	connect   = make(chan (chan<- GSocket))
	unconnect = make(chan (<-chan GSocket))
)

func Connect(user chan GSocket) GSocket {
	connect <- user
	return <-user
}

func Unconnect(user chan GSocket) {
	unconnect <- user
}

func OnChannel() {
	for {
		select {
		case con := <-connect:
			MainChannel.Lock()
			for id, user := range MainChannel.users {
				user.conn.Write()
			}
			MainChannel.Unlock()
			break
		case uncon := <-unconnect:

			break
		}
	}
}
