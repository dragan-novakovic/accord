import { RouterContext } from "oak";

export const AUTH__BASE_URL = "http://auth:3000";

export const AUTH = {
  async getStatus(context: RouterContext<"/auth/status">) {
    const response = await fetch("http://auth:3000/status");
    const data = await response.json();
    console.log(data);
    context.response.body = response.statusText;
  },
};
