import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CreditContract } from 'src/app/models/creditContract';
import { CreditService } from 'src/app/_services/credit.service';

@Component({
  selector: 'app-client-credit-list',
  templateUrl: './client-credit-list.component.html',
  styleUrls: ['./client-credit-list.component.css']
})
export class ClientCreditListComponent implements OnInit {
  creditContracts: CreditContract[];
  @Input() clientId: number;

  constructor(private creditService: CreditService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadClientCredits();
  }

  loadClientCredits() {
    this.creditService.getCreditsByClientId(this.clientId).subscribe((credits: CreditContract[]) => {
      this.creditContracts = credits;
    });
  }
}
