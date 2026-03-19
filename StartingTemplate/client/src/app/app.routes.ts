import { Routes } from '@angular/router';
import { HelloWorld } from './hello-world/hello-world';
import { PageOne } from './page-one/page-one';
import { App } from './app';
import { Home } from './home/home';

export const routes: Routes = [
    {
        path: '',
        component: Home
    },
    {
        path: '**',
        redirectTo: ''
    }
];
