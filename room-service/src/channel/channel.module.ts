import { Module } from "@nestjs/common";

import { ChannelService } from "./channel.service";
import { ChannelController } from "./channel.controller";
import { ChannelEntity } from "./channel.entity";
import { RoomEntity } from "../rooms/rooms.entity";
import { ChannelRepository } from "./channel.repository";

@Module({
  imports: [],
  providers: [ChannelRepository, ChannelService],
  controllers: [ChannelController],
  exports: [],
})
export class ChannelModule {}
