import { Injectable } from '@angular/core';
import { CreateOrderRequest, CreateOrderResponse, GetAllEmployeesResponse, GetAllProductsResponse, GetAllShippersResponse, GetOrdersResponse, NextOrderResponse } from '../../models/Sales.model';
import { zip } from 'rxjs';
import { GeneralService } from '../general.service';

@Injectable({
  providedIn: 'root'
})
export class SalesService extends GeneralService {

  nextOrders(filter = '') {
    return this.http.get<NextOrderResponse[]>(`${this.base}Order/NextOrder?filter=${filter}`);
  }

  getOrders(id: string) {
    return this.http.get<GetOrdersResponse[]>(`${this.base}Order/GetOrderByClient/${id}`);
  }

  getAllEmployees() {
    return this.http.get<GetAllEmployeesResponse[]>(`${this.base}Employees/GetEmployees`);
  }

  getAllShippers() {
    return this.http.get<GetAllShippersResponse[]>(`${this.base}Shippers/GetShippers`);
  }

  getAllProducts() {
    return this.http.get<GetAllProductsResponse[]>(`${this.base}Products/GetProducts`);
  }

  loadAllSelects() {
    return zip(
      this.getAllEmployees(),
      this.getAllShippers(),
      this.getAllProducts()
    )
  }

  createOrder(request: CreateOrderRequest) {
    return this.http.post<CreateOrderResponse>(`${this.base}Order/CreateOrder`, request);
  }
}
