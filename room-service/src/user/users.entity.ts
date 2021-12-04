import { RoomEntity } from "src/rooms/rooms.entity";
import { Entity, Column, PrimaryColumn, ManyToMany, JoinTable } from "typeorm";

@Entity({ name: "users" })
export class UsersEntity {
  @PrimaryColumn()
  id: string;

  @ManyToMany(() => RoomEntity)
  @JoinTable()
  rooms: RoomEntity[];
}
