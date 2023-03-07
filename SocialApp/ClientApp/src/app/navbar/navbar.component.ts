import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.services';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model : any = {};

  constructor(public authSerivce: AuthService, private router: Router, private alertify:AlertifyService) { }

  ngOnInit(): void {
  }

  login(){

    this.authSerivce.login(this.model).subscribe(next =>{
      this.alertify.success("login başarılı");
      this.router.navigate(['/members']);
    }, error =>
    {
      this.alertify.error(error);

    }

    )
  }
    loggedIn(){
    return this.authSerivce.loggedIn();
    }
    logout(){
      localStorage.removeItem("token");
      this.alertify.warning("logout");
      this.router.navigate(['/home']);
    }
}
