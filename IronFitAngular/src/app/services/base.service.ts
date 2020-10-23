import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BaseService {

  constructor(private httpClient: HttpClient) {}

  public get(url, params = ''): Observable<any> {
    return this.httpClient.get(`${url}/${params}`)
      .pipe(map((result: any) => result));
  }

  public post(url, params): Observable<any> {
    return this.httpClient.post(`${url}/`, params)
      .pipe(map((result: any) => result));
  }

  public put(url, params): Observable<any> {
    return this.httpClient.put(`${url}/`, params)
      .pipe(map((result: any) => result));
  }

  public delete(url, params = ''): Observable<any> {
    return this.httpClient.delete(`${url}/${params}`)
      .pipe(map((result: any) => result));
  }

  protected createQueryString(parameters: any): string {
    let queryString = '';
    let colocarEComercial = false;

    for (const key in parameters) {
      if (parameters.hasOwnProperty(key)) {
        if (parameters[key] !== null || parameters[key] !== undefined) {
          if (colocarEComercial) {
            queryString += '&';
          }
          if (Array.isArray(parameters[key])) {
            parameters[key].forEach(element => {
              queryString += `${key}=${element}&`;
            });
          } else {
            queryString += key + '=' + parameters[key];
          }
          if (!colocarEComercial) {
            colocarEComercial = true;
          }
        }
      }
    }

    if (queryString !== '') {
      return '?' + queryString;
    }

    return '';
  }
}
