import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor() { }

  protected BaseUrl(): string {
      return "https://localhost:5113/api";
  }
}
