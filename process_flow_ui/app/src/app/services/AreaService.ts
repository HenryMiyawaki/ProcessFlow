import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AreaModel } from '../models/AreaModel';

@Injectable({
  providedIn: 'root',
})
export class AreaService {
  constructor(private http: HttpClient) {}

  getAreas(): Observable<AreaModel[]> {
    return this.http.get<AreaModel[]>(`${environment.apiUrl}`);
  }

  getAreaById(id: string): Observable<AreaModel> {
    return this.http.get<AreaModel>(`${environment.apiUrl}/${id}`);
  }

  createArea(area: AreaModel): Observable<AreaModel> {
    return this.http.post<AreaModel>(`${environment.apiUrl}`, area);
  }

  updateArea(id: string, area: AreaModel): Observable<AreaModel> {
    return this.http.put<AreaModel>(`${environment.apiUrl}/${id}`, area);
  }

  deleteArea(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/${id}`);
  }
}
