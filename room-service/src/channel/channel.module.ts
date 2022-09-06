import { Module } from "@nestjs/common";

import { ChannelService } from "./channel.service";
import { ChannelController } from "./channel.controller";
import { ChannelRepository } from "./channel.repository";
//import { RoomsRepository } from "src/rooms/rooms.repository";

@Module({
  imports: [],
  providers: [ChannelRepository, ChannelService],
  controllers: [ChannelController],
})
export class ChannelModule {}
