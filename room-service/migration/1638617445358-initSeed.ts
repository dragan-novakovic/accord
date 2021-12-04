import { MigrationInterface, QueryRunner, getRepository } from "typeorm";
import { users, channels, rooms } from "../data/seed";

export class initSeed1638617445358 implements MigrationInterface {
  public async up(queryRunner: QueryRunner): Promise<void> {
    //  await getRepository("users").save(users);
    // const roomsEntity = await getRepository("rooms").create(rooms);
    // const channelsMapped = channels.map((channel) => ({
    //   ...channel,
    //   roomId: roomsEntity[0].id,
    // }));
  }

  public async down(queryRunner: QueryRunner): Promise<void> {}
}
