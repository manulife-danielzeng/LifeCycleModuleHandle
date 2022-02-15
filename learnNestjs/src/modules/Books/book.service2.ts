import { Injectable } from '@nestjs/common';
import { bookDto } from './book.dto';
import { BookService } from './book.service';

@Injectable()
export class BookService2 {
    constructor(private bs1: BookService){

    }
    getBoo(): bookDto {
        var result = this.bs1.getBoo();
        result.name="神雕侠侣";
        return result;
    }
}
