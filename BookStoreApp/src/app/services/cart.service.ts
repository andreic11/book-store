import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book, BookRequest } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:44350/api/Cart';
  list : Book[] = [];

  addItem(userId:string, itemId:string){
    return this.http.put(`${this.baseURL}/${userId}/${itemId}`,null);
  }

  removeItem(itemId:string){
    return this.http.put(`${this.baseURL}/${itemId}`,null);
  }

  getCartItems(userId:string){
    this.http.get(`${this.baseURL}/${userId}`)
    .toPromise()
    .then(res => this.list = res as Book[]);
  }

}
