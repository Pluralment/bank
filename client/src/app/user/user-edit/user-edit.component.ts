import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { City } from 'src/app/models/city';
import { Country } from 'src/app/models/country';
import { FamilyPosition } from 'src/app/models/familyPosition';
import { Invalidity } from 'src/app/models/invalidity';
import { User } from 'src/app/models/user';
import { CityService } from 'src/app/_services/city.service';
import { CountryService } from 'src/app/_services/country.service';
import { FamilyPositionService } from 'src/app/_services/family-position.service';
import { InvalidityService } from 'src/app/_services/invalidity.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  user: User;
  userForm: FormGroup;
  cities: City[];
  familyPositions: FamilyPosition[];
  countries: Country[];
  invalidities: Invalidity[];

  passportNumberPattern = new RegExp("^\\d{7}$");
  cellPhonePattern = new RegExp('^\\+375[1-9]{2}\\s?[1-9]\\d{2}-?\\d{2}-?\\d{2}$');
  homePhonePattern = new RegExp("^[1-9]\\d{2}-?\\d{2}-?\\d{2}$");
  identifyNumberPattern = new RegExp("^\\d{7}A\\d{3}PB\\d$");

  identifyNumberTip = "Структура: <7 цифр>A<номер последовательности><контрольная цифра>"
  cellPhoneTip = "Структура: +375<код оператора><номер телефона>"
  passportNumberTip = "Номер паспорта должен состоять из 7 цифр"

  constructor(private userService: UserService,
    private formBuilder: FormBuilder,
    private cityService: CityService,
    private familyPositionService: FamilyPositionService,
    private countryService: CountryService,
    private invalidityService: InvalidityService,
    private route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadCities();
    this.loadFamilyPositions();
    this.loadCountries();
    this.loadInvalidityTypes();
    this.loadUser();
  }

  loadUser() {
    this.userService.getUser(this.route.snapshot.paramMap.get('id')).subscribe((user: User) => {
      this.user = user;
      this.initForm();
    });
  }

  editUser() {
    let cityOfResidence = this.cities.find(city => city?.id == this.userForm.controls["cityOfResidence"].value);
    this.userForm.controls["cityOfResidence"].setValue(cityOfResidence);

    let livingCity = this.cities.find(city => city?.id == this.userForm.controls["livingCity"].value);
    this.userForm.controls["livingCity"].setValue(livingCity);

    let citizen = this.countries.find(citizen => citizen?.id == this.userForm.controls["citizen"].value);
    this.userForm.controls["citizen"].setValue(citizen);

    let familyPosition = this.familyPositions.find(familyPos => familyPos?.id == this.userForm.controls["familyPosition"].value);
    this.userForm.controls["familyPosition"].setValue(familyPosition);

    let invalidity = this.invalidities.find(invalid => invalid?.id == this.userForm.controls["invalidity"].value);
    this.userForm.controls["invalidity"].setValue(invalidity);

    this.userService.updateUser(this.userForm.value).subscribe({
      next: () => this.toastr.success("User is updated"),
      error: (e) => this.toastr.error(e)
    });
  }

  initForm() {
    this.userForm = this.formBuilder.group({
      id: [this.user.id],
      name: [this.user.name, [Validators.required]],
      surname: [this.user.surname, [Validators.required]],
      fatherName: [this.user.fatherName, [Validators.required]],
      dateOfBirth: [this.user.dateOfBirth, Validators.required],
      gender: [this.user.gender, Validators.required],
      passportSerial: [this.user.passportSerial, Validators.required],
      passportNumber: [this.user.passportNumber, [Validators.required, Validators.pattern(this.passportNumberPattern)]],
      issuedBy: [this.user.issuedBy, [Validators.required]],
      issuedDate: [this.user.issuedDate, Validators.required],
      identifyNumber: [this.user.identifyNumber, [Validators.required, Validators.pattern(this.identifyNumberPattern)]],
      cityOfResidence: [this.user.cityOfResidence?.id, [Validators.required]],
      addressOfResidence: [this.user.addressOfResidence, Validators.required],
      homePhone: [this.user.homePhone, Validators.pattern(this.homePhonePattern)],
      cellPhone: [this.user.cellPhone, Validators.pattern(this.cellPhonePattern)],
      email: [this.user.email, Validators.email],
      placeOfWork: [this.user.placeOfWork],
      position: [this.user.position],
      livingCity: [this.user.livingCity?.id, [Validators.required]],
      livingAddress: [this.user.livingAddress, [Validators.required]],
      familyPosition: [this.user.familyPosition?.id, [Validators.required]],
      citizen: [this.user.citizen?.id, [Validators.required]],
      invalidity: [this.user.invalidity?.id, [Validators.required]],
      retired: [this.user.retired, [Validators.required]],
      monthlyIncome: [this.user.monthlyIncome],
      military: [this.user.military],
    });
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

}
