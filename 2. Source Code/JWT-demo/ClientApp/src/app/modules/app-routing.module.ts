import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from '../components/home/home.component';
import { MainLayoutComponent } from '../components/shared/main-layout/main-layout.component';
import { PageNotFoundComponent } from '../components/shared/page-error/page-not-found/page-not-found.component';
import { LoginComponent } from '../components/user/login/login.component';
import { AdminComponent } from '../components/admin/admin.component';
import { ManagerComponent } from '../components/manager/manager.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    {
        path: '',
        component: MainLayoutComponent,
        children: [
            { path: 'home', component: HomeComponent },
            { path: 'admin', component: AdminComponent },
            { path: 'manager', component: ManagerComponent },
        ]
    },
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
