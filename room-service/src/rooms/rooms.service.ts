import { Injectable } from "@nestjs/common";

import { IRoom } from "./interfaces/rooms.interface";
import { RoomEntity } from "./rooms.entity";
import { CreateRoomDto } from "./dto";

@Injectable()
export class RoomsService {
  constructor(private roomsRepository: any) {}

  // findAll(): Promise<IRoom[]> {
  //   return this.roomsRepository.find();
  // }

  // findOne(id: string): Promise<IRoom> {
  //   return this.roomsRepository.findOne(id);
  // }

  // create(room: CreateRoomDto): Promise<IRoom> {
  //   const newRoom = this.roomsRepository.create({ ...room, channels: [] });
  //   return this.roomsRepository.save(newRoom);
  // }

  // update(room: IRoom): Promise<IRoom> {
  //   return this.roomsRepository.save(room);
  // }

  // async remove(id: string): Promise<void> {
  //   await this.roomsRepository.delete(id);
  // }
}
