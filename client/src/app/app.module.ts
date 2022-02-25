import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { ReactiveFormsModule }   from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { UserListComponent } from './user/user-list/user-list.component';
import { UserCreationComponent } from './user/user-creation/user-creation.component';
import { ToastrModule } from 'ngx-toastr';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { HomeComponent } from './home/home.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { IndivDepositFormComponent } from './individual/indiv-deposit-form/indiv-deposit-form.component';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { UserDetailsComponent } from './user/user-details/user-details.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { ClientDepositListComponent } from './user/client-deposit-list/client-deposit-list.component';
import { AccountingRecordListComponent } from './deposit/accounting-record-list/accounting-record-list.component';
import { ClientEntryReportListComponent } from './user/client-entry-report-list/client-entry-report-list.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ModeratorPageComponent } from './moderator/moderator-page/moderator-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    FooterComponent,
    UserListComponent,
    UserCreationComponent,
    TextInputComponent,
    UserEditComponent,
    HomeComponent,
    IndivDepositFormComponent,
    UserDetailsComponent,
    ClientDepositListComponent,
    AccountingRecordListComponent,
    ClientEntryReportListComponent,
    ModeratorPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    NgxSpinnerModule,
    AccordionModule.forRoot(),
    TabsModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
