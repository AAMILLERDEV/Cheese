import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Cheese } from 'src/models/Cheese';
import { SharedService } from './shared.service';

@Injectable({
  providedIn: 'root'
})

export class CheeseService {



  constructor(private http: HttpClient, private sharedService: SharedService) {

  }

  public getCheeses(){
    return this.sharedService.get("Cheese/GetCheese");
  }

  public upsertCheese(cheese: Cheese){
    return this.sharedService.upsert("Cheese/UpsertCheese", cheese);
  }
}
