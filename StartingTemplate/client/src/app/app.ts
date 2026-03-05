import { Component, inject, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HelloWorld } from './hello-world/hello-world';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HelloWorld],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('client');
  private router = inject(Router);

  goToHelloWorld() {
    this.router.navigate(['/hello-world']);
  }
}
