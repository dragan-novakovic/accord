import { Module } from "@nestjs/common";
//import { MongooseModule } from "@nestjs/mongoose";
import { MikroOrmModule } from "@mikro-orm/nestjs";

// Entites

// Modules
import { RoomsModule } from "./rooms/rooms.module";
import { ChannelModule } from "./channel/channel.module";
import { MessageModule } from "./message/message.module";
import { UserModule } from "./user/users.module";

// Service
import { UserService } from "./user/user.service";

@Module({
  imports: [
    MikroOrmModule.forRoot({
      type: "postgresql",
      host: "localhost",
      port: 5555,
      user: "docker",
      password: "docker",
      dbName: "ROOM-SERVICE",
      entities: ["dist/**/*.entity{.ts,.js}"],
    }),
    UserModule,
    RoomsModule,
    ChannelModule,
    // MongooseModule.forRoot(
    //   "mongodb://admin:admin@localhost:27017/CHAT-SERVICE"
    // ),
  ],
  providers: [UserService],
})
export class AppModule {}

//TODO
//3. Connect to sockets
