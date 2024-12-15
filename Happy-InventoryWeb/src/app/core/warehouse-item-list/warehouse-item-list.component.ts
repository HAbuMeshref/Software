import { Component, OnChanges, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LazyLoadEvent } from 'primeng/api';
import { warehouse, WarehouseItem } from 'src/app/Models/models';
import { WarehouseService } from 'src/app/Services/warehouse.service';
import { WarehouseItemsService } from 'src/app/Services/warehouse_items.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-warehouse-item-list',
  templateUrl: './warehouse-item-list.component.html',
  styleUrls: ['./warehouse-item-list.component.css']
})
export class WarehouseItemListComponent implements OnInit  {
   showPopup: boolean = false;
   form!: FormGroup;
   ItemList :WarehouseItem[]=[] ;
   selectedId! :number;
   lazyLoading: boolean = false;
   totalRecords!: number;
   gridPageSize: number = environment.pageSize;

   constructor(
     private router: Router,
     private ItemsService: WarehouseItemsService,
     private route: ActivatedRoute
   ) {}
   
 
   ngOnInit(): void {
    debugger
     this.GetAllWarehouseItem();
     
   }
  GetAllWarehouseItem() {
   debugger;
    var id = localStorage.getItem("warehouseId")?.toString();
   this.ItemsService.GetItemByWarehouseID(id).subscribe(
     (res) => {
       if (res && res.status) {
         this.ItemList = res.data;
         this.totalRecords =res.totalRecords;
         this.lazyLoading = false;
       }
     }
   )
  }
   addNewWarehouse() {
     this.router.navigate(['/Warehouse']);
   }
   viewWarehouseItems(warehouseId: number) {
    debugger;
    this.openPopup();
    this.selectedId= warehouseId;
   }

   openPopup(): void {
    this.showPopup = true;
  }

   closePopup(): void {
    this.showPopup = false;
    this.GetAllWarehouseItem();
  }
  onLazyLoad(event: LazyLoadEvent) {
    const firstValue = event?.first ?? 0;
    const rows = event?.rows ?? 10;
    setTimeout(() => {

      var pageIndex = event.first == 0 ? event.first + 1 : ((firstValue) / (rows)) + 1
        var sortOrder = event.sortOrder
        this.GetAllWarehouseItem();
     
    }, 0);
  }

  //not used 
  loadItems(event: LazyLoadEvent) {
    debugger;
    const first = event.first ?? 0; 
    const rows = event.rows ?? 10;   
    this.GetAllWarehouseItem();
  }
}
