import { Prop, Schema, SchemaFactory } from "@nestjs/mongoose";
import { Document } from "mongoose";

@Schema()
export class User extends Document {
  @Prop()
  username: string;
}
// roomID - cascade delete?
export const UserSchema = SchemaFactory.createForClass(User);
