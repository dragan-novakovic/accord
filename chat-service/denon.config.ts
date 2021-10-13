import type { DenonConfig } from "https://deno.land/x/denon/mod.ts";

const config: DenonConfig = {
  scripts: {
    start: {
      cmd: "./src/ws-server.ts",
      desc: "WS server",
      allow: ["env", "write", "read", "net"],
      unstable: true,
    },
  },
};

export default config;
