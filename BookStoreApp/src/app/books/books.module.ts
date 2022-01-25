import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { BooksPageComponent } from './books-page/books-page.component';
import { BookFormComponent } from './book-form/book-form.component';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

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
];

@NgModule({
    declarations: [
        BooksPageComponent,
        BookFormComponent
    ],
    imports: [
        FormsModule,
        ToastrModule.forRoot(),
        CommonModule,
        RouterModule.forChild(routes)],
    providers: [
    ],
})
export class BooksModule { }
