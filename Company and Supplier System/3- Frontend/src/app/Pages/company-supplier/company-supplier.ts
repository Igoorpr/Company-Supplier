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
  
  saveCompanySupplier() {
    this.companySupplierService.postCompanySupplier(this.newSupplier).subscribe({
      next: result => {
        this.showMessage(result, 'success');
        this.closeModal();

        setTimeout(() => {
          window.location.reload();
        }, 2000);
      },
      error: error => {
        this.showMessage(error, 'error')
      }
    });
  }

  removeCompanySupplier(companyCnpj: string, supplier_Cpf_Cnpj : string) {  
      const supplier: ICompanySupplier = {
        company_Cnpj: companyCnpj,
        cpfCnpj: supplier_Cpf_Cnpj,
        name: ''
      }; 
    this.companySupplierService.DeleteCompanySupplier(supplier).subscribe({
      next: result => this.showMessage(result, 'success'),
      error: error => this.showMessage(error, 'error')
    });
    setTimeout(() => {
      window.location.reload();
    }, 2000); 
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
         this.suppliers = []
         this.showMessage(error, 'error')
         setTimeout(() => {
            window.location.reload();
         }, 2000); 
       }
     );
    this.searchTerm = ''    
 }

 showMessage(text: string, type: 'error' | 'success' | 'info') {
    this.messageText = text;
    this.messageType = type;

    setTimeout(() => {
      this.messageText = '';
      this.messageType = '';
    }, 3000);
  }

  AddCompany() {
    this.router.navigateByUrl('/company')
  }

  AddSupplier() {
    this.router.navigateByUrl('/supplier')
  }
}
