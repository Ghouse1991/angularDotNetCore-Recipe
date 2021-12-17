import { AvatarModule } from 'ngx-avatar';
import { SidebarModule } from 'ng-sidebar';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgxSpinnerModule } from 'ngx-spinner';
import { UiSwitchModule } from 'ngx-ui-switch';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
  ],
  imports: [
    RouterModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule,
    NgxSpinnerModule,
    UiSwitchModule,
    FontAwesomeModule,
    SidebarModule,
    AvatarModule,
  ],
  exports: [
    RouterModule,
    ReactiveFormsModule,
    CommonModule,
    NgxSpinnerModule,
    UiSwitchModule,
    FontAwesomeModule,
    SidebarModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule {}
