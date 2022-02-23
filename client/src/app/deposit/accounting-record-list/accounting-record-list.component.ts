import { Component, OnInit } from '@angular/core';
import { AccountReport } from 'src/app/models/accountReport';
import { DepositService } from 'src/app/_services/deposit.service';

@Component({
  selector: 'app-accounting-record-list',
  templateUrl: './accounting-record-list.component.html',
  styleUrls: ['./accounting-record-list.component.css']
})
export class AccountingRecordListComponent implements OnInit {
  accountReports: AccountReport[];

  constructor(private depositService: DepositService) { }

  ngOnInit(): void {
    this.loadAccountReports();
  }

  loadAccountReports() {
    this.depositService.getAccountReports().subscribe((reports: AccountReport[]) => {
      this.accountReports = reports;
    });
  }

}
