import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createUser(user: User) {
    return this.http.post<User>(this.baseUrl + 'clients', user);
  }

  getUsers() {
    return this.http.get<User[]>(this.baseUrl + 'clients');
  }

  updateUser(user: User) {
    return this.http.put<User>(this.baseUrl + 'clients', user);
  }

  deleteUser(id: number) {
    return this.http.delete(this.baseUrl + 'clients/' + id, {});
  }
}