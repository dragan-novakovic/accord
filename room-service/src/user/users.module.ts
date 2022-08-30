import { Module } from "@nestjs/common";

import { UserService } from "./user.service";
import { UserController } from "./users.controller";
import { UserRepository } from "./users.repository";

@Module({
  imports: [],
  providers: [UserRepository, UserService],
  controllers: [UserController],
})
export class UserModule {}
