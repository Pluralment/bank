import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DepositContract } from 'src/app/models/depositContract';
import { DepositService } from 'src/app/_services/deposit.service';

@Component({
  selector: 'app-client-deposit-list',
  templateUrl: './client-deposit-list.component.html',
  styleUrls: ['./client-deposit-list.component.css']
})
export class ClientDepositListComponent implements OnInit {
  depositContracts: DepositContract[];
  @Input() clientId: number;

  constructor(private depositService: DepositService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadClientDeposits();
  }

  loadClientDeposits() {
    this.depositService.getDepositsByClientId(this.clientId).subscribe((deposits: DepositContract[]) => {
      this.depositContracts = deposits;
    });
  }

  closeDeposit(depositId: number) {
    this.depositService.closeDeposit(depositId).subscribe(() => {
      this.toastr.info("Deposit closed");
    });
  }

}
