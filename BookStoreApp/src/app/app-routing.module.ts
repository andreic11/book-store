import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookFormComponent } from './components/book-form/book-form.component';
import { BooksPageComponent } from './components/books-page/books-page.component';
import { CartComponent } from './components/cart/cart.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { UsersPageComponent } from './components/users-page/users-page.component';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'books',
    pathMatch: 'full'
  },
  {
    path: 'home',
    redirectTo: 'books',
    pathMatch: 'full'
  },
  {
    path: 'books', 
    component: BooksPageComponent
  },
  {
    path: 'book/create',
    component: BookFormComponent
  },
  {
    path: 'book/:id',
    component: BookFormComponent
  },
  {
    path: 'login', 
    component: LoginComponent
  },
  {
    path: 'users',
    component: UsersPageComponent,
    canActivate:[AuthGuard, RoleGuard]
  },
  {
    path: 'cart',
    component: CartComponent,
    canActivate:[AuthGuard]
  },
  {
    path: 'users/register', component: RegisterUserComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
