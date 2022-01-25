import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CartService } from '../services/cart.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(public service: CartService,
    private userService: UserService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    let userId = this.userService.getUserId();
    this.service.getCartItems(userId);
  }

  onRemove(id:string){
    if(confirm("Are you sure to remove this item from cart?")){
      this.service.removeItem(id)
      .subscribe(
        res => {
          let userId = this.userService.getUserId();
          this.service.getCartItems(userId);
          this.toastr.info("Successfully", "Removed from cart");
        },
        err => {console.log(err);}
      );
    }
  }

}
