import { Injectable } from "@nestjs/common";

import { IChannel } from "./interfaces/channel.interface";
import { ChannelEntity } from "./channel.entity";
import { RoomEntity } from "../rooms/rooms.entity";
import { CreateChannelDto } from "./dto";
import { ChannelRepository } from "./channel.repository";

@Injectable()
export class ChannelService {
  constructor(private channelRepository: ChannelRepository) {}
  findAll(): Promise<IChannel[]> {
    return this.channelRepository.findAll();
  }
  findOne(id: string): Promise<IChannel> {
    return this.channelRepository.findOne(id);
  }
  async create(channel: ChannelEntity): Promise<ChannelEntity> {
    return this.channelRepository.create(channel);
  }
  // update(room: IChannel): Promise<IChannel> {
  //   return this.channelRepository.save(room);
  // }
  // async remove(id: string): Promise<void> {
  //   await this.channelRepository.delete(id);
  // }
}
