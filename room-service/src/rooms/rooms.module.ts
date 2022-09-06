import { Module } from "@nestjs/common";
import { RoomsService } from "./rooms.service";
import { RoomsController } from "./rooms.controller";
import { RoomsRepository } from "./rooms.repository";

@Module({
  imports: [],
  providers: [RoomsRepository, RoomsService],
  controllers: [RoomsController],
})
export class RoomsModule {}
