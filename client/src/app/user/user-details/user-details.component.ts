import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DepositContract } from 'src/app/models/depositContract';
import { DepositService } from 'src/app/_services/deposit.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {
  depositContracts: DepositContract[];
  clientId = this.route.snapshot.params['id'];

  constructor(private route: ActivatedRoute,
    private depositService: DepositService) { }

  ngOnInit(): void {
  }

}
