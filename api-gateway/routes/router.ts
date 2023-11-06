import { Router } from "oak";
import { AUTH } from "./auth.ts";

export const router = new Router();

router
  .get("/auth/status", AUTH.getStatus)
  .post("/auth/register", AUTH.register)
  .post("/auth/login", AUTH.login);
