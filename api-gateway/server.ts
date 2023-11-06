import { Application, isHttpError, Status } from "oak";
import { router } from "./routes/router.ts";
import { setupLogger } from "./common/Logger.ts";
import { setupTiming } from "./common/Timing.ts";

const app = new Application();

// Middleware
app.addEventListener("error", (evt) => {
  // Will log the thrown error to the console.
  console.log(evt.error);
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
