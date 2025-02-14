import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Book } from '../models/book'; 



@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7048/api/Books';

  constructor(private http: HttpClient) {}

  createBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.apiUrl, book);
  }

  updateBook(book: Book): Observable<Book> {
    return this.http.put<Book>(`${this.apiUrl}/${book.id}`, book);
  }

  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
  getBooks(): Observable<Book[]> {
    return this.http.get<{ data: Book[] }>(this.apiUrl).pipe(
      map(response => response.data)  
    );
  }
  getBooksByID(id: number): Observable<Book> {
    return this.http.get< Book >(`${this.apiUrl}/${id}`).pipe(
      map(response => response)  
    );
  }
}
