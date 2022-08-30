import {
  Entity,
  Property,
  ManyToOne,
  PrimaryKey,
  Collection,
} from "@mikro-orm/core";
import { RoomEntity } from "../rooms/rooms.entity";

@Entity({ tableName: "channels" })
export class ChannelEntity {
  @PrimaryKey()
  id: string;

  @Property()
  name: string;

  @ManyToOne(() => RoomEntity)
  room: RoomEntity;
}
