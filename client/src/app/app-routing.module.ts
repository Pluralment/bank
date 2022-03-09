import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { IndivCreditFormComponent } from './individual/indiv-credit-form/indiv-credit-form.component';
import { IndivDepositFormComponent } from './individual/indiv-deposit-form/indiv-deposit-form.component';
import { ModeratorPageComponent } from './moderator/moderator-page/moderator-page.component';
import { UserCreationComponent } from './user/user-creation/user-creation.component';
import { UserDetailsComponent } from './user/user-details/user-details.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserListComponent } from './user/user-list/user-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'users', runGuardsAndResolvers: 'always', children: [
    { path: '', component: UserListComponent },
    { path: 'create', component: UserCreationComponent },
    { path: ':id/edit', component: UserEditComponent },
    { path: ':id', component: UserDetailsComponent },
  ] },
  { path: 'individual', runGuardsAndResolvers: 'always', children: [
    { path: 'deposit', component: IndivDepositFormComponent },
    { path: 'credit', component: IndivCreditFormComponent },
  ] },
  { path: 'moderator', runGuardsAndResolvers: 'always', children: [
    { path: '', component: ModeratorPageComponent },
  ] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
