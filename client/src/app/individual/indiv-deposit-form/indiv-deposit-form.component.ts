import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Currency } from 'src/app/models/currency';
import { DepositContract } from 'src/app/models/depositContract';
import { DepositType } from 'src/app/models/depositType';
import { User } from 'src/app/models/user';
import { CurrencyService } from 'src/app/_services/currency.service';
import { DepositService } from 'src/app/_services/deposit.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-indiv-deposit-form',
  templateUrl: './indiv-deposit-form.component.html',
  styleUrls: ['./indiv-deposit-form.component.css']
})
export class IndivDepositFormComponent implements OnInit {
  depositForm: FormGroup;
  depositTypes: DepositType[];
  currencies: Currency[];
  clients: User[];

  amountTip: string;

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private depositService: DepositService,
    private currencyService: CurrencyService) { }

  ngOnInit(): void {
    this.loadClients();
    this.loadDepositTypes();
    this.loadCurrencies();
    this.initForm();
  }

  initForm() {
    this.depositForm = this.formBuilder.group({
      number: ["", Validators.required],
      startDate: [, Validators.required],
      endDate: [, Validators.required],
      interest: [{value: 0, disabled: true}, Validators.required],
      amount: [, [Validators.required]],
      currency: [4, Validators.required],
      depositType: [, Validators.required],
      client: [, Validators.required]
    });
  }

  loadClients() {
    this.userService.getUsers().subscribe((clients: User[]) => {
      this.clients = clients;
    });
  }

  loadDepositTypes() {
    this.depositService.getDepositTypes().subscribe((depositTypes: DepositType[]) => {
      this.depositTypes = depositTypes;
    });
  }

  loadCurrencies() {
    this.currencyService.getCurrencies().subscribe((currencies: Currency[]) => {
      this.currencies = currencies;
    });
  }

  setAmountValidators() {
    if (this.depositForm.controls["depositType"].dirty) {
      let depositType: DepositType = this.depositTypes.find(depositType => depositType.id == this.depositForm.controls["depositType"].value);
      this.amountTip = "минимальная сумма: " + depositType.minContribution + ", максимальная сумма: " + depositType.maxContribution;

      this.depositForm.controls["amount"].setValidators([
        Validators.min(depositType.minContribution), 
        Validators.max(depositType.maxContribution)
      ]);

      this.setInterest(depositType.interest);
    }
  }

  setInterest(interest: number) {
    this.depositForm.controls["interest"].setValue(interest);
  }

  createDeposit() {
    let depositType = this.depositTypes.find(type => type.id == this.depositForm.controls["depositType"].value);
    let currency = this.currencies.find(currency => currency.id == this.depositForm.controls["currency"].value);
    let client = this.clients.find(client => client.id == this.depositForm.controls["client"].value);

    let form = this.depositForm;

    // Добавить start и end date
    let depositContract: Partial<DepositContract> = {
      number: form.controls["number"].value,
      //startDate: new  Date(Date.now()),
      startDate: form.controls["startDate"].value,
      //endDate: new Date(Date.now() + form.controls["duration"].value*(1000 * 60 * 60 * 24)),
      endDate: form.controls["endDate"].value,
      currency: currency,
      isClosed: false,
      amount: form.controls["amount"].value,
      depositType: depositType,
      client: client
    };

    /* this.depositService.createDepositContract(depositContract).subscribe((createdDeposit: DepositContract) => {
      console.log(createdDeposit);
    }); */
    console.log(depositContract);
  }
}
