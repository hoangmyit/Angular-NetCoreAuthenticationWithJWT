import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// layout
import { MainLayoutComponent } from '../components/shared/main-layout/main-layout.component';
import { PageNotFoundComponent } from '../components/shared/page-error/page-not-found/page-not-found.component';
import { UnauthorizedComponent } from '../components/shared/page-error/unauthorized/unauthorized.component';
// components
import { HomeComponent } from '../components/home/home.component';
import { LoginComponent } from '../components/user/login/login.component';
import { AdminComponent } from '../components/admin/admin.component';
import { ManagerComponent } from '../components/manager/manager.component';
import { AuthGuard } from '../components/user/auth/auth.guard';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    {
        path: '',
        component: MainLayoutComponent,
        children: [
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
            { path: 'manager', component: ManagerComponent, canActivate: [AuthGuard] },
        ]
    },
    { path: 'unauthorized', component: UnauthorizedComponent},
    { path: 'login', component: LoginComponent },
    { path: '**', component: PageNotFoundComponent }
 ];
@NgModule({
    declarations: [
        HomeComponent,
        LoginComponent,
        AdminComponent,
        ManagerComponent,
    ],
    imports: [
        RouterModule.forRoot(appRoutes,
            { enableTracing: true }
          ),
        RouterModule,
        CommonModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    exports: [
        HomeComponent,
        RouterModule,
        LoginComponent,
        AdminComponent,
        ManagerComponent,
    ],
})

export class AppRoutingModule {
}
