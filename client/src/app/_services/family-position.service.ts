import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FamilyPosition } from '../models/familyPosition';

@Injectable({
  providedIn: 'root'
})
export class FamilyPositionService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getFamilyPositions() {
    return this.http.get<FamilyPosition[]>(this.baseUrl + 'familyPositions');
  }
}
