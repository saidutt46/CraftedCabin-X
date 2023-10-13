import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardComponent, CategoryManagementComponent, DashboardPanelComponent, InventoryManagementComponent,
  OrdersManagementComponent, ProductManagementComponent, QuickReportComponent, UserManagementComponent } from '@admin-components';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminNavigationComponent } from './admin-navigation/admin-navigation.component';
import { MaterialModule } from '../ui-ux/ui-ux.module';
import { FlexLayoutModule } from '@angular/flex-layout';



@NgModule({
  declarations: [
    AdminDashboardComponent,
    CategoryManagementComponent,
    InventoryManagementComponent,
    OrdersManagementComponent,
    ProductManagementComponent,
    UserManagementComponent,
    AdminNavigationComponent,
    QuickReportComponent,
    DashboardPanelComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MaterialModule,
    FlexLayoutModule
  ]
})
export class AdminModule { }
