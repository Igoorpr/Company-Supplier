import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanySupplier } from './company-supplier';

describe('CompanySupplier', () => {
  let component: CompanySupplier;
  let fixture: ComponentFixture<CompanySupplier>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanySupplier]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanySupplier);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
