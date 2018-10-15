import { IBookModel } from '../api-interfaces/i-book-model';
import { Guid } from '../guid';

export class BookModel implements IBookModel {
    guid: Guid;
    title: string;
    description: string;
    pages: number;
    author: string;
}
