import { Injectable } from "@nestjs/common";
import { InjectRepository } from "@nestjs/typeorm";
import { Repository } from "typeorm";
import { UsersEntity } from "./users.entity";
import type { IUser } from "./interfaces/users.interface";
import type { CreateUserDto } from "./dto";

@Injectable()
export class UserService {
  constructor(
    @InjectRepository(UsersEntity)
    private userRepository: Repository<UsersEntity>
  ) {}

  findAll(): Promise<IUser[]> {
    return this.userRepository.find();
  }

  findOne(id: string): Promise<IUser> {
    return this.userRepository.findOne(id);
  }

  create(user: CreateUserDto): Promise<IUser> {
    const newUser = this.userRepository.create(user);
    return this.userRepository.save(newUser);
  }
}
