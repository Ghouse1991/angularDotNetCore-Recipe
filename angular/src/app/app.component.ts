import { filter } from 'rxjs/operators';
import { Observable, Subscription } from 'rxjs';
import { Title } from '@angular/platform-browser';
import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnDestroy {
  private subscriptions: Subscription[] = [];
  public ngOnDestroy(): void {
    this.subscriptions.forEach(x => x.unsubscribe());
  }
}