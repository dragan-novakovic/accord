import { MigrationInterface, QueryRunner, getRepository } from "typeorm";
import { users, channels, rooms } from "../data/seed";

export class initSeed1638617445358 implements MigrationInterface {
  public async up(queryRunner: QueryRunner): Promise<void> {
    const eUsers = getRepository("users").create(users);
    await getRepository("users").save(eUsers);

    const eRooms = getRepository("rooms").create(rooms);
    await getRepository("rooms").save(eRooms);

    const eChannels = getRepository("channels").create(channels);
    await getRepository("channels").save(eChannels);
  }

  public async down(queryRunner: QueryRunner): Promise<void> {}
}
