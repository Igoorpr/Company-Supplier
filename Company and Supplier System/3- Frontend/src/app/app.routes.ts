import { Routes } from '@angular/router';
import { CompanySupplier } from './Pages/company-supplier/company-supplier';
import { Company } from './Pages/company/company';
import { Supplier } from './Pages/supplier/supplier';

export const routes: Routes = [
    { path: '', pathMatch: 'full', component: CompanySupplier },
    { path: 'company', component: Company },
    { path: 'supplier', component: Supplier },
];
