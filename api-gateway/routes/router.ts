import { Router } from "oak";
import { AUTH } from "./auth.ts";

export const router = new Router();

router.get("/auth/status", AUTH.getStatus);
