import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalService } from '../../../_modal';

import { Product } from '../model/product';

import { ProductService } from '../service/product.service';
import { } from 'sweetalert2'

const swal = require('sweetalert2')

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html',
  styleUrls: ['./form-product.component.css']
})
export class FormProductComponent implements OnInit {

  public formProduct: FormGroup;
  public products!: Product[];
  modeSave: string = '';
  product!: Product;

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private modalService: ModalService) { }

  ngOnInit() {
    this.formProduct = this.formBuilder.group({
      nameProduct: ["", [Validators.required, Validators.maxLength(40)]],
      cantidadPorUnidad: ["", [Validators.required, Validators.maxLength(40)]]
    });

    this.obtenerProductos();
  }

  guardarProducto() {
    let product = new Product();
    product.nameProduct = this.formProduct.get("nameProduct").value;
    product.cantidadPorUnidad = this.formProduct.get("cantidadPorUnidad").value;

    this.productService.addProduct(product)
      .subscribe(
        (res: any) => {
          if (res != undefined && res != null) {
            this.obtenerProductos();
            this.closeModal(this.modeSave);
          }
          else {
            console.log('Se rompió todo.');
          }
        }
      );
  }

  modificarProducto() {
    this.product.nameProduct = this.formProduct.get("nameProduct").value;
    this.product.cantidadPorUnidad = this.formProduct.get("cantidadPorUnidad").value;

    this.productService.upDateProduct(this.product)
      .subscribe(
        (res: any) => {
          debugger
          if (res != undefined && res != null) {
            this.obtenerProductos();
            this.closeModal(this.modeSave);
          }
          else {
            console.log('Se rompió todo.');
          }
        }
      )
  }

  deleteProduct(id: number) {
    this.productService.deleteProduct(id)
      .subscribe(
        (res: any) => {
          if (res != undefined && res != null) {
            this.obtenerProductos();
            alert('El producto se eliminó satisfactoriamente.');
          }
          else {
            alert('Hubo un error al eliminar el producto.');
          }
        }
      );
  }

  obtenerProductos() {
    this.productService.getProduct()
      .subscribe(
        (res: Product[]) => {
          this.products = res;
        }
      );
  }

  cancelarFormulario() {
    this.formProduct.reset();
    console.log("selecciono cancelar");
  }

  get f() {
    return this.formProduct.controls;
  }

  //#region Modal
  openModal(id: string, product?: Product) {
    this.modalService.open(id);

    if (product != null || product != undefined) {
      this.product = product;
    }

    this.modeSave = id;
  }

  closeModal(id: string) {
    this.modalService.close(id);
    this.cancelarFormulario()
  }

  confirmDelete(product: any): void {
    debugger
    swal.fire({
      title: '¡Atención!',
      text: "¿Está seguro de eliminar a " + product.NameProduct + "?",
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '$boton-confirmar',
      cancelButtonColor: '$boton-cancelar',
      cancelButtonText: 'No',
      confirmButtonText: 'Sí',
      allowOutsideClick: false,
    }).then((result: any) => {
      if (result.value) {
        this.deleteProduct(product.Id);
      }
    })
  }
  //#endregion
}
