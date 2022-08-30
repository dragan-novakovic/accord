import { Injectable } from "@nestjs/common";

import { UsersEntity } from "./users.entity";
import { query } from "../dbAccess/index";
import { IUser } from "./interfaces/users.interface";

@Injectable()
export class UserRepository {
  constructor() {}

  async findAll() {
    const response = await query(`SELECT * FROM users`, []);

    return response.rows;
  }

  async findOne(id: string) {
    const response = await query(`SELECT * FROM users WHERE id=$id`, [id]);

    return response.rows as unknown as IUser;
  }

  async create(user: UsersEntity) {
    const response = await query(
      `INSERT INTO users(id)
     VALUES ($1)
     RETURNING *
    `,
      [user.id]
    );

    return response.rows as unknown as IUser;
  }
}
