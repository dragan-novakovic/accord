package main

import "github.com/gofiber/fiber/v2"

func main() {
	app := fiber.New()

	// Create a new endpoint
	app.Get("/", func(c *fiber.Ctx) error {
		return c.SendString("Hello World!")
	})

	//login

	//room
	app.Get("/rooms", func(ctx *fiber.Ctx) error {

		return ctx.SendString("HI")
	})

	// Start server on port 3000
	app.Listen(":3000")
}
