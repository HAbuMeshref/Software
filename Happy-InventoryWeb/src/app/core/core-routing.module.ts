import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { WarehouseListComponent } from './warehouse-list/warehouse-list.component';
import { WarehouseItemComponent } from './warehouse-item/warehouse-item.component';
import { WarehouseItemListComponent } from './warehouse-item-list/warehouse-item-list.component';
import { AuthGuard } from '../Guard/auth.guard';

const routes: Routes = [ 
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
 
  {
    path: 'login',
    component: LoginComponent,
    children: [
      { path: 'login', component: LoginComponent }
    ]
  },

  {
    path: 'UserProfile',
    component: UserComponent,
    children: [
      { path: 'UserProfile', component: UserComponent }
    ], canActivate: [AuthGuard]
  },

  {
    path: 'Warehouse',
    component: WarehouseComponent,
    children: [
      { path: 'Warehouse', component: WarehouseComponent }
    ], canActivate: [AuthGuard]
  },

  {
    path: 'WarehouseList',
    component: WarehouseListComponent,
    children: [
      { path: 'WarehouseList', component: WarehouseListComponent }
    ]
    , canActivate: [AuthGuard]
  },

  {
    path: 'WarehouseItem',
    component: WarehouseItemComponent,
    children: [
      { path: 'WarehouseItem', component: WarehouseItemComponent }
    ], canActivate: [AuthGuard]
  },

  {
    path: 'ItemList',
    component: WarehouseItemListComponent,
    children: [
      { path: 'ItemList', component: WarehouseItemListComponent }
    ], canActivate: [AuthGuard]
  },
  // {
  //   path: 'UserProfiles',
  //   component: UserComponent,
  //   children: [
  //     { path: 'UserProfile', component: UserComponent }
  //   ]
  // }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
