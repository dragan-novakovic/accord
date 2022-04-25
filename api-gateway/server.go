package main

import "github.com/gofiber/fiber/v2"

func main() {
	app := fiber.New()

	// Create a new endpoint
	app.Static("/", "./public")

	//users

	type User struct {
		username string
		password string
	}

	app.Post("/api/login", func(ctx *fiber.Ctx) error {

		var reqBody = ctx.BodyParser(&User)
		return ctx.SendString("QO")
	})

	// middleware auth
	app.Use("/api/rooms", func(ctx *fiber.Ctx) error {
		ctx.Set("X-Custom-Header", "X")
		return ctx.Next()
	})

	//room
	app.Get("/api/rooms", func(ctx *fiber.Ctx) error {

		return ctx.SendString("HI")
	})

	// Start server on port 3000
	app.Listen(":3000")
}
