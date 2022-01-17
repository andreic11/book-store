import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books-page',
  templateUrl: './books-page.component.html',
  styleUrls: ['./books-page.component.css']
})
export class BooksPageComponent implements OnInit {

  constructor(public service: BookService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord : Book){
    this.service.formData = Object.assign({}, selectedRecord);
    this.service.formDataId = selectedRecord.id;
    // this.service.formDataId = 
  }

  onDelete(id:string){
    if(confirm("Are you sure to delete this record?")){
      this.service.deleteBook(id)
      .subscribe(
        res => {
          this.service.refreshList();
          this.toastr.error("Book deleted successfully", "Delete");
        },
        err => {console.log(err);}
      );
    }
  }

}
