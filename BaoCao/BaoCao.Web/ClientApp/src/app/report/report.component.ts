import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";



@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  Reports: any = {
    data: [],
    total_record: Number,
  };

  isEdit: boolean = true;
  refeshdata: any;

  constructor(
    
  ) 
  {}
  

  ngOnInit() 
  {
    
  }
  








}