import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CompanySupplierService } from '../../Services/company-supplier.service';
import { ICompanySupplierReturn } from '../../Interfaces/company-supplier-return.interface';
import { ICompanySupplier } from '../../Interfaces/company-supplier.interface';

@Component({
  selector: 'app-company-supplier',
  imports: [
    CommonModule,
    FormsModule, 
  ],
  templateUrl: './company-supplier.html',
  styleUrls: ['./company-supplier.scss']
})

@Injectable({providedIn: 'root'})

export class CompanySupplier implements OnInit {
  public suppliers: ICompanySupplierReturn[] = [];
  modalOpen = false;
  searchTerm = '';
  newSupplier: any = {};
  messageText: string = '';
  messageType: 'error' | 'success' | 'info' | '' = ''; 

  constructor(
      private companySupplierService: CompanySupplierService,
      private readonly router: Router
    ){
  }

  ngOnInit(): void {
     this.companySupplierService.getCompanySupplier(this.searchTerm).subscribe(
       (result: ICompanySupplierReturn[]) => {
         this.suppliers = result;
       },
       error => {
         this.showMessage(error, 'error')
       }
     );
  }
  
  saveSupplier() {
    this.companySupplierService.postCompanySupplier(this.newSupplier).subscribe(
      {
        next: result => this.showMessage('This request was successfully.', 'success'),
        error: error => this.showMessage(error, 'error')
      }
    )
    this.closeModal();
    window.location.reload();
  }

  removeSupplier(companyCnpj: string, supplier_Cpf_Cnpj : string) {  
      const supplier: ICompanySupplier = {
        company_Cnpj: companyCnpj,
        cpfCnpj: supplier_Cpf_Cnpj,
        name: ''
      }; 
    this.companySupplierService.DeleteCompanySupplier(supplier).subscribe({
      next: result => this.showMessage('This request was successfully.', 'success'),
      error: error => this.showMessage(error, 'error')
    });
    window.location.reload();
  }

  openModal() {
    this.modalOpen = true;
    this.newSupplier = {};
  }

  closeModal() {
    this.modalOpen = false;
  }

 search() {
  this.companySupplierService.getCompanySupplier(this.searchTerm).subscribe(
       (result: ICompanySupplierReturn[]) => {
         this.suppliers = result;
       },
       error => {
         this.showMessage(error, 'error')
       }
     );
 }

 showMessage(text: string, type: 'error' | 'success' | 'info') {
    this.messageText = text;
    this.messageType = type;
  }
}
