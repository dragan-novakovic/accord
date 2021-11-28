import { RoomEntity } from "src/rooms/rooms.entity";
import { Entity, PrimaryGeneratedColumn, OneToMany, Column } from "typeorm";

@Entity({ name: "users" })
export class UsersEntity {
  @PrimaryGeneratedColumn("uuid")
  id: string;

  @Column()
  name: string;

  @OneToMany((type) => RoomEntity, (room) => room.id, {
    eager: true,
  })
  rooms: RoomEntity[];
}
