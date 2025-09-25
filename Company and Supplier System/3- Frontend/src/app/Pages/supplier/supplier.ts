import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ISupplier } from '../../Interfaces/supplier.interface';
import { SupplierService } from '../../Services/supplier.service';
import { ISupplierKey } from '../../Interfaces/supplierKey.interface';

@Component({
  selector: 'app-supplier',
  imports: [
    CommonModule,
    FormsModule, 
  ],
  templateUrl: './supplier.html',
  styleUrl: './supplier.scss'
})

@Injectable({providedIn: 'root'})

export class Supplier implements OnInit {
  public suppliers: ISupplier[] = [];
  modalOpen = false;
  modalOpenUpdate = false;
  searchTerm = '';
  newSupplier: any = {};
  newSupplierUpdate: any = {};
  messageText: string = '';
  messageType: 'error' | 'success' | 'info' | '' = ''; 

  constructor(
      private supplierService: SupplierService,
      private readonly router: Router
    ){
  }

  ngOnInit(): void {
     this.supplierService.getSupplier('10402082079').subscribe(
       (result: ISupplier[]) => {
         this.suppliers = result;
       },
       error => {
         this.showMessage(error, 'error')
       }
     );
  }
  
  saveSupplier() {
    this.supplierService.postSupplier(this.newSupplier).subscribe(
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

  openModalUpdate(supplierCpfCnpj: string, supplierName: string, supplierType: string, supplierEmail: string | null, supplierPostalCode: string, supplierRG: string | null, supplierBirthDate: Date | null) {
    this.newSupplierUpdate = {
      supplierCpfCnpj: supplierCpfCnpj,
      supplierName: supplierName,
      supplierType: supplierType,
      supplierEmail: supplierEmail,
      supplierPostalCode: supplierPostalCode,
      supplierRG: supplierRG,
      supplierBirthDate: supplierBirthDate
    };
    this.modalOpenUpdate = true;
  }

  UpdateSupplier() {
    this.supplierService.putSupplier(this.newSupplierUpdate).subscribe(
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

  removeSupplier(supplierCpfCnpj: string) {  
      const supplier: ISupplierKey = {
        supplierCpfCnpj: supplierCpfCnpj
      }; 
    this.supplierService.DeleteSupplier(supplier).subscribe({
      next: result => this.showMessage('This request was successfully.', 'success'),
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

  AddCompany() {
    this.router.navigateByUrl('/Company')
  }
}




