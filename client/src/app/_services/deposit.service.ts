import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AccountReport } from '../models/accountReport';
import { DepositContract } from '../models/depositContract';
import { DepositType } from '../models/depositType';
import { EntryReport } from '../models/entryReport';

@Injectable({
  providedIn: 'root'
})
export class DepositService {
  baseUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getDepositTypes() {
    return this.http.get<DepositType[]>(this.baseUrl + 'depositTypes');
  }

  getDepositsByClientId(clientId: number) {
    return this.http.get<DepositContract[]>(this.baseUrl + 'deposit/GetDepositsByClientId/' + clientId);
  }

  createDepositContract(deposit: Partial<DepositContract>) {
    return this.http.post<DepositContract>(this.baseUrl + 'deposit', deposit);
  }

  closeDeposit(depositId: number) {
    return this.http.put(this.baseUrl + 'deposit/' + depositId, depositId);
  }

  getAccountReports() {
    return this.http.get<AccountReport[]>(this.baseUrl + 'deposit/AccountsReport');
  }
  
  getEntryReports() {
    return this.http.get<EntryReport[]>(this.baseUrl + 'deposit/EntriesReport');
  }
}
