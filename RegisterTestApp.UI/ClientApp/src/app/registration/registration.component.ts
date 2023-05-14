import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html'
})
export class Registration {
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  model = new RegistrationModel();
  save = () => {
    this.http.post<RegistrationModel>(this.baseUrl + 'register', this.model).subscribe(result => {
      console.log(result);
      this.router.navigate(['/model']);
    }, error => {
      let errorMessage = '';
      if (error.status == "400") {
        errorMessage = "You should be at least 18 years old to use this app"

      } else {
        errorMessage =  error.message
      }
      window.alert(errorMessage)});
  }
  addPhone = () => {
    this.model.phoneNumbers.push('');
  }
  removePhone = (index: number) => {
    this.model.phoneNumbers.splice(index, 1);
  }
  trackByIndex = (index: number, obj: any): any => index;
}

class RegistrationModel {
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  dateOfBirth: string = '' ;
  phoneNumbers: string[] = [''];
}
