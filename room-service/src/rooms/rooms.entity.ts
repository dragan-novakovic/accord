import { UsersEntity } from "src/user/users.entity";
import {
  Entity,
  Column,
  PrimaryGeneratedColumn,
  OneToMany,
  ManyToOne,
  ManyToMany,
} from "typeorm";
import { ChannelEntity } from "../channel/channel.entity";

@Entity({ name: "rooms" })
export class RoomEntity {
  @PrimaryGeneratedColumn("uuid")
  id: string;

  @Column()
  name: string;

  @OneToMany(() => ChannelEntity, (channel) => channel.room)
  channels: ChannelEntity[];
}
