import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AssigneeComponent } from './assignee/assignee.component';
import { AssigneeTaskComponent } from './assigneetask/assigneetask.component';
import { TaskComponent } from './task/task.component';
import { StateComponent } from './state/state.component';
import { ReportComponent } from './report/report.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AssigneeComponent,
    AssigneeTaskComponent,
    TaskComponent,
    StateComponent,
    ReportComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'assignee', component: AssigneeComponent },
      { path: 'assigneetask', component: AssigneeTaskComponent },
      { path: 'task', component: TaskComponent },
      { path: 'state', component: StateComponent },
      { path: 'report', component: ReportComponent },
    
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
