import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('src/app/books/books.module').then((m) => m.BooksModule),
  },
  {
    path: 'user',
    loadChildren: () =>
      import('src/app/user/user.module').then((m) => m.UserModule),
  },
  {
    path: 'administration',
    loadChildren: () =>
      import('src/app/administration/administration.module').then((m) => m.AdministrationModule),
  },
  {
    path: 'cart',
    loadChildren: () =>
      import('src/app/cart/cart.module').then((m) => m.CartModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
