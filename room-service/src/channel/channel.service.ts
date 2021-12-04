import { Injectable } from "@nestjs/common";
import { InjectRepository } from "@nestjs/typeorm";
import { Repository } from "typeorm";

import { IChannel } from "./interfaces/channel.interface";
import { ChannelEntity } from "./channel.entity";
import { RoomEntity } from "../rooms/rooms.entity";
import { CreateChannelDto } from "./dto";

@Injectable()
export class ChannelService {
  constructor(
    @InjectRepository(ChannelEntity)
    private channelRepository: Repository<ChannelEntity>,
    @InjectRepository(RoomEntity)
    private roomRepository: Repository<RoomEntity>
  ) {}

  findAll(): Promise<IChannel[]> {
    return this.channelRepository.find();
  }

  findOne(id: string): Promise<IChannel> {
    return this.channelRepository.findOne(id);
  }

  async create(channel: CreateChannelDto): Promise<ChannelEntity> {
    const { roomId, ...channelDto } = channel;

    // room: string -> room: Room
    const roomEntity = await this.roomRepository.findOne(roomId);

    const newChannel = this.channelRepository.create({
      ...channelDto,
      room: roomEntity,
    });
    return this.channelRepository.save(newChannel);
  }

  update(room: IChannel): Promise<IChannel> {
    return this.channelRepository.save(room);
  }

  async remove(id: string): Promise<void> {
    await this.channelRepository.delete(id);
  }
}
