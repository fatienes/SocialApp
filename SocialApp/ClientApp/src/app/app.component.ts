import { Component, OnInit } from '@angular/core';
import { Model } from './Model';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from "@auth0/angular-jwt";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SocialApp'; jwtHelper = new JwtHelperService();

 constructor(private authServices: AuthService){}


ngOnInit() {
 const token = localStorage.getItem("token");
 if(token){
   this.authServices.decodedToken =this.jwtHelper.decodeToken(token);
 }
}


}
