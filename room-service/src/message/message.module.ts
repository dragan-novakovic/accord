import { Module } from "@nestjs/common";

import { MessageService } from "./message.service";
import { MessageController } from "./message.controller";
import { Message } from "./message.schema";

@Module({
  imports: [],
  providers: [MessageService],
  controllers: [MessageController],
})
export class MessageModule {}
