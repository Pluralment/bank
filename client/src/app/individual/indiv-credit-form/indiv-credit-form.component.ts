import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreditContract } from 'src/app/models/creditContract';
import { CreditType } from 'src/app/models/creditType';
import { Currency } from 'src/app/models/currency';
import { User } from 'src/app/models/user';
import { CreditService } from 'src/app/_services/credit.service';
import { CurrencyService } from 'src/app/_services/currency.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-indiv-credit-form',
  templateUrl: './indiv-credit-form.component.html',
  styleUrls: ['./indiv-credit-form.component.css']
})
export class IndivCreditFormComponent implements OnInit {
  creditForm: FormGroup;
  creditTypes: CreditType[];
  currencies: Currency[];
  clients: User[];

  amountTip: string;

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private creditService: CreditService,
    private currencyService: CurrencyService) { }

  ngOnInit(): void {
    this.loadClients();
    this.loadCurrencies();
    this.loadCreditTypes();
    this.initForm();
  }

  initForm() {
    this.creditForm = this.formBuilder.group({
      number: ["", Validators.required],
      startDate: [, Validators.required],
      endDate: [, Validators.required],
      interest: [{value: 0, disabled: true}, Validators.required],
      amount: [, [Validators.required]],
      currency: [4, Validators.required],
      creditType: [, Validators.required],
      client: [, Validators.required]
    });
  }

  
  loadCurrencies() {
    this.currencyService.getCurrencies().subscribe((currencies: Currency[]) => {
      this.currencies = currencies;
    });
  }

  loadClients() {
    this.userService.getUsers().subscribe((clients: User[]) => {
      this.clients = clients;
    });
  }

  loadCreditTypes() {
    this.creditService.getCreditTypes().subscribe((creditTypes: CreditType[]) => {
      this.creditTypes = creditTypes;
    });
  }

  setAmountValidators() {
    if (this.creditForm.controls["creditType"].dirty) {
      let creditType: CreditType = this.creditTypes.find(creditType => creditType.id == this.creditForm.controls["creditType"].value);
      this.amountTip = "минимальная сумма: " + creditType.minContribution + ", максимальная сумма: " + creditType.maxContribution;

      this.creditForm.controls["amount"].setValidators([
        Validators.min(creditType.minContribution), 
        Validators.max(creditType.maxContribution)
      ]);

      this.setInterest(creditType.interest);
    }
  }

  setInterest(interest: number) {
    this.creditForm.controls["interest"].setValue(interest);
  }

  createCredit() {
    let creditType = this.creditTypes.find(type => type.id == this.creditForm.controls["creditType"].value);
    let currency = this.currencies.find(currency => currency.id == this.creditForm.controls["currency"].value);
    let client = this.clients.find(client => client.id == this.creditForm.controls["client"].value);

    let form = this.creditForm;

    let creditContract: Partial<CreditContract> = {
      number: form.controls["number"].value,
      startDate: form.controls["startDate"].value,
      endDate: form.controls["endDate"].value,
      currency: currency,
      isClosed: false,
      amount: form.controls["amount"].value,
      creditType: creditType,
      client: client
    };

    this.creditService.createCreditContract(creditContract).subscribe((createdCredit: CreditContract) => {
      console.log(createdCredit);
    });
  }

}
