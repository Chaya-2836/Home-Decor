import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CartService } from '../../Services/Cart.service';
import { Order } from '../../Classes/Order';
import { ProductOrderedPublic } from '../../Classes/ProductOrderedPublic';

@Component({
  selector: 'pay',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './pay.component.html',
  styleUrls: ['./pay.component.css']
})
export class PayComponent implements OnInit, AfterViewInit {

  theForm: FormGroup = new FormGroup({})

  constructor(private router: Router, public cs: CartService, private el: ElementRef) { }
  ngOnInit(): void {
    this.theForm = new FormGroup({
      email: new FormControl(null, [Validators.required, this.checkEmail.bind(this)]),
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      phone: new FormControl(null, [Validators.required, this.checkPhone.bind(this)])
    })
  }

  get GemailUser() {
    return this.theForm.controls['email']
  }
  get GfirstName() {
    return this.theForm.controls['firstName']
  }
  get GlastName() {
    return this.theForm.controls['lastName']
  }
  get Gphone() {
    return this.theForm.controls['phone']
  }

  checkEmail(e: AbstractControl) {
    if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/.test(e.value))
      return { 'invalidEmail': true }
    return null
  }
  checkPhone(e: AbstractControl) {
    if (!/^0?(([23489]{1}\d{7})|[5]{1}[012345689]\d{7})$/.test(e.value))
      return { 'invalidPhone': true }
    return null
  }

  save() {
    const toSend: Order =
      new Order(
        0,
        // new Date(),
        this.GfirstName.value,
        this.Gphone.value,
        this.GlastName.value,
        this.GemailUser.value,
        this.cs.cartItems.map(p=>new ProductOrderedPublic(p.id, p.product.product!.sku!, p.quantity))
      )

    console.log(toSend);

    this.cs.AddOrder(toSend).subscribe(oSucc => {
      console.log(oSucc);
      setTimeout(() => {
        this.router.navigate([''])
        this.cs.clearCart()
      }, 200)
    }, oFail => {
      console.log(oFail);
    })

  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      const yOffset = window.innerHeight * 0.33; // 23% מגובה המסך
      const y = this.el.nativeElement.getBoundingClientRect().top + window.scrollY - yOffset;
      window.scrollTo({ top: y, behavior: 'smooth' });
    });
  }

}
