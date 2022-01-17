import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User, UserRequest } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient) { }

  readonly baseURL = 'https://localhost:44350/api/Users';
  formData : UserRequest = new UserRequest();
  formDataId : string = "";
  list : User[] = [];

  createUser(){
    return this.http.post(this.baseURL+"/create", this.formData);
  }

  authenticateUser(){
    return this.http.post(this.baseURL+"/authentificate", this.formData);
  }
}