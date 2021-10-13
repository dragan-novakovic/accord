import { MongoClient } from "https://deno.land/x/mongo@v0.26.0/mod.ts";
import { WebSocket } from "https://deno.land/std/ws/mod.ts";

const client = new MongoClient();

client.connectWithOptions({
  username: "admin",
  password: "admin",
  hosts: ["localhost:27017"],
  directConnection: true,
});

type Message = {
  roomId: string;
  message: string;
  username: string;
};

const db = client.database("CHAT_SERVICE");
const messages = db.collection<MessageSchema>("messages");

interface TestUserPayload {
  id: string;
  username: string;
  roomId: string;
  message: string;
}

const handleMessageWS = async (
  wsEvent: string,
  users: Map<string, WebSocket>
) => {
  const { username, roomId, message }: TestUserPayload = JSON.parse(wsEvent);

  const insertId = await messages.insertOne({
    username,
    roomId,
    message,
  });

  if (insertId) {
    users.forEach((sock) => {
      sock.send(`${username}: ${message}`);
    });
  }
};

export { handleMessageWS };
