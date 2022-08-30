import { RoomEntity } from "src/rooms/rooms.entity";
import { Entity, PrimaryKey, ManyToMany, Collection } from "@mikro-orm/core";

@Entity({ tableName: "users" })
export class UsersEntity {
  @PrimaryKey()
  id: string;

  @ManyToMany(() => RoomEntity)
  rooms = new Collection<RoomEntity>(this);
}
