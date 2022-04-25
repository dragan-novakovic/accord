//CHAT-SERVICE

db_chat = db.getSiblingDB("CHAT-SERVICE");

db_chat.createUser({
  user: "admin",
  pwd: "admin",
  roles: [
    {
      role: "readWrite",
      db: "CHAT-SERVICE",
    },
  ],
});

db_chat.messages.drop();

db_chat.messages.insertMany([
  {
    username: "admin",
    roomId: "xxx",
    message: "First Message",
  },
  { username: "admin2", roomId: "xxx", message: "Second Message" },
]);

//AUTH-SERVICE

db_auth = db.getSiblingDB("AUTH-SERVICE");

db_auth.createUser({
  user: "admin",
  pwd: "admin",
  roles: [
    {
      role: "readWrite",
      db: "AUTH-SERVICE",
    },
  ],
});

db_auth.users.drop();

db_auth.users.insertMany([
  {
    username: "admin1",
    password: "admin1",
  },
  {
    username: "admin2",
    password: "admin2",
  },
  ,
]);
