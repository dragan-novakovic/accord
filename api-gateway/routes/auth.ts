import { RouterContext } from "oak";

export const AUTH__BASE_URL = "http://admin:3000";

export const AUTH = {
  async getStatus(context: RouterContext<"/auth/status">) {
    const response = await fetch("http://admin:3000/status");

    context.response.body = response;
  },
};
