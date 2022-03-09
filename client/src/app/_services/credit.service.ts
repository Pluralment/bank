import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CreditContract } from '../models/creditContract';
import { CreditType } from '../models/creditType';

@Injectable({
  providedIn: 'root'
})
export class CreditService {
  baseApi = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCreditTypes() {
    return this.http.get<CreditType[]>(this.baseApi + 'creditTypes');
  }

  createCreditContract(credit: Partial<CreditContract>) {
    return this.http.post<CreditContract>(this.baseApi + 'credit', credit);
  }

  getCreditsByClientId(clientId: number) {
    return this.http.get<CreditContract[]>(this.baseApi + 'credit/GetCreditsByClientId/' + clientId);
  }
}
