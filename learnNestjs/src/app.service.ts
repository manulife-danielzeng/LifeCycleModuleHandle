import { Injectable } from '@nestjs/common';
import { BookService2 } from './modules/Books/book.service2';

@Injectable()
export class AppService {
  constructor(private bookService: BookService2) {

  }
  getHello(): string {
    var book = this.bookService.getBoo();
    return JSON.stringify(book);
  }
}
