import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Currency } from '../models/currency';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getCurrencies() {
    return this.http.get<Currency[]>(this.baseUrl + 'currencies');
  }
}
