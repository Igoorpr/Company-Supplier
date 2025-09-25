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
  searchTerm = '';
  newCompany: any = {};
  messageText: string = '';
  messageType: 'error' | 'success' | 'info' | '' = ''; 

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
  }
  
  saveCompany() {
    this.companyService.postCompany(this.newCompany).subscribe(
      {
        next: result => this.showMessage('This request was successfully.', 'success'),
        error: error => this.showMessage(error, 'error')
      }
    )
    this.closeModal();
    setTimeout(() => {
      window.location.reload();
    }, 2000); 
  }

  removeCompany(companyCnpj: string) {  
      const company: ICompanyKey = {
        companyCnpj: companyCnpj
      }; 
    this.companyService.DeleteCompany(company).subscribe({
      next: result => this.showMessage('This request was successfully.', 'success'),
      error: error => this.showMessage(error, 'error')
    });
    setTimeout(() => {
      window.location.reload();
    }, 2000); 
  }

  openModal() {
    this.modalOpen = true;
    this.newCompany = {};
  }

  closeModal() {
    this.modalOpen = false;
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
}




