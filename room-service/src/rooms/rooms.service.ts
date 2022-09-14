import { Injectable } from "@nestjs/common";

import { IRoom } from "./interfaces/rooms.interface";
import { RoomEntity } from "./rooms.entity";
import { CreateRoomDto } from "./dto";
import { RoomsRepository } from "./rooms.repository";

@Injectable()
export class RoomsService {
  constructor(private roomsRepository: RoomsRepository) {}

  findAll(): Promise<IRoom[]> {
    return this.roomsRepository.findAll();
  }

  findOne(id: string): Promise<IRoom> {
    return this.roomsRepository.findOne(id);
  }

  create(room: RoomEntity): Promise<IRoom> {
    return this.roomsRepository.create(room);
  }

  // update(room: IRoom): Promise<IRoom> {
  //   return this.roomsRepository.save(room);
  // }

  async remove(id: string): Promise<void> {
    await this.roomsRepository.delete(id);
  }
}
