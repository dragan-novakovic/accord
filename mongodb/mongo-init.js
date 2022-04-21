db = db.getSiblingDB("CHAT-SERVICE");

db.createUser({
  user: "admin",
  pwd: "admin",
  roles: [
    {
      role: "readWrite",
      db: "CHAT-SERVICE",
    },
  ],
});

db.messages.drop();

db.messages.insertMany([
  {
    username: "admin",
    roomId: "xxx",
    message: "First Message",
  },
  { username: "admin2", roomId: "xxx", message: "Second Message" },
]);
