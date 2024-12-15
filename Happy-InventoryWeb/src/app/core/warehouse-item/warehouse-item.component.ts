import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { WarehouseItem } from 'src/app/Models/models';
import { WarehouseItemsService } from 'src/app/Services/warehouse_items.service';


@Component({
  selector: 'app-warehouse-item',
  templateUrl: './warehouse-item.component.html',
  styleUrls: ['./warehouse-item.component.css']
})
export class WarehouseItemComponent implements OnInit {
  itemForm!: FormGroup;
  warehouseItemElement: WarehouseItem = new WarehouseItem;
  @Input() Id! : number;
 
  @Output() closePopup: EventEmitter<any> = new EventEmitter();


  constructor(private fb: FormBuilder,
    private ItemsService :WarehouseItemsService,
     private router: Router,
     private Ms :MessageService
  ) {}

  ngOnInit(): void {
   this.createWrehouseItemForm();
  }


  createWrehouseItemForm(){
    this.itemForm = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('^(?!.*\\b\\1\\b).*')]], 
      skuCode: [''], 
      qty: [1, [Validators.required, Validators.min(1)]], 
      costPrice: ['', [Validators.required, Validators.pattern('^[0-9]*\\.?[0-9]+$')]], 
      msrpPrice: [''], 
      warehouse: [''] 
    });
  }
  onSubmit(): void {
    debugger;
    this.warehouseItemElement = new WarehouseItem();
    let formValue = this.itemForm?.value;
    this.warehouseItemElement.name=formValue.name;
    this.warehouseItemElement.SkuCode=formValue.skuCode;
    this.warehouseItemElement.Qty=formValue.qty
    this.warehouseItemElement.CostPrice= formValue.costPrice
    this.warehouseItemElement.MsrpPrice=formValue.msrpPrice;
    this.warehouseItemElement.WarehouseId=this.Id;
    this.warehouseItemElement.creationUser = "Admin";
    this.warehouseItemElement.creationDate = new Date();
   
     this.ItemsService.Add(this.warehouseItemElement).subscribe(
      (res) => {
        if (res.data != null ) {
          this.Ms.add({ severity: 'success', summary: 'Success', detail: 'Message sent successfully!' });
         // alert('Save Successfully');
          this.closePopup.emit()
        }
        else{
        }
      }
     )
  }
}