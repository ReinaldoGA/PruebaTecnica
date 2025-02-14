import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book } from '../models/book';  


@Component({
  selector: 'app-book-view',
  templateUrl: './book-view.component.html'
})
export class BookViewComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public book: Book,) {}

}


