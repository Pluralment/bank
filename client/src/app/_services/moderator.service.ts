import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ModeratorService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  closeBankDay() {
    return this.http.put(this.baseUrl + 'deposit/CloseBankDay', []);
  }
}
