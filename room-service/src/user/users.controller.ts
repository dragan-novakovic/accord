import { Controller, Get, Param } from "@nestjs/common";
import { IUser } from "./interfaces/users.interface";
import { UserService } from "./user.service";

@Controller("users")
export class UserController {
  constructor(private userService: UserService) {}

  @Get(":id")
  getMessages(@Param("id") id: string): Promise<IUser> {
    return null;
  }
}
