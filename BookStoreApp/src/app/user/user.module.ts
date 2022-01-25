import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './login/login.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { UserFormComponent } from './register-user/user-form/user-form.component';

const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register', component: RegisterUserComponent
    },
];

@NgModule({
    declarations: [
        LoginComponent,
        UserFormComponent,
        RegisterUserComponent
    ],
    imports: [
        FormsModule,
        ToastrModule.forRoot(),
        CommonModule,
        RouterModule.forChild(routes)],
    providers: [
    ],
})
export class UserModule { }
