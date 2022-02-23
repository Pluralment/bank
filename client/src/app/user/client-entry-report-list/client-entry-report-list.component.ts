import { Component, OnInit } from '@angular/core';
import { EntryReport } from 'src/app/models/entryReport';
import { DepositService } from 'src/app/_services/deposit.service';

@Component({
  selector: 'app-client-entry-report-list',
  templateUrl: './client-entry-report-list.component.html',
  styleUrls: ['./client-entry-report-list.component.css']
})
export class ClientEntryReportListComponent implements OnInit {
  entryReports: EntryReport[];

  constructor(private depositService: DepositService) { }

  ngOnInit(): void {
    this.loadEntryReports();
  }

  loadEntryReports() {
    this.depositService.getEntryReports().subscribe((entries: EntryReport[]) => {
      this.entryReports = entries;
    });
  }

}
