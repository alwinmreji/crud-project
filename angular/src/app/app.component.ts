import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  
})



export class AppComponent {
  
  employeeObj = new employee();
  title = 'application';
  name:string="mani";
  checkoutForm: any;
  
  ngOnInit(){
    
    this.employeeObj.user
    this.employeeObj.dob
    this.employeeObj.emp_id 
    this.employeeObj.desig
    this.employeeObj.salary
    this.employeeObj.address
  }

  getValues(val: any)
  {
     console.warn(val)
  }

  resetForm(){
    this.employeeObj.user = '';
    this.employeeObj.dob = '';
    this.employeeObj.emp_id = '';
    this.employeeObj.desig = '';
    this.employeeObj.salary = '';
    this.employeeObj.address = '';
  }
}


class employee {
  user:any;
  emp_id:any;
  desig: any;
  dob: any;
  salary:any;
  address:any;
}