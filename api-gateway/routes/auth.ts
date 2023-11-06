import { RouterContext } from "oak";

export const AUTH__BASE_URL = "http://auth:3000";

export const AUTH = {
  async getStatus(context: RouterContext<"/auth/status">) {
    const response = await fetch("http://auth:3000/status");
    console.log(response.json());
    context.response.body = response.statusText;
  },
};
