import { Injectable } from "@nestjs/common";
import { Message } from "./message.schema";

@Injectable()
export class MessageService {
  // constructor(
  //   @InjectModel(Message.name) private messageModel: Model<Message>
  // ) {}
  // async getMessagesForChannel(id: string): Promise<Message[]> {
  //   return [];
  // }
  // async findAll(): Promise<Message[]> {
  //   return this.messageModel.find().exec();
  // }
}
