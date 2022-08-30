import { RoomEntity } from "../rooms/rooms.entity";

export class ChannelEntity {
  id: string;
  name: string;
  room: RoomEntity;
}
