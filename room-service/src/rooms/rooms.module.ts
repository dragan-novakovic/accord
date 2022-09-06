import { Module } from "@nestjs/common";
import { RoomsService } from "./rooms.service";
import { RoomsController } from "./rooms.controller";
import { RoomEntity } from "./rooms.entity";
import { RoomsRepository } from "./rooms.repository";

@Module({
  imports: [],
  providers: [RoomsRepository, RoomsService],
  controllers: [RoomsController],
  exports: [],
})
export class RoomsModule {}
