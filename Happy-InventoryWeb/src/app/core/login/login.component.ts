import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Password } from 'primeng/password';
import { Login } from 'src/app/Models/models';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;  
  submitted = false;  
  errorMessage = ''; 
  loginElement: Login = new Login();

  constructor(private formBuilder: FormBuilder, 
    private loginService  :LoginService,
    private router: Router

  ) { }

  ngOnInit(): void {
    this.createloginForm();
  }
  createloginForm() {
   this.loginForm =this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],  
    password: [''], 
   })
  }

  onSubmit(): void {
    debugger;
    this.submitted = true;
    this.loginElement = new Login();
    let formValue = this.loginForm?.value;
    this.loginElement.email =formValue.email;
    this.loginElement.password = formValue.password
   

    this.loginService.Login(this.loginElement).subscribe(
    (res) => {
     if(res.token !=null){
      localStorage.setItem("token",res.token)
     }

      this.router.navigate(['/UserProfile']);
    }
    )
    console.log('Login successful', this.loginForm.value);

    // // Check if the login is successful and show the message
    // if (this.loginForm.value.email === 'user@example.com' && this.loginForm.value.password === 'password123') {
    //   alert('Login Successful');
    // } else {
    //   this.errorMessage = 'Invalid credentials. Please try again.';
    // }

     // Stop if the form is invalid
    // if (this.loginForm.invalid) {
    //   return;
    // }
  }

}
