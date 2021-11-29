import { IRoom } from "src/rooms/interfaces/rooms.interface";

export interface CreateUserDto {
  id: string;
  rooms: IRoom[];
}
