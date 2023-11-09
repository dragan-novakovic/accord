import { Application, isHttpError, Status } from "oak";
import { router } from "./routes/router.ts";
import { setupLogger } from "./common/Logger.ts";
import { setupTiming } from "./common/Timing.ts";

// Connect to the proxy server
// const conn = await Deno.connect({
//   hostname: "chat:5207/chat",
//   port: 8080,
// });

// // Create a buffered reader and writer
// const reader = conn.readable.getReader();
// const writer = conn.writable.getWriter();

// // Send the HTTP request to the proxy server, requesting to connect to the WebSocket server // Sending?
// const request = `CONNECT example.com:80 HTTP/1.1\r\nHost: example.com\r\n\r\n`;
// await writer.write(new TextEncoder().encode(request));

// // Read the HTTP response from the proxy server
// const response = await reader.readLine();
// console.log(new TextDecoder().decode(response.line));

// // Upgrade the connection to a WebSocket connection
// const ws = Deno.upgradeWebSocket(conn);

// // Send and receive WebSocket messages
// await ws.send("Hello");
// const msg = await ws.receive();
// console.log(msg);

const app = new Application();

// Middleware
app.addEventListener("error", (evt) => {
  // Will log the thrown error to the console.
  console.log(evt.error);
});

app.use(async (ctx, next) => {
  ctx.response.headers.set("Access-Control-Allow-Origin", "*");
  ctx.response.headers.set(
    "Access-Control-Allow-Methods",
    "GET, POST, PUT, DELETE"
  );
  ctx.response.headers.set("Access-Control-Allow-Headers", "Content-Type");
  ctx.response.headers.set("Access-Control-Allow-Credentials", "true");
  await next();
});

// Logger
app.use(async (ctx, next) => {
  setupLogger(ctx);
  await next();
});

// Timing
app.use(async (ctx, next) => {
  const start = Date.now();
  await next();
  setupTiming(ctx, start);
});

// Routes
app.use(router.routes());
app.use(router.allowedMethods());
app.listen({ port: 1993 });

app.addEventListener("listen", ({ hostname, port, secure }) => {
  console.log(
    `Listening on: ${secure ? "https://" : "http://"}${
      hostname ?? "localhost"
    }:${port}`
  );
});
