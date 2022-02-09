import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];

  constructor(private userService: UserService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
      console.log(this.users);
    });
  }

  deleteUser(userId: number) {
    this.userService.deleteUser(userId).subscribe(() => {
      let userName: string = "";
      this.users = this.users.filter((element, index, array) => {
        if (element.id == userId) userName = element.name;
        return (element.id !== userId); 
      });
      this.toastr.info(userName + " удален");
    });
  }

  updateUser(userId: number) {
    console.log(userId);
  }

}
