import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CompanyService } from '../../Services/company.service';
import { ICompany } from '../../Interfaces/company.interface';
import { ICompanyKey } from '../../Interfaces/companyKey.interface';

@Component({
  selector: 'app-company',
  imports: [
    CommonModule,
    FormsModule, 
  ],
  templateUrl: './company.html',
  styleUrl: './company.scss'
})

@Injectable({providedIn: 'root'})

export class Company implements OnInit {
  public companyies: ICompany[] = [];
  modalOpen = false;
  modalOpenUpdate = false;
  searchTerm = '';
  newCompany: any = {};
  newCompanyUpdate: any = {};
  messageText: string = '';
  messageType: 'error' | 'success' | 'info' | '' = ''; 
  postalCodeValidated: boolean = false;

  constructor(
      private companyService: CompanyService,
      private readonly router: Router
    ){
  }

  ngOnInit(): void {
     this.companyService.getCompany('10402082079').subscribe(
       (result: ICompany[]) => {
         this.companyies = result;
       },
       error => {
         this.showMessage(error, 'error')
       }
     );
     this.postalCodeValidated = false;
  }
  
  saveCompany() {
    this.companyService.postCompany(this.newCompany).subscribe({
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

  openModalUpdate(companyCnpj: string, companyName: string, companyPostalCode: string, companyState: string) {
    this.newCompanyUpdate = {
      companyCnpj: companyCnpj,
      companyName: companyName,
      companyPostalCode: companyPostalCode,
      companyState: companyState
    };
    this.modalOpenUpdate = true;
  }

  UpdateCompany() {
    this.companyService.putCompany(this.newCompanyUpdate).subscribe({
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

  removeCompany(companyCnpj: string) {  
      const company: ICompanyKey = {
        companyCnpj: companyCnpj
      }; 
    this.companyService.DeleteCompany(company).subscribe({
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

  openModal() {
    this.modalOpen = true;
    this.newCompany = {};
  }

  closeModal() {
    this.modalOpen = false;
    this.modalOpenUpdate = false;
  }

 showMessage(text: string, type: 'error' | 'success' | 'info') {
    this.messageText = text;
    this.messageType = type;

    setTimeout(() => {
      this.messageText = '';
      this.messageType = '';
    }, 3000);
  }

  BackCompanySupplier() {
    this.router.navigateByUrl('/')
  }

  AddSupplier() {
    this.router.navigateByUrl('/supplier')
  }

 onPostalCodeChange(cep: string) {
    if (cep.length === 8 && !this.postalCodeValidated) {  
      this.postalCodeValidated = true;  
      this.searchCep(cep); 
    }
  }

  searchCep(cep: string) {        
    this.companyService.getCep(cep).subscribe({
      next: (result) => {
        console.log(result)
      },
      error: (error) => {
        this.showMessage('Cep is invalid.', 'error');
        this.newCompanyUpdate.supplierPostalCode = ''
        this.newCompany.supplierPostalCode = ''
        this.postalCodeValidated = false;
      }
    });
  }
}




