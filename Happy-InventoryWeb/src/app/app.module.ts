import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http'; 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { RadioButtonModule } from 'primeng/radiobutton'; 
import { CoreModule } from './core/core.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { PasswordModule } from 'primeng/password';
import { DialogModule } from 'primeng/dialog';
import { MenuComponent } from './core/menu/menu.component';




@NgModule({
  declarations: [
    AppComponent,
    MenuComponent
  ],
  imports: [
  
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    TableModule,
    HttpClientModule, 
    //FormsModule,
    CoreModule,
    ReactiveFormsModule,
    InputTextModule,
    RadioButtonModule,
    BrowserTransferStateModule,
    BrowserAnimationsModule,
    PasswordModule,
    DialogModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
