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
import { BothComponent } from '../components/both/both.component';
import { AuthGuard } from '../components/user/auth/auth.guard';
import { NoAuthGuard } from '../components/user/auth/no-auth.guard';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    {
        path: '',
        component: MainLayoutComponent,
        children: [
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'admin', component: AdminComponent, canActivate: [AuthGuard], data: {'roles': ['Admin']} },
            { path: 'manager', component: ManagerComponent, canActivate: [AuthGuard], data: {'roles': ['Manager']} },
            { path: 'both', component: BothComponent, canActivate: [AuthGuard], data: {'roles': ['Admin', 'Manager']} },
        ]
    },
    { path: 'unauthorized', component: UnauthorizedComponent, canActivate: [AuthGuard]},
    { path: 'login', component: LoginComponent, canActivate: [NoAuthGuard]},
    { path: '**', component: PageNotFoundComponent }
 ];
@NgModule({
    declarations: [
        HomeComponent,
        LoginComponent,
        AdminComponent,
        ManagerComponent,
        BothComponent,
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
        BothComponent,
    ],
})

export class AppRoutingModule {
}
