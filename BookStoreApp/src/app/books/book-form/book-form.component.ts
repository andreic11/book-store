import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BookRequest } from 'src/app/models/book.model';
import { BookService } from 'src/app/books/service/book.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  constructor(public service: BookService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formDataId==""){
      this.insertRecord(form);
    }else{
      this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.createBook().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.success('Successfully', 'Book Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form:NgForm){
    this.service.updateBook().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        this.toastr.info('Book updated successfully', 'Update');
      },
      err => { console.log(err); }
    );
  }


  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new BookRequest();
    this.service.formDataId = "";
  }

}
