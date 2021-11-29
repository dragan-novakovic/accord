import { Module } from "@nestjs/common";
import { MongooseModule } from "@nestjs/mongoose";
import { TypeOrmModule } from "@nestjs/typeorm";

import { UserService } from "./user.service";
import { UserController } from "./users.controller";
import { UsersEntity } from "./users.entity";

@Module({
  imports: [TypeOrmModule.forFeature([UsersEntity])],
  providers: [UserService],
  controllers: [UserController],
  exports: [TypeOrmModule],
})
export class UserModule {}
