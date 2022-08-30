import { Injectable } from "@nestjs/common";

import { UserRepository } from "./users.repository";
import { UsersEntity } from "./users.entity";
import type { IUser } from "./interfaces/users.interface";
import type { CreateUserDto } from "./dto";

@Injectable()
export class UserService {
  constructor(private userRepository: UserRepository) {}

  async findAll(): Promise<any[]> {
    return this.userRepository.findAll();
  }

  async findOne(id: string): Promise<IUser> {
    return this.userRepository.findOne(id);
  }

  create(user: CreateUserDto): Promise<IUser> {
    return this.userRepository.create({ ...user, rooms: [] });
  }
}
