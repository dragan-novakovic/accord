import { Controller, Get, Param } from "@nestjs/common";
import { UserService } from "./user.service";
import { User } from "./user.schema";

@Controller("message")
export class UserController {
  constructor(private userService: UserService) {}

  @Get(":id")
  getMessages(@Param("id") id: string): Promise<User> {
    return null;
  }
}
