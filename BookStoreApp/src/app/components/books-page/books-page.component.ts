import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Book } from 'src/app/models/book.model';
import { BookService } from 'src/app/services/book.service';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-books-page',
  templateUrl: './books-page.component.html',
  styleUrls: ['./books-page.component.css']
})
export class BooksPageComponent implements OnInit {

  constructor(public service: BookService,
    public userService: UserService,
    public cartService: CartService,
    private _router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord : Book){
    this.service.formData = Object.assign({}, selectedRecord);
    this.service.formDataId = selectedRecord.id;
  }

  addBook(){
    this._router.navigate(['/book/create']);
  }

  editBook(selectedRecord : Book){
    this.populateForm(selectedRecord);
    this._router.navigate([`/book/${selectedRecord.id}`]);
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

  addToCart(bookId:string){
    var userId = this.userService.getUserId();
    if(confirm("Add to cart?")){
      this.cartService.addItem(userId, bookId)
      .subscribe(
        res => {
          this.toastr.info("Book added to cart", "Item added");
        },
        err => {console.log(err);}
      );
    }
  }

}
