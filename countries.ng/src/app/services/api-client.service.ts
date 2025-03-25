import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  public getAllCountries() {
    return this.http.get(`${environment.api.baseUrl}/all`);
  }
}
