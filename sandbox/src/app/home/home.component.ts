import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Cheese } from 'src/models/Cheese';
import { CheeseService } from 'src/services/cheese.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})


export class HomeComponent implements OnInit {

  public cheeses: Cheese[] = [];

  constructor (public cheeseService: CheeseService,
    public toastr: ToastrService,
    public router: Router) {

  }


  public async ngOnInit(){

    let userLogged = JSON.parse(sessionStorage.getItem("User")!);
    console.log(userLogged);
    if (!userLogged){
      this.router.navigateByUrl("login");
    }

    this.toastr.success("Hello!");
    this.cheeses = await this.cheeseService.getCheeses();
  }
}
