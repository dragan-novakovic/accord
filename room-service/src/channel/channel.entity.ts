import { Entity, Column, PrimaryGeneratedColumn, ManyToOne } from "typeorm";
import { RoomEntity } from "../rooms/rooms.entity";

@Entity({ name: "channels" })
export class ChannelEntity {
  @PrimaryGeneratedColumn("uuid")
  id: string;

  @Column()
  name: string;

  @ManyToOne(() => RoomEntity, (room) => room.channels)
  room: RoomEntity;
}
