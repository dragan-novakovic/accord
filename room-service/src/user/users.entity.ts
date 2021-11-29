import { RoomEntity } from "src/rooms/rooms.entity";
import { Entity, OneToMany, Column, PrimaryColumn } from "typeorm";

@Entity({ name: "users" })
export class UsersEntity {
  @PrimaryColumn()
  id: string;

  @OneToMany((type) => RoomEntity, (room) => room.id, {
    eager: true,
  })
  rooms: RoomEntity[];
}
