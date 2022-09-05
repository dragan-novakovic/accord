import { Injectable } from "@nestjs/common";

import { RoomEntity } from "./rooms.entity";
import { query } from "../dbAccess/index";

@Injectable()
export class RoomsRepository {
  constructor() {}

  async findAll() {
    const response = await query(`SELECT * FROM rooms`, []);

    return response.rows;
  }

  async findOne(id: string) {
    const response = await query(`SELECT * FROM rooms WHERE id=$id`, [id]);

    return response.rows as unknown as RoomEntity;
  }

  async create(room: RoomEntity) {
    const response = await query(
      `INSERT INTO room(id, name)
     VALUES ($1, $2)
     RETURNING *
    `,
      [room.id, room.name]
    );

    return response.rows as unknown as RoomEntity;
  }
}
