import {
  Entity,
  Property,
  OneToMany,
  PrimaryKey,
  Collection,
} from "@mikro-orm/core";
import { ChannelEntity } from "../channel/channel.entity";

@Entity({ tableName: "rooms" })
export class RoomEntity {
  @PrimaryKey()
  id!: string;

  @Property()
  name: string;

  @OneToMany(() => ChannelEntity, (channel) => channel.room)
  channels = new Collection<ChannelEntity>(this);
}
