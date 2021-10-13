import { serve } from "https://deno.land/std/http/server.ts";
import { WebSocket } from "https://deno.land/std/ws/mod.ts";
import {
  WebSocketServer,
  WebSocketClient,
} from "https://deno.land/x/websocket@v0.1.3/mod.ts";

import { v4 } from "https://deno.land/std/uuid/mod.ts";
import requestParser from "./utils/requestParser.ts";

const currentUsers = new Map<string, WebSocket>();

const wss = new WebSocketServer(8080);
wss.on("connection", function (ws: WebSocketClient) {
  ws.on("message", function (message: string) {
    console.log(message);
    ws.send(message);
  });
});

if (import.meta.main) {
  const port = Deno.args[0] || "8080";
  console.info(`WS server is running on :${port}`);
}
