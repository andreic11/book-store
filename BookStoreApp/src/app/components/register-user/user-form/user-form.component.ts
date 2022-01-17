import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserRequest } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  constructor(public service : UserService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formDataId==""){
      this.insertRecord(form);
    }else{
      // this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.createUser().subscribe(
      res => {
        this.resetForm(form);
        // this.service.refreshList();
        this.toastr.success('Successful', 'User Register')
      },
      err => { console.log(err); }
    );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new UserRequest();
    this.service.formDataId = "";
  }

}