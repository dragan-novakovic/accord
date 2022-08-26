import { MikroOrmModule } from "@mikro-orm/nestjs";
import { Module } from "@nestjs/common";
//import { MongooseModule } from "@nestjs/mongoose";

import { UserService } from "./user.service";
import { UserController } from "./users.controller";
import { UsersEntity } from "./users.entity";

@Module({
  imports: [MikroOrmModule.forFeature([UsersEntity])],
  providers: [UserService],
  controllers: [UserController],
})
export class UserModule {}
