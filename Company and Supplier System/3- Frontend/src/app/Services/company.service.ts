import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from './base.service';

import { IReturn } from '../Interfaces/return.interface';
import { ICompany } from '../Interfaces/company.interface';
import { ICompanyKey } from '../Interfaces/companyKey.interface';


@Injectable({
  providedIn: 'root'
})

export class CompanyService extends BaseService {

  constructor(private readonly http: HttpClient){
    super()
  }

  public postCompany(company: ICompany): Observable<ICompany> {
    const str_Url = `${this.BaseUrl()}/Company`;
  
    return this.http.post<IReturn>(str_Url, company, {
      headers: { 'Content-Type': 'application/json' }
    }).pipe(
      map((response: IReturn): ICompany => response.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public getCompany(Company_Cnpj_Name: string): Observable<any[]> {
    const str_Url = `${this.BaseUrl()}/Company`;

    const params = {
      companyCnpj: Company_Cnpj_Name
    };

    return this.http.get<IReturn>(str_Url, { params }).pipe(
      map((data: IReturn): ICompany[] => data.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public putCompany(company: ICompany): Observable<ICompany> {
    const str_Url = `${this.BaseUrl()}/Company`;
  
    return this.http.put<IReturn>(str_Url, company, {
      headers: { 'Content-Type': 'application/json' }
    }).pipe(
      map((response: IReturn): ICompany => response.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public DeleteCompany(company: ICompanyKey): Observable<ICompanyKey> {
    const str_Url = `${this.BaseUrl()}/Company`;
  
    return this.http.delete<IReturn>(str_Url, {
      headers: { 'Content-Type': 'application/json' },
      body: company
    }).pipe(
      map((response: IReturn): ICompanyKey => response.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }
}