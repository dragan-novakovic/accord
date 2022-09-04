export { rooms } from "./room.seed";
export { channels } from "./channel.seed";
export { users } from "./user.seed";

import { query } from "../../src/dbAccess/index";

export default function seeder() {}

function migrations() {
  query(``, []);
}
