import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Invalidity } from '../models/invalidity';

@Injectable({
  providedIn: 'root'
})
export class InvalidityService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getInvalidityTypes() {
    return this.http.get<Invalidity[]>(this.baseUrl + 'invalidities');
  }
}
