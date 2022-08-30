import { Body, Controller, Get, Param, Post } from "@nestjs/common";
import { CreateUserDto } from "./dto";
import { IUser } from "./interfaces/users.interface";
import { UserService } from "./user.service";

@Controller("users")
export class UserController {
  constructor(private userService: UserService) {}

  @Get()
  getUsers(): Promise<IUser[]> {
    return this.userService.findAll();
  }

  @Get(":id")
  getUser(@Param("id") id: string): Promise<IUser> {
    return this.userService.findOne(id);
  }

  @Post()
  create(@Body() createUserDto: CreateUserDto): Promise<IUser> {
    return this.userService.create(createUserDto);
  }
}
