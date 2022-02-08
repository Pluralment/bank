import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UserCreationComponent } from './user/user-creation/user-creation.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { UserListComponent } from './user/user-list/user-list.component';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'users', runGuardsAndResolvers: 'always', children: [
    { path: '', component: UserListComponent },
    { path: 'create', component: UserCreationComponent },
    { path: ':id/edit', component: UserEditComponent },
  ] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
