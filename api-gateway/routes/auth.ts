import { Status } from "https://deno.land/std@0.200.0/http/http_status.ts";
import { RouterContext } from "oak";

export const AUTH__BASE_URL = "http://auth:3000";

export const AUTH = {
  async getStatus(context: RouterContext<"/auth/status">) {
    const response = await fetch("http://auth:3000/status");
    const data = await response.json();
    console.log(data);
    context.response.body = data;
  },

  async register(context: RouterContext<"/auth/register">) {
    console.log("Gateway register");

    if (!context.request.hasBody) {
      context.throw(Status.BadRequest, "BAAAD");
    }

    const body = context.request.body();
    const realBody = await body.value;

    const registerResponse = await fetch("http://auth:3000/register", {
      method: "POST",
      body: JSON.stringify(realBody),
    });
    const UserData = await registerResponse.json();

    const response = {
      ...UserData,
      status: registerResponse.status,
      statusText: registerResponse.statusText,
    };

    console.log({ response });

    context.response.type = "aplication/json";
    context.response.body = JSON.stringify(response);
  },

  async login(context: RouterContext<"/auth/login">) {
    console.log("Gateway login");

    if (!context.request.hasBody) {
      context.throw(Status.BadRequest, "BAAAD");
    }

    const body = context.request.body();

    const loginData = await fetch("http://auth:3000/login", {
      method: "POST",
      body: JSON.stringify(body.value),
    });

    const userData = await loginData.json();
    console.log(userData);
    context.response.body = loginData;
  },
};
