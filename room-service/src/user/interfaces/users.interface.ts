import { RoomEntity } from "src/rooms/rooms.entity";

export interface IUser {
  id: string;
  rooms: RoomEntity[];
}
