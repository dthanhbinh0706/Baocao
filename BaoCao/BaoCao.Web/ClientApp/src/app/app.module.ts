import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { MatSliderModule } from '@angular/material/slider';
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
import { DepartmentComponent } from './department/department.component';
import { AssigneeDepartmentComponent } from './assigneedepartment/assigneedepartment.component';
import { NgxEchartsModule } from 'ngx-echarts';
import { NgxMatDatetimePickerModule, NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import {
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatRippleModule
} from '@angular/material';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';



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
    DepartmentComponent ,
    AssigneeDepartmentComponent,
  ],
  
  imports: [
    
    MatSliderModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
      NgxMatTimepickerModule,
      NgxMatDatetimePickerModule,    // <----- this module will be deprecated in the future version.
    MatDatepickerModule,        // <----- import(must)
    MatNativeDateModule,      // <----- import for date formating adapted to more locales(optional)
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts')
    }), 
    BrowserAnimationsModule,
    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'assignee', component: AssigneeComponent },
      { path: 'assigneetask', component: AssigneeTaskComponent },
      { path: 'task', component: TaskComponent },
      { path: 'state', component: StateComponent },
      { path: 'report', component: ReportComponent },
      { path: 'department', component: DepartmentComponent },
      { path: 'assigneedepartment', component: AssigneeDepartmentComponent },
      

    
    ])
  ],
  exports: [
    
  ],
  providers: [MatDatepickerModule,
    MatNativeDateModule, 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
