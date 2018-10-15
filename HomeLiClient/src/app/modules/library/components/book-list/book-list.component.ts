import { Component, OnInit } from '@angular/core';
import { BookModel } from '../../models/api-models/book-model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.less']
})

export class BookListComponent implements OnInit {

  public bookList: Array<BookModel>;

  constructor() {
    this.bookList = [
      {
        guid: '375602e2-9759-4b2b-ae9e-5ee659014a8f',
        title: 'Game of Thrones',
        description: 'Qui reprehenderit anim fugiat occaecat cillum irure Lorem ut id ex cupidatat tempor.',
        pages: 465,
        author: 'George R.R. Martin'
      },
      {
        guid: '8754154f-132e-479c-b138-c0c0f24357d0',
        title: 'Dance with dragons',
        description: 'Do ullamco excepteur ullamco do elit in reprehenderit.',
        pages: 553,
        author: 'George R.R. Martin'
      },
      {
        guid: '8754154f-132e-479c-b138-c0c0f24357d0',
        title: 'Dance with dragons',
        description: 'Do ullamco excepteur ullamco do elit in reprehenderit.',
        pages: 553,
        author: 'George R.R. Martin'
      },
      {
        guid: '8754154f-132e-479c-b138-c0c0f24357d0',
        title: 'Dance with dragons',
        description: 'Do ullamco excepteur ullamco do elit in reprehenderit.',
        pages: 553,
        author: 'George R.R. Martin'
      },
      {
        guid: '375602e2-9759-4b2b-ae9e-5ee659014a8f',
        title: 'Game of Thrones',
        description: 'Qui reprehenderit anim fugiat occaecat cillum irure Lorem ut id ex cupidatat tempor.',
        pages: 465,
        author: 'George R.R. Martin'
      },
      {
        guid: '8754154f-132e-479c-b138-c0c0f24357d0',
        title: 'Dance with dragons',
        description: 'Do ullamco excepteur ullamco do elit in reprehenderit.',
        pages: 553,
        author: 'George R.R. Martin'
      },
      {
        guid: '8754154f-132e-479c-b138-c0c0f24357d0',
        title: 'Dance with dragons',
        description: 'Do ullamco excepteur ullamco do elit in reprehenderit.',
        pages: 553,
        author: 'George R.R. Martin'
      },
      {
        guid: '8754154f-132e-479c-b138-c0c0f24357d0',
        title: 'Dance with dragons',
        description: 'Do ullamco excepteur ullamco do elit in reprehenderit.',
        pages: 553,
        author: 'George R.R. Martin'
      },
    ];
   }

  ngOnInit() {
  }

}
