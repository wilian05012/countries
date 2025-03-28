import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Country } from '../core/country';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  constructor(private http: HttpClient) { }

  public getAllCountries() :Observable<Country[]> {
    return this.http.get(`${environment.api.baseUrl}/all`) as Observable<Country[]>;
  }
}
