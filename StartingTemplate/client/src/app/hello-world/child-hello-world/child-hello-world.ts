import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-child-hello-world',
  imports: [],
  templateUrl: './child-hello-world.html',
  styleUrl: './child-hello-world.scss',
})
export class ChildHelloWorld {
  parent = input.required<string>();
  changeParent = output<string>();
  childName = 'Bobbly'

  changeParentName() {
    this.changeParent.emit('I dont want parents');
  }
}
