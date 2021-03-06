import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserAuth, UserRequest } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public service: UserService,
    private toastr: ToastrService,
    private _router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.logIn(form);
  }

  logIn(form: NgForm) {
    this.service.authenticateUser().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Successful', 'Login');
        var u = res as UserAuth;
        localStorage.setItem(UserService.AUTH_KEY, u.token);
        this._router.navigate(['/home']);
      },
      err => { console.log(err); }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new UserRequest();
    this.service.formDataId = "";
  }
}