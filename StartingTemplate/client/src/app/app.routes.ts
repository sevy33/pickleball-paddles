import { Routes } from '@angular/router';
import { HelloWorld } from './hello-world/hello-world';
import { PageOne } from './page-one/page-one';
import { App } from './app';

export const routes: Routes = [
    {
        path: '',
        component: HelloWorld
    },
    {
        path: 'page-one',
        component: PageOne,
        children: [
            {
                path: 'below',
                component: PageOne
            }
        ]
    },
    {
        path: '**',
        redirectTo: ''
    }
];
