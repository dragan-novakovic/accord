import {
  Controller,
  Post,
  Body,
  Get,
  Param,
  Delete,
  Put,
} from "@nestjs/common";
import { ChannelService } from "./channel.service";

import { CreateChannelDto } from "./dto";
import { IChannel } from "./interfaces/channel.interface";

@Controller("channel")
export class ChannelController {
  constructor(private channelService: ChannelService) {}

  // @Get()
  // findAll(): Promise<IChannel[]> {
  //   return this.channelService.findAll();
  // }

  // @Get(":id")
  // findOne(@Param("id") id: string): Promise<IChannel> {
  //   return this.channelService.findOne(id);
  // }

  // @Post()
  // create(@Body() createRoomDto: CreateChannelDto): Promise<IChannel> {
  //   return this.channelService.create(createRoomDto);
  // }

  // @Put(":id")
  // update(
  //   @Param("id") id: string,
  //   @Body() updateRoomDto: IChannel
  // ): Promise<IChannel> {
  //   return this.channelService.update(updateRoomDto);
  // }

  // @Delete(":id")
  // remove(@Param("id") id: string): Promise<void> {
  //   return this.channelService.remove(id);
  // }
}
