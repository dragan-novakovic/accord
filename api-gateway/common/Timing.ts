import { Context } from "oak";

export const setupTiming = (ctx: Context, start: number) => {
  const ms = Date.now() - start;
  ctx.response.headers.set("X-Response-Time", `${ms}ms`);
};
