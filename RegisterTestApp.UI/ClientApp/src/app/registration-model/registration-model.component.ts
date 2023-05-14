import { Component, Inject, OnInit } from '@angular/core';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-registration',
  templateUrl: './registration-model.component.html'
})
export class RegistrationModel implements OnInit {
    registrationModelComponent$!: Observable<RegistrationModelComponent>;
    
    constructor() { }

    ngOnInit() {
      //  model to show 
    }
}

class RegistrationModelComponent {
    firstName: string = '';
    lastName: string = '';
    email: string = '';
    dateOfBirth: string = '' ;
    phoneNumbers: string[] = [''];
  }
  