import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreRoutingModule } from './core-routing.module';
import { ReactiveFormsModule, FormsModule, CheckboxControlValueAccessor } from '@angular/forms';
import { PanelMenuModule } from 'primeng/panelmenu';
import { UserComponent } from './user/user.component';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputTextModule } from 'primeng/inputtext';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { DropdownModule } from 'primeng/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { CheckboxModule } from 'primeng/checkbox'; 
import { PasswordModule } from 'primeng/password';
import { LoginComponent } from './login/login.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { WarehouseListComponent } from './warehouse-list/warehouse-list.component';
import { WarehouseItemComponent } from './warehouse-item/warehouse-item.component';
import { WarehouseItemListComponent } from './warehouse-item-list/warehouse-item-list.component';
import { DialogModule } from 'primeng/dialog';  
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { MenuComponent } from './menu/menu.component';
@NgModule({
  imports: [
     CommonModule,
     CoreRoutingModule,
    //FormsModule,
     PanelMenuModule,
     BrowserModule,
     AppRoutingModule,
     ButtonModule,
     TableModule,
     HttpClientModule, 
     FormsModule,
     ReactiveFormsModule,
     InputTextModule,
     RadioButtonModule,
     DropdownModule,
     BrowserAnimationsModule,
     PasswordModule,
     CheckboxModule,
     DialogModule,
     ToastModule
  ],
  declarations: [  UserComponent, LoginComponent,WarehouseComponent,WarehouseListComponent, WarehouseItemComponent, WarehouseItemListComponent],
  exports: [UserComponent,LoginComponent,WarehouseComponent,WarehouseListComponent,WarehouseItemComponent],
  providers: [MessageService],

})
export class CoreModule { }
