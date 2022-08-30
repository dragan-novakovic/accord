import { ChannelEntity } from "../channel/channel.entity";

export class RoomEntity {
  id: string;
  name: string;
  channels: ChannelEntity[];
}
