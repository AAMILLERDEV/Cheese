import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginForm } from 'src/form-models/login-form';
import { User } from 'src/models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  public loginForm: FormGroup;

  constructor(public router: Router){
    this.loginForm = LoginForm;
  }

  public ngOnInit() {
    
  }

  public submitUserLoginCredentials(){

    let user: User = {
      password: this.loginForm.controls['passwordControl'].value,
      username: this.loginForm.controls['usernameControl'].value
    }

    sessionStorage.setItem("User", JSON.stringify(user));


    this.router.navigateByUrl("home");
  }
}
