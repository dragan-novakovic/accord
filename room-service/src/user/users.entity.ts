import { Entity, Column, PrimaryGeneratedColumn, OneToMany } from "typeorm";
import { ChannelEntity } from "../channel/channel.entity";

@Entity({ name: "users" })
export class UsersEntity {
  @PrimaryGeneratedColumn("uuid")
  id: string;

  @Column()
  name: string;

  @OneToMany((type) => ChannelEntity, (channel) => channel.room, {
    eager: true,
  })
  channels: ChannelEntity[];
}
