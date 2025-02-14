import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { CommonModule } from '@angular/common';
import { ApiService } from './services/api.service';
import { Book } from './models/book';  
import { BookCreateComponent } from '../app/book-create/book-create.component';
import { BookEditComponent } from '../app/book-edit/book-edit.component';
import { BookViewComponent } from '../app/book-view/book-view.component';
import { MatIconModule } from '@angular/material/icon';  
import { MatTooltipModule } from '@angular/material/tooltip';  
import { MatDatepickerModule } from '@angular/material/datepicker';  
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [CommonModule, MatTableModule, MatToolbarModule,MatIconModule,MatTooltipModule,MatDatepickerModule]  
})



export class AppComponent implements OnInit {
  displayedColumns: string[] = ['id','title','description','pageCount','excerpt','publishDate', 'acciones'];
  dataSource: any[] = [];
   
  constructor(private apiService: ApiService, private dialog: MatDialog,private snackBar: MatSnackBar) {}

  ngOnInit() {
    this.apiService.getBooks().subscribe({
      next: (data: Book[]) => {
        this.dataSource = data.map((book: Book) => ({
          id: book.id,
          title: book.title, 
          description: book.description ,
          pageCount: book.pageCount ,
          excerpt: book.excerpt ,
          publishDate: book.publishDate ,
        }));
      },
      error: (err) => console.error('Error al obtener los datos:', err)
    });
    
  }

  openCreateDialog() {
    const dialogRef = this.dialog.open(BookCreateComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.apiService.getBooks();
      }
    });
  }
  
  openEditDialog(book: Book) {
    console.log(book);
    const dialogRef = this.dialog.open(BookEditComponent, {
      data: { book },  
      width: '500px' 
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.apiService.getBooks();
      }
    });
  }
  
  openViewDialog(book: Book) {
    const dialogRef = this.dialog.open(BookViewComponent, {
      data: { book },  
      width: '500px' 
    });
  }


  deleteBook(id: number) {
    if (confirm("¿Estás seguro de eliminar este libro?")) {
      this.apiService.deleteBook(id).subscribe({
        next: () => {
          this.dataSource = this.dataSource.filter(book => book.id !== id);
          this.snackBar.open('📖 Libro eliminado exitosamente', 'Cerrar', { duration: 3000 });
        },
        error: (err) => this.snackBar.open('Ha ocurrido un error', 'Cerrar', { duration: 3000 })
      });
    }
  }
}
