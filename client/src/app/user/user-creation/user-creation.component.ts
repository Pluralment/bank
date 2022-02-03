import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-creation',
  templateUrl: './user-creation.component.html',
  styleUrls: ['./user-creation.component.css']
})
export class UserCreationComponent implements OnInit {
  userForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { 
  }

  initForm() {
    this.userForm = this.formBuilder.group({
      name: ["", [Validators.required]],
      surname: ["", [Validators.required]],
      patronymic: ["", [Validators.required]],
      birthDate: [Date, Validators.required],
      gender: ["", Validators.required],
      passportSerial: ["", Validators.required],
      passportNumber: ["", Validators.required],
      authority: ["", [Validators.required]],
      issueDate: [Date, Validators.required],
      idNumber: ["", Validators.required],
      birthplace: ["", [Validators.required]],
      city: ["", [Validators.required]],
      address: ["", Validators.required],
      homePhone: [""],
      handPhone: [""],
      email: ["", Validators.email],
      familyStatus: ["", [Validators.required]],
      citizenship: ["", [Validators.required]],
      disability: ["", [Validators.required]],
      pensioner: [false, [Validators.required]],
      income: [""],
      reservist: [false],
    });
  }

  ngOnInit(): void {
    this.initForm();
  }

  create() {

  }

}
