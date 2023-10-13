import { RouterModule, Routes } from "@angular/router";
import { AdminDashboardComponent, CategoryManagementComponent, InventoryManagementComponent,
  OrdersManagementComponent, ProductManagementComponent, UserManagementComponent } from "@admin-components";
import { NgModule } from "@angular/core";


const routes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    children: [
      { path: 'users', component: UserManagementComponent },
      { path: 'products', component: ProductManagementComponent },
      { path: 'categories', component: CategoryManagementComponent },
      { path: 'inventory', component: InventoryManagementComponent },
      { path: 'orders', component: OrdersManagementComponent },
      { path: '', redirectTo: '', pathMatch: 'full' } // Default route
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }