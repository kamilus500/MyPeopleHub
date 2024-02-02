import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PeopleComponent } from './components/people/people.component';
import { FriendshipComponent } from './components/friendship/friendship.component';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { AccountComponent } from './components/account/account.component';
import { AvatarModule } from 'primeng/avatar';
import { TokenService } from './services/token.service';
import { UserService } from './services/user.service';
import { FriendsService } from './services/friends.service';
import { AccountService } from './services/account.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FileUploadModule } from 'primeng/fileupload';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { TokenInterceptor } from './tokenInterceptor';
import { JwtDecryptionService } from './services/jwt-decryption.service';
import { AccountDataService } from './services/data-services/account-data.service';
import { CardModule } from 'primeng/card';

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent,
    NavbarComponent,
    PeopleComponent,
    FriendshipComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    MenubarModule,
    AvatarModule,
    FormsModule,
    PasswordModule,
    InputTextModule,
    ReactiveFormsModule,
    HttpClientModule,
    FileUploadModule,
    ToastModule,
    CardModule
  ],
  providers: [TokenService,
    JwtDecryptionService,
    UserService, 
    FriendsService, 
    AccountService,
    AccountDataService,
    MessageService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
