import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { AdministrationComponent } from './administration.component';
import { AuthGuard } from '../guards/auth.guard';
import { RoleGuard } from '../guards/role.guard';

const routes: Routes = [
    {
        path: 'users',
        component: AdministrationComponent,
        canActivate: [AuthGuard, RoleGuard]
    },
];

@NgModule({
    declarations: [
        AdministrationComponent,
    ],
    imports: [
        FormsModule,
        ToastrModule.forRoot(),
        CommonModule,
        RouterModule.forChild(routes)],
    providers: [
    ],
})
export class AdministrationModule { }
