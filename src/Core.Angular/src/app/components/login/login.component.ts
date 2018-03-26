import { UserService } from './../../services/user.service';
import { SharedService } from './../../services/shared.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user = new User('', '', '', '');
  shared: SharedService;
  message: string;

  constructor(
    private userService: UserService,
    private router: Router
  ) {
    this.shared = SharedService.getInstance();
  }

  ngOnInit() {
  }

  login() {
    this.message = '';
    this.userService
      .login(this.user)
      .subscribe((userAuthentication: User) => {
        this.shared.user = userAuthentication;
        this.shared.showTemplate.emit(true)
        this.router.navigate(['/']);
      }, err => {
        this.shared.user = null;
        this.message = 'Erro';
        this.shared.showTemplate.emit(false);
      });
  }

}
