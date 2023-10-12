import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  // Define your animation in the component's metadata
  animations: [
    trigger('reveal', [
      state('initial', style({ width: '100%' })),
      state('final', style({ width: '50%' })),
      transition('initial => final', animate('1s ease-in-out'))
    ])
  ]
})
export class HomeComponent implements OnInit {
  revealState: string = 'initial';

  ngOnInit() {
    // Set up a trigger for the animation
    // setTimeout(() => {
    //   this.revealState = 'final';
    // }, 0);
  }

  userRegister() {
  }
  userLogin() {

  }

}
