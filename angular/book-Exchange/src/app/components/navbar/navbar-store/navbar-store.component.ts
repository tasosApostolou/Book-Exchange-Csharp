import { Component, inject } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import{ MatIcon, MatIconModule } from'@angular/material/icon'
import { Router, RouterLink } from '@angular/router';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatBadge, MatBadgeModule } from '@angular/material/badge';
import { MatButtonToggle, MatButtonToggleGroup, MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatButton, MatIconButton } from '@angular/material/button';
import { AddBookComponent } from '../../add-book/add-book.component';
import { UpdateComponent } from '../../update/update.component';
import { ManageAccountComponent } from '../../manage-account/manage-account.component';

@Component({
  selector: 'app-navbar-store',
  standalone: true,
  imports: [UpdateComponent,ManageAccountComponent,
    MatIcon,RouterLink,AddBookComponent,MatIconModule,MatMenu,MatMenuTrigger,MatBadgeModule,MatBadge,MatButtonToggle,MatButtonToggleGroup,MatButtonToggleModule,MatIcon,MatIconButton,MatButton],
  templateUrl: './navbar-store.component.html',
  styleUrl: './navbar-store.component.css'
})
export class NavbarStoreComponent {
  router = inject(Router)
  userService = inject(UserService)
  user = this.userService.user

  logout(){
    this.userService.logoutUser();
  }
  
  }


