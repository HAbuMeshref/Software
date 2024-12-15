import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {  LookupValue, warehouse } from 'src/app/Models/models';
import { SharedService } from 'src/app/Services/shared.service';
import { WarehouseService } from 'src/app/Services/warehouse.service';

@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.css']
})
export class WarehouseComponent implements OnInit {
  warehouseForm!: FormGroup;
  countries!: any[];  // For the country dropdown
  submitted = false;
  warehouseElement: warehouse = new warehouse;
  
  constructor(private fb: FormBuilder,
     private warehouseService: WarehouseService,
     private router: Router,
     private sharedService: SharedService
  ) { 
  
  }

  ngOnInit(): void {
    this.GetCountries();
    this.createWrehouseForm();
    
  }

  // this.countries = [
  //   { label: 'United States', value: 'US' },
  //   { label: 'Canada', value: 'CA' },
  //   { label: 'United Kingdom', value: 'UK' },
  //   { label: 'Australia', value: 'AU' }
  // ];

  GetCountries(){
    debugger;
     this.sharedService.GetAllLookupDetails(LookupValue.country).subscribe(
    (res) => {
      this.countries =res.data
    }
     )
  }

  createWrehouseForm(){
    this.warehouseForm = this.fb.group({
      name: ['', [Validators.required]], 
      address: ['', [Validators.required]], 
      city: ['', [Validators.required]], 
      countryCode: ['', [Validators.required]] 
    });
  }
  onSubmit() {
    debugger;
    this.submitted = true;
    this.warehouseElement = new warehouse();
    let formValue = this.warehouseForm?.value;
    this.warehouseElement.name =formValue.name;
    this.warehouseElement.address=formValue.address;
    this.warehouseElement.city =formValue.city;
    this.warehouseElement.countryCode  =formValue.countryCode;
    this.warehouseElement.creationUser = "System";
    this.warehouseElement.creationDate = new Date();

    this.warehouseService.Add(this.warehouseElement).subscribe(
      (res) => {
        if (res != null ) {
          alert('Save Successfully');
          this.router.navigate(['/WarehouseList']);
        }
        else{
        }
      }
    )
  }
}
