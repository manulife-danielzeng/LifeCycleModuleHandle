import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import {BookModule} from './modules/Books/book.modules'

@Module({
  imports: [
    BookModule
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
