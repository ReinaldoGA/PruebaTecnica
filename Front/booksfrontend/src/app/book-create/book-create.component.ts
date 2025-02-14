import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ApiService } from '../services/api.service';
import { Book } from '../models/book';  


@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html'
})
export class BookCreateComponent {
  book: Book = { id: 0, title: '', description: '', pageCount: 0, excerpt: '', publishDate: new Date };

  constructor(private apiService: ApiService, private dialogRef: MatDialogRef<BookCreateComponent>) {}

  save() {
    this.apiService.createBook(this.book).subscribe(() => {
      this.dialogRef.close(true);
    });
  }
}
