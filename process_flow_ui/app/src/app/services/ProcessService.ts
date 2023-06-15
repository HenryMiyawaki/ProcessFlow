import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProcessModel } from '../models/ProcessModel';

@Injectable({
  providedIn: 'root',
})
export class ProcessService {
  private apiUrl: string = `${environment.apiUrlBase}/Process`;

  constructor(private http: HttpClient) {}

  getProcesses(areaName: string): Observable<ProcessModel[]> {
    return this.http.get<ProcessModel[]>(`${this.apiUrl}/${areaName}`);
  }

  getProcessById(areaId: string, id: string): Observable<ProcessModel> {
    return this.http.get<ProcessModel>(`${this.apiUrl}/${areaId}/${id}`);
  }

  createProcess(
    areaId: string,
    process: ProcessModel
  ): Observable<ProcessModel> {
    return this.http.post<ProcessModel>(`${this.apiUrl}/${areaId}`, process);
  }

  updateProcess(
    areaId: string,
    id: string,
    process: ProcessModel
  ): Observable<ProcessModel> {
    return this.http.put<ProcessModel>(
      `${this.apiUrl}/${areaId}/${id}`,
      process
    );
  }

  deleteProcess(areaId: string, id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${areaId}/${id}`);
  }
}
