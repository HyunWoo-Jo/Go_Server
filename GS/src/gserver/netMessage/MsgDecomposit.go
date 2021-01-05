package netMessage

import (
	"strings"
)

func Decoposit(input string) []string {
	return strings.FieldsFunc(input, func(r rune) bool {
		return strings.ContainsRune(":", r)
	})
}
