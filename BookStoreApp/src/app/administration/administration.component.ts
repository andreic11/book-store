import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-administration',
  templateUrl: './administration.component.html',
  styleUrls: ['./administration.component.css']
})
export class AdministrationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getUsers();
  }

  onDelete(id:string){
    if(confirm("Are you sure to delete this user?")){
      this.service.deleteUser(id)
      .subscribe(
        res => {
          this.service.getUsers();
          this.toastr.error("User deleted successfully", "Delete");
        },
        err => {console.log(err);}
      );
    }
  }

}
