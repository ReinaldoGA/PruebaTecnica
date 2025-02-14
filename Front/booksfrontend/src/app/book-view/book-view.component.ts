import { Component, Inject,OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Book } from '../models/book';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-book-view',
  templateUrl: './book-view.component.html',
  styleUrls: ['./book-view.component.css'],
  imports: [
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule ,
MatNativeDateModule  

  ]
})
export class BookViewComponent  implements OnInit {  
  constructor(
    public dialogRef: MatDialogRef<BookViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { book: Book },
    private snackBar: MatSnackBar
  ) {}
  ngOnInit() {
    if (!this.data || !this.data.book) {
      this.snackBar.open('⚠️ Error: No se encontraron datos del libro', 'Cerrar', { duration: 3000 });
      this.dialogRef.close();
      return;
    }
  }
  closeDialog() {
    this.dialogRef.close();
  }
}
