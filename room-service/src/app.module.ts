import { Module } from "@nestjs/common";
import { MongooseModule } from '@nestjs/mongoose';
// Entites

// Modules
import { RoomsModule } from "./rooms/rooms.module";
import { ChannelModule } from "./channel/channel.module";
import { MessageModule } from "./message/message.module";
import { UserModule } from "./user/users.module";

// Service
import { UserRepository } from "./user/users.repository";

@Module({
  imports: [UserModule, RoomsModule, ChannelModule, MongooseModule.forRoot('mongodb://localhost/CHAT-SERVICE'), MessageModule], 
  providers: [UserRepository],
})
export class AppModule {}

//TODO
//3. Connect to sockets
