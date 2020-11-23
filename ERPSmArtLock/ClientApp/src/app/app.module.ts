import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Helpers
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
// Components
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AdminComponent } from './admin/admin/admin.component';
import { CarrouselComponent } from './components/shared/carrousel/carrousel/carrousel.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './login/login/login.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { RegisterComponent } from './register/register/register.component';
import { SidebarComponent } from './components/shared/sidebar/sidebar/sidebar.component';

// Modules
import { BuildingModule } from './modules/buildings/building.module';
import { DevicesModule } from './modules/devices/devices.module';
import { OrdersModule } from './modules/sales/components/orders.module';
import { CrmModule } from './modules/crm/crm.module';


@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    SidebarComponent,
    CarrouselComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BuildingModule,
    OrdersModule,
    DevicesModule,
    CrmModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
