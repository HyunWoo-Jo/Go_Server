package NetMessage

var (
	Msg = make(chan string)
)

func OnKernel() {
	for {
		select {
		case str := <-read:
			s := Decoposit(str)
			switch s[1] {
			case "msg":
				Msg <- str
				break
			}
			break
		}
	}
}
