import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  model: any = {}
  toastr = inject(ToastrService);
  private accountService = inject(AccountService);
  cancelRegister = output<boolean>();

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: error => {
        this.toastr.error(error.error); 
        console.log(error);
      }
    });
  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}
