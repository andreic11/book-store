import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book, BookRequest } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44350/api/Books';
  // formData : Book = new Book();
  formData : BookRequest = new BookRequest();
  formDataId : string = "";
  list : Book[] = [];

  
  createBook(){
    return this.http.post(this.baseURL+"/create", this.formData);
  }

  updateBook(){
    return this.http.put(`${this.baseURL}/${this.formDataId}`, this.formData);
  }

  deleteBook(id:string){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as Book[]);
  }


}
