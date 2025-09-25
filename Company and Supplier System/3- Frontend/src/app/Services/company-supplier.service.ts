import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { BaseService } from './base.service';
import { ICompanySupplier } from '../Interfaces/company-supplier.interface';

import { IReturn } from '../Interfaces/return.interface';
import { ICompanySupplierReturn } from '../Interfaces/company-supplier-return.interface';

@Injectable({
  providedIn: 'root'
})

export class CompanySupplierService extends BaseService {

  constructor(private readonly http: HttpClient){
    super()
  }

  public postCompanySupplier(companySupplier: ICompanySupplier): Observable<ICompanySupplier> {
    const str_Url = `${this.BaseUrl()}/CompanySupplier`;
  
    return this.http.post<IReturn>(str_Url, companySupplier, {
      headers: { 'Content-Type': 'application/json' }
    }).pipe(
      map((response: IReturn): ICompanySupplier => response.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public getCompanySupplier(Company_Cnpj_Name: string): Observable<any[]> {
    const str_Url = `${this.BaseUrl()}/CompanySupplier`;
    let Cpf_Cnpj = ''
    let Name = ''

    if (/^\d+$/.test(Company_Cnpj_Name)) {
      Cpf_Cnpj = Company_Cnpj_Name
    } else {
      Name = Company_Cnpj_Name
    }

    const params = {
      company_Cnpj: Cpf_Cnpj,
      name: Name
    };

    return this.http.get<IReturn>(str_Url, { params }).pipe(
      map((data: IReturn): ICompanySupplierReturn[] => data.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }

  public DeleteCompanySupplier(companySupplier: ICompanySupplier): Observable<ICompanySupplier> {
    const str_Url = `${this.BaseUrl()}/CompanySupplier`;
  
    return this.http.delete<IReturn>(str_Url, {
      headers: { 'Content-Type': 'application/json' },
      body: companySupplier
    }).pipe(
      map((response: IReturn): ICompanySupplier => response.data),
      catchError((error: HttpErrorResponse) => {
        const errorMsg = error.error?.message;
        return throwError(() => new Error(errorMsg));
      })
    );
  }
}