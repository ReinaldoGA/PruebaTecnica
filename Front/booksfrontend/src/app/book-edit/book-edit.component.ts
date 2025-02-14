import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ApiService } from '../services/api.service';
import { Book } from '../models/book'; 

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html'
})
export class BookEditComponent {
  book: Book;

  constructor(
    private apiService: ApiService,
    private dialogRef: MatDialogRef<BookEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Book
  ) {
    this.book = { ...data };
  }

  save() {
    this.apiService.updateBook(this.book).subscribe(() => {
      this.dialogRef.close(true);
    });
  }
  closeDialog() {
    this.dialogRef.close();
  }
}
