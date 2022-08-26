import { RoomEntity } from "src/rooms/rooms.entity";
import {
  Entity,
  Property,
  PrimaryKey,
  ManyToMany,
  JoinTable,
} from "@mikro-orm/core";

@Entity({ name: "users" })
export class UsersEntity {
  @PrimaryKey()
  id: string;

  @ManyToMany(() => RoomEntity, { eager: true })
  @JoinTable()
  rooms: RoomEntity[];
}
