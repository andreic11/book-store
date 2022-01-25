import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { CartComponent } from './cart.component';
import { AuthGuard } from '../guards/auth.guard';

const routes: Routes = [
    {
        path: '',
        component: CartComponent,
        canActivate: [AuthGuard]
    },
];

@NgModule({
    declarations: [
        CartComponent,
    ],
    imports: [
        FormsModule,
        ToastrModule.forRoot(),
        CommonModule,
        RouterModule.forChild(routes)],
    providers: [
    ],
})
export class CartModule { }
