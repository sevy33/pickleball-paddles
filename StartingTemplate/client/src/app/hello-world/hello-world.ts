import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { ChildHelloWorld } from './child-hello-world/child-hello-world';

@Component({
  selector: 'app-hello-world',
  imports: [ChildHelloWorld],
  templateUrl: './hello-world.html',
  styleUrl: './hello-world.scss',
})
export class HelloWorld {
  private router = inject(Router);
  name = signal('Dad');

  changeName() {
    this.name.set('mom');
  }

  goToPageOne() { 
    this.router.navigate(['/page-one']);
  }

  changeNameFromChild(newName: string) {
    this.name.set(newName);
  }

}
