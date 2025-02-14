import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators,  ReactiveFormsModule} from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ApiService } from '../services/api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Book } from '../models/book';  


@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css'],
  imports: [
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule ,
MatNativeDateModule  

  ],
})
export class BookCreateComponent {
  bookForm: FormGroup;

  constructor(private fb: FormBuilder, private dialogRef: MatDialogRef<BookCreateComponent>,private apiService: ApiService,
    private snackBar: MatSnackBar) {
    this.bookForm = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      pageCount: ['', [Validators.required, Validators.min(1)]],
      excerpt: [''],
      publishDate: ['']
    });
  }

  onCancel() {
    this.dialogRef.close();
  }

  onSave() {
    if (this.bookForm.valid) {
      const newBook: Book = this.bookForm.value;

      this.apiService.createBook(newBook).subscribe({
        next: (createdBook) => {
          this.snackBar.open('Libro creado exitosamente', 'Cerrar', { duration: 3000 });
          this.dialogRef.close(createdBook);
        },
        error: (err) => {
          console.error('Error creando el libro:', err);
          this.snackBar.open('Error al crear el libro', 'Cerrar', { duration: 3000 });
        }
      });
    } else {
      this.snackBar.open('Por favor completa los campos obligatorios', 'Cerrar', { duration: 3000 });
    }
        
    }
}
