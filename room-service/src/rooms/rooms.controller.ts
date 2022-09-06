import {
  Controller,
  Post,
  Body,
  Query,
  Get,
  Param,
  Delete,
  Put,
} from "@nestjs/common";
import { RoomsService } from "./rooms.service";
import { RoomEntity } from "./rooms.entity";
import { IRoom } from "./interfaces/rooms.interface";

class CreateRoomDto {
  name: string;
}

@Controller("rooms")
export class RoomsController {
  constructor(private roomsService: RoomsService) {}

  @Get()
  findAll(): Promise<IRoom[]> {
    return this.roomsService.findAll();
  }

  @Get(":id")
  findOne(@Param("id") id: string): Promise<IRoom> {
    return this.roomsService.findOne(id);
  }

  @Post()
  create(@Body() createRoomDto: RoomEntity): Promise<IRoom> {
    return this.roomsService.create(createRoomDto);
  }

  // @Put(":id")
  // update(
  //   @Param("id") id: string,
  //   @Body() updateRoomDto: IRoom
  // ): Promise<IRoom> {
  //   return this.roomsService.update(updateRoomDto);
  // }

  // @Delete(":id")
  // remove(@Param("id") id: string): Promise<void> {
  //   return this.roomsService.remove(id);
  // }
}
