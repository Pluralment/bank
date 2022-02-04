import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { City } from '../models/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createCity(city: City) {
    return this.http.post<City>(this.baseUrl + 'cities', city);
  }

  getCities() {
    return this.http.get<City[]>(this.baseUrl + 'cities');
  }

  deleteCity(id: number) {
    return this.http.delete(this.baseUrl + 'cities/' + id, {});
  }
}
