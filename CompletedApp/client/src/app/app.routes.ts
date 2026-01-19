import { Routes } from '@angular/router';
import { PaddleListComponent } from './paddle-list/paddle-list.component';
import { PaddleDetailComponent } from './paddle-detail/paddle-detail.component';

export const routes: Routes = [
    { path: '', redirectTo: 'paddles', pathMatch: 'full' },
    { path: 'paddles', component: PaddleListComponent },
    { path: 'paddles/:id', component: PaddleDetailComponent }
];
