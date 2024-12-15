import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { warehouse } from 'src/app/Models/models';
import { WarehouseService } from 'src/app/Services/warehouse.service';

@Component({
  selector: 'app-warehouse-list',
  templateUrl: './warehouse-list.component.html',
  styleUrls: ['./warehouse-list.component.css']
})
export class WarehouseListComponent {
  form!: FormGroup;
  warehouses :warehouse[]=[] ;
  @Input() Id! : number;
  constructor(
    private router: Router,
    private warehouseService: WarehouseService,
  ) {}
  

  ngOnInit(): void {
    this.GetAllWarehouse();
  }

 GetAllWarehouse() {
  debugger;
  this.warehouseService.GetAllwarehouse().subscribe(
    (res) => {
      if (res && res.status) {
        this.warehouses = res.data;
      }
    }
  )
 }
  addNewWarehouse() {
    this.router.navigate(['/Warehouse']);
  }
  
  viewWarehouseItems(warehouseId: number) {
    debugger;
    //this.router.navigate(['/ItemList']);
    localStorage.setItem('warehouseId', warehouseId.toString());
    this.router.navigate(['/ItemList']);




  }
}
