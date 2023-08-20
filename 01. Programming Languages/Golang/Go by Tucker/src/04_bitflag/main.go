package main

import "fmt"

type Room uint8

const (
	MasterRoom Room = 1 << iota
	BathRoom
	Kitchen
	LivingRoom
)

func SetLight(rooms, room Room) Room {
	return rooms | room
}

func ResetLight(rooms, room Room) Room {
	return rooms &^ room
}

func IsTurnOn(rooms, room Room) bool {
	return rooms&room == room
}

func TurnOnLight(rooms Room) {
	if IsTurnOn(rooms, MasterRoom) {
		fmt.Println("Turn On MasterRoom Light")
	}
	if IsTurnOn(rooms, BathRoom) {
		fmt.Println("Turn On BathRoom Light")
	}
	if IsTurnOn(rooms, Kitchen) {
		fmt.Println("Turn On Kitchen Light")
	}
	if IsTurnOn(rooms, LivingRoom) {
		fmt.Println("Turn On LivingRoom Light")
	}
}

func main() {
	var rooms Room = 0
	rooms = SetLight(rooms, MasterRoom)
	rooms = SetLight(rooms, LivingRoom)
	TurnOnLight(rooms)
}
