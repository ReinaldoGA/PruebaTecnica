import { Component, Inject, OnInit } from '@angular/core';  
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from '../services/api.service';
import { Book } from '../models/book';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css'],
  imports: 
  [
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule ,
MatNativeDateModule  
  ]
})
export class BookEditComponent   implements OnInit {
  bookForm!: FormGroup;

  constructor(
    private dialogRef: MatDialogRef<BookEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { book: Book },  
    private fb: FormBuilder,
    private apiService: ApiService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    if (!this.data || !this.data.book) {
      this.snackBar.open('⚠️ Error: No se encontraron datos del libro', 'Cerrar', { duration: 3000 });
      this.dialogRef.close();
      return;
    }

    this.bookForm = this.fb.group({
      title: [this.data.book.title, Validators.required],
      description: [this.data.book.description],
      pageCount: [this.data.book.pageCount, [Validators.required, Validators.min(1)]],
      excerpt: [this.data.book.excerpt],
      publishDate: [this.data.book.publishDate, Validators.required]
    });
  }


  onSave() {
    if (this.bookForm.valid) {
      const bookData: Book = { ...this.bookForm.value, id: this.data.book.id };

      this.apiService.updateBook( bookData).subscribe({
        next: () => {
          this.snackBar.open('📘 Libro actualizado correctamente', 'Cerrar', { duration: 3000 });
          this.dialogRef.close(bookData);
        },
        error: () => {
          this.snackBar.open('❌ Error al actualizar el libro', 'Cerrar', { duration: 3000 });
        }
      });
    } else {
      this.snackBar.open('⚠️ Completa los campos obligatorios', 'Cerrar', { duration: 3000 });
    }
  }

  onCancel() {
    this.dialogRef.close();
  }
}
