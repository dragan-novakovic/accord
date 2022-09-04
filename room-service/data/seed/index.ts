export { rooms } from "./room.seed";
export { channels } from "./channel.seed";
export { users } from "./user.seed";

import { query } from "../../src/dbAccess/index";
import { rooms } from "./room.seed";
import { users } from "./user.seed";

export default function seeder() {
  // insert users
  users.forEach(async (user) => {
    await query(`INSERT INTO users (id) VALUES ($1)`, [user.id]);
  });

  rooms.forEach(async (room) => {
    await query(`INSERT INTO rooms (id, name) VALUES ($1, $2)`, [
      room.id,
      room.name,
    ]);
  });
}

async function migrations() {
  // create all needed tables
  await query(
    `CREATE TABLE IF NOT EXISTS rooms (
  id varchar(45) NOT NULL,
  name varchar(45) NOT NULL,
  enabled integer NOT NULL DEFAULT '1',
  PRIMARY KEY (id)
)`,
    []
  );
  // create users_rooms
  await query(
    `CREATE TABLE IF NOT EXISTS users_rooms (
  user_id varchar(45) REFERENCES users (id),
  room_id varchar(45) REFERENCES rooms (id)
)`,
    []
  );
  // create channels
  await query(
    `CREATE TABLE IF NOT EXISTS channels (
  id varchar(45) NOT NULL,
  name varchar(45) NOT NULL,
  room_id varchar(45) REFERENCES rooms (id),
  enabled integer NOT NULL DEFAULT '1',
  PRIMARY KEY (id)
)`,
    []
  );
}

//migrations().then((x) => console.log(x));
seeder();
