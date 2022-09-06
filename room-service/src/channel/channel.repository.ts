import { Injectable } from "@nestjs/common";

import { ChannelEntity } from "./channel.entity";
import { query } from "../dbAccess/index";

@Injectable()
export class ChannelRepository {
  constructor() {}

  async findAll() {
    const response = await query(
      `SELECT * FROM rooms, channels 
     LEFT JOIN rooms
     ON rooms.id === channels.roomid
`,
      []
    );

    return response.rows;
  }

  async findOne(id: string) {
    // add channel
    const response = await query(`SELECT * FROM rooms WHERE id=$id`, [id]);

    return response.rows as unknown as ChannelEntity;
  }

  async create(room: ChannelEntity) {
    const response = await query(
      `INSERT INTO room(id, name)
     VALUES ($1, $2)
     RETURNING *
    `,
      [room.id, room.name]
    );

    return response.rows as unknown as ChannelEntity;
  }
}
