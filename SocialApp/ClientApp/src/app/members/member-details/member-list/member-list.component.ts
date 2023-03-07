import { Component, OnInit } from '@angular/core';
import { User } from '../../../_models/user';
import { AlertifyService } from '../../../_services/alertify.services';
import { UserService } from '../../../_services/user.services';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
users: User[];
  constructor(private userServices: UserService, private alertify: AlertifyService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.userServices.getUsers().subscribe(users=>{
      this.users= users;


    }, err =>{
      this.alertify.error(err);

    })
  }

}
