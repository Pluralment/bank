import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ModeratorService } from 'src/app/_services/moderator.service';

@Component({
  selector: 'app-moderator-page',
  templateUrl: './moderator-page.component.html',
  styleUrls: ['./moderator-page.component.css']
})
export class ModeratorPageComponent implements OnInit {

  constructor(private moderatorService: ModeratorService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  closeBankDay() {
    this.moderatorService.closeBankDay().subscribe({
      next: () => {
        this.toastr.success("Банковский день закрыт");
      },
      error: (e) => {
        this.toastr.error("Произошла ошибка");
        console.log(e);
      }
    });
  }

}
