import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { User, UserRequest } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http : HttpClient,
    private toastr:ToastrService) { }
  
  static readonly AUTH_KEY = "auth";
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

  getUsers(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => this.list = res as User[]);
  }

  loggedIn(){
    return !!localStorage.getItem(UserService.AUTH_KEY);
  }

  logOut(){
    localStorage.removeItem(UserService.AUTH_KEY);
    this.toastr.info('Successful', 'Logout');
  }

  getRole(){
    if(this.loggedIn()){
      let jwtToken = localStorage.getItem(UserService.AUTH_KEY);
      jwtToken = jwtToken ? jwtToken : "";
      var payload = atob(jwtToken.split('.')[1]); //decode from base64
      const payloadData = JSON.parse(payload);
      return payloadData.role;
    }
    return "";
  }

  isAdmin(){
    let role = this.getRole();
    if(role.toUpperCase().localeCompare("ADMIN")==0){
        return true;
    }
    return false;
  }
}