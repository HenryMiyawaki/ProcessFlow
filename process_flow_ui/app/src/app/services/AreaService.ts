import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AreaModel } from '../models/AreaModel';

@Injectable({
  providedIn: 'root',
})
export class AreaService {
  private apiUrl: string = `${environment.apiUrlBase}/Area`;

  constructor(private http: HttpClient) {}

  getAreas(): Observable<AreaModel[]> {
    return this.http.get<AreaModel[]>(`${this.apiUrl}`);
  }

  getAreaById(id: string): Observable<AreaModel> {
    return this.http.get<AreaModel>(`${this.apiUrl}/${id}`);
  }

  createArea(area: AreaModel): Observable<AreaModel> {
    return this.http.post<AreaModel>(`${this.apiUrl}`, area);
  }

  updateArea(id: string, area: AreaModel): Observable<AreaModel> {
    return this.http.put<AreaModel>(`${this.apiUrl}/${id}`, area);
  }

  deleteArea(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
