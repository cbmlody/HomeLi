import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BookListComponent } from './components/book-list/book-list.component';

@NgModule({
    imports: [
        CommonModule,
    ],
    declarations: [
        BookListComponent
    ]
})

export class LibraryModule {}
