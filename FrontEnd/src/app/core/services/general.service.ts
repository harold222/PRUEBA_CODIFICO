import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  
  protected readonly base: string = environment.apiEndpoint;
  protected http = inject(HttpClient);

  constructor() { }
}
