import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Product } from '../model/product';
import { environment } from 'src/environments/environment';


const httpOptions = {
  headers: new HttpHeaders({
    'content-type': 'application/json; charset=UTF-8;',
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  endPoint: string = 'Product';

  constructor(private http: HttpClient) { }

  addProduct(requestProduct: Product): Observable<any> {
    return this.http.post<any>(environment.apiNorthwind
      .concat(this.endPoint),
      requestProduct)
      .pipe(
        catchError(this.handleError('Products', []))
      );
  }

  getProduct(): Observable<Product[]> {
    return this.http.get<Product[]>(environment.apiNorthwind
      .concat(this.endPoint),
      httpOptions)
      .pipe(
        catchError(this.handleError('Products', []))
      );
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(environment.apiNorthwind
      .concat(this.endPoint + '/' + id))
      .pipe(
        catchError(this.handleError('DeleteProduct', []))
      );

  }

  upDateProduct(product: Product): Observable<any> {
    return this.http.put<any>(environment.apiNorthwind
      .concat(this.endPoint),
      product)
      .pipe(
        catchError(this.handleError('UpDateProduct', []))
      );
  }

  //#region Handle Error
  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // Let the app keep running by returning an empty result.
      //return of(result as T);
      return of(error);
    };
  }

  //#endregion
}
