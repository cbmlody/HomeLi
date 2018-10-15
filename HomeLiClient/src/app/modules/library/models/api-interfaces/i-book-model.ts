import { Guid } from '../guid';

export interface IBookModel {
    guid: Guid;
    title: string;
    description: string;
    pages: number;
    author: string;
}
