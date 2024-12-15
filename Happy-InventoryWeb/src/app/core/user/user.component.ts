import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { apiType, CommonRequest, GetAllMakesModel, LookupValue, User } from 'src/app/Models/models';
import { CoreServiceService } from 'src/app/Services/core-service.service';
import { SharedService } from 'src/app/Services/shared.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  AddUserForm!: FormGroup;
  userElement: User = new User();
  roles!: any[];  

  ngOnInit(): void {
  this.createUserForm();
  this.Getroles();
  }
  constructor(
    private CoreService: CoreServiceService,
    private sharedService: SharedService,
    private router: Router,
       
  ) {}

  createUserForm() {
    debugger;
    this.AddUserForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      name: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required]),
      confirmPassword: new FormControl("", [Validators.required]),
      active: new FormControl("", [Validators.required]),
      role: new FormControl("", [Validators.required]),
      id: new FormControl("")
    })
  }
  onSubmit() {
    debugger
     this.userElement = new User();
     let formValue = this.AddUserForm?.value;
     this.userElement.name = formValue.name;
     this.userElement.email = formValue.email;
     this.userElement.password =formValue.password;
     this.userElement.confirmPassword = formValue.confirmPassword;
     this.userElement.creationDate = new Date();
     this.userElement.role=formValue.role.value;
     this.userElement.active =formValue.active;
     this.userElement.creationUser = "System";
    this.CoreService.AddUser(this.userElement).subscribe(
      (res) => {
       debugger;
        if (res.data != null ) {
          alert('Save Successfully');
          this.router.navigate(['/WarehouseList']);
        }
        else{
        }
      },
    );
  }

  
  Getroles(){
      debugger;
       this.sharedService.GetAllLookupDetails(LookupValue.Rules).subscribe(
      (res) => {
        this.roles =res.data
      }
       )
    }
 

}
