import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Cheese } from 'src/models/Cheese';

@Injectable({
  providedIn: 'root'
})
export class CheeseService {



  constructor(private http: HttpClient) {

  }

  public getCheeses(){
    var url = `http://localhost:5172/Cheese/GetCheddars`;
    return lastValueFrom(this.http.get<Cheese[]>(url));
  }
}
