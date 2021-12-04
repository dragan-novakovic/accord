import { join } from "path";
import {
  Transport,
  ClientOptions,
  MicroserviceOptions,
} from "@nestjs/microservices";
import { NestFactory } from "@nestjs/core";
import { AppModule } from "./app.module";

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  app.connectMicroservice<MicroserviceOptions>({
    transport: Transport.GRPC,
    options: {
      package: ["user"],
      protoPath: [join(__dirname, "./user/user.proto")],
    },
  });

  await app.listen(3003);
}
bootstrap();
