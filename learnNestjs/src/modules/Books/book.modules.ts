import { Module } from '@nestjs/common';
import { BookService } from './book.service';
import { BookService2 } from './book.service2'

@Module({
    imports: [],
    providers: [BookService, BookService2],
    exports:[BookService, BookService2]
})
export class BookModule {
}