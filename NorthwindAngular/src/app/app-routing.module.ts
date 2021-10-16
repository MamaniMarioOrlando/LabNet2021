import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormProductComponent } from './northwind/Componentes/form-product/form-product.component';

const routes: Routes = [
  {
    path : '',
    component : FormProductComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
