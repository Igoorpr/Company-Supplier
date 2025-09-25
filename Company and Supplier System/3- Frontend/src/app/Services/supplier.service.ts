import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from './base.service';

import { IReturn } from '../Interfaces/return.interface';
import { ISupplier } from '../Interfaces/supplier.interface';
import { ISupplierKey } from '../Interfaces/supplierKey.interface';
import { IReturnObject } from '../Interfaces/return-object.interface';
import { ICepReturn } from '../Interfaces/returnCep.interface';

@Injectable({
  providedIn: 'root'
})

export class SupplierService extends BaseService {

  constructor(private readonly http: HttpClient){
    super()
  }

  public postSupplier(supplier: ISupplier): Observable<string> {
    const str_Url = `${this.BaseUrl()}/Supplier`;

    return this.http.post<IReturn>(str_Url, supplier, {
      headers: { 'Content-Type': 'application/json' }
    }).pipe(
      map((response: IReturn) => response.message),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public getSupplier(Supplier_Cpf_Cnpj: string): Observable<any[]> {
    const str_Url = `${this.BaseUrl()}/Supplier`;

    const params = {
      supplierCpfCnpj: Supplier_Cpf_Cnpj
    };

    return this.http.get<IReturnObject>(str_Url, { params }).pipe(
      map((data: IReturnObject) => Array.isArray(data.data) ? data.data : []),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public putSupplier(supplier: ISupplier): Observable<string> {
    const str_Url = `${this.BaseUrl()}/Supplier`;
  
    return this.http.put<IReturn>(str_Url, supplier, {
      headers: { 'Content-Type': 'application/json' }
    }).pipe(
      map((response: IReturn) => response.message),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public DeleteSupplier(supplier: ISupplierKey): Observable<string> {
    const str_Url = `${this.BaseUrl()}/Supplier`;
  
    return this.http.delete<IReturn>(str_Url, {
      headers: { 'Content-Type': 'application/json' },
      body: supplier
    }).pipe(
      map((response: IReturn) => response.message),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public getCep (cep: string): Observable<any> {
    const str_Url = `https://viacep.com.br/ws/${cep}/json/`;

    return this.http.get<ICepReturn>(str_Url).pipe(
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }
}