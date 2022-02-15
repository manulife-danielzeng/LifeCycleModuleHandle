import { Injectable } from '@nestjs/common';
import { bookDto } from './book.dto';

@Injectable()
export class BookService {
    getBoo(): bookDto {
        var result = new bookDto();
        result.author = "金庸";
        result.name = "天龙八部";
        return result;
    }
}
