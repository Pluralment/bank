import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { City } from 'src/app/models/city';
import { Country } from 'src/app/models/country';
import { FamilyPosition } from 'src/app/models/familyPosition';
import { Invalidity } from 'src/app/models/invalidity';
import { CityService } from 'src/app/_services/city.service';
import { CountryService } from 'src/app/_services/country.service';
import { FamilyPositionService } from 'src/app/_services/family-position.service';
import { InvalidityService } from 'src/app/_services/invalidity.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user-creation',
  templateUrl: './user-creation.component.html',
  styleUrls: ['./user-creation.component.css']
})
export class UserCreationComponent implements OnInit {
  userForm: FormGroup;
  cities: City[];
  familyPositions: FamilyPosition[];
  countries: Country[];
  invalidities: Invalidity[];

  passportNumberPattern = new RegExp("^[0-9]{7}");
  cellPhonePattern = new RegExp("^\\+375[1-9]{2}\s?[1-9]\d{2}-?\d{2}-?\d{2}");
  homePhonePattern = new RegExp("^[1-9]\d{2}-?\d{2}-?\d{2}");
  identifyNumberPattern = new RegExp("^[1-6][0-3]\d[0-1][1-9]\d{2}[ABCHKEM]\d{3}(PB|BA|BI)\d");

  constructor(private userService: UserService,
    private formBuilder: FormBuilder, 
    private cityService: CityService,
    private familyPositionService: FamilyPositionService,
    private countryService: CountryService,
    private invalidityService: InvalidityService) { 
  }

  initForm() {
    this.userForm = this.formBuilder.group({
      name: ["", [Validators.required]],
      surname: ["", [Validators.required]],
      fatherName: ["", [Validators.required]],
      dateOfBirth: [Date, Validators.required],
      gender: [false, Validators.required],
      passportSerial: ["", Validators.required],
      passportNumber: ["", [Validators.required, Validators.pattern(this.passportNumberPattern)]],
      issuedBy: ["", [Validators.required]],
      issuedDate: [Date, Validators.required],
      identifyNumber: ["", [Validators.required, Validators.pattern(this.identifyNumberPattern)]],
      cityOfResidence: ["", [Validators.required]],
      addressOfResidence: ["", Validators.required],
      homePhone: ["", Validators.pattern(this.homePhonePattern)],
      cellPhone: ["", Validators.pattern(this.cellPhonePattern)],
      email: ["", Validators.email],
      placeOfWork: [""],
      position: [""],
      livingCity: ["", [Validators.required]],
      livingAddress: ["", [Validators.required]],
      familyPosition: ["", [Validators.required]],
      citizen: ["", [Validators.required]],
      invalidity: ["", [Validators.required]],
      retired: [false, [Validators.required]],
      monthlyIncome: [""],
      military: [false],
    });
  }

  ngOnInit(): void {
    this.initForm();
    this.loadCities();
    this.loadFamilyPositions();
    this.loadCountries();
    this.loadInvalidityTypes();
  }

  loadCities() {
    this.cityService.getCities().subscribe((cities: City[]) => {
      this.cities = cities;
    });
  }

  loadCountries() {
    this.countryService.getCountries().subscribe((countries: Country[]) => {
      this.countries = countries;
    });
  }

  loadFamilyPositions() {
    this.familyPositionService.getFamilyPositions().subscribe((positions: FamilyPosition[]) => {
      this.familyPositions = positions;
    });
  }

  loadInvalidityTypes() {
    this.invalidityService.getInvalidityTypes().subscribe((invalidities: Invalidity[]) => {
      this.invalidities = invalidities;
    });
  }

  createClient() {
    //console.log(this.userForm);
    this.userService.createUser(this.userForm.value).subscribe((data) => {
      console.log(data);
    });
  }

}
