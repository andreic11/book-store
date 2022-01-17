import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { BooksPageComponent } from './components/books-page/books-page.component';
import { BookFormComponent } from './components/books-page/book-form/book-form.component';
import { UserFormComponent } from './components/register-user/user-form/user-form.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { LoginFormComponent } from './components/login/login-form/login-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    LoginComponent,
    BooksPageComponent,
    BookFormComponent,
    UserFormComponent,
    RegisterUserComponent,
    LoginFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
