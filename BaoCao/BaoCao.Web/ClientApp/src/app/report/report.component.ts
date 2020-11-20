import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
import { EChartOption, ECharts, EChartsResizeOption, EChartsSeriesType } from 'echarts';
import { ActivatedRoute } from "@angular/router";
import { HttpHeaders} from '@angular/common/http';
import {Observable,of} from 'rxjs';
import { data } from "jquery";
import { report } from "process";
import { Subscription } from "rxjs";
declare var $: any;

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  Reports: any = {
    data: [],
    total_record: Number,
    page: Number,
    size: Number,
    total_page: Number,
  };

  Report:any = {
    stateId: Number ,
    total: Number
  }

  ReportStr:any = [{name: String , value: Number}]
    
  /*
  a = [
    {
      a:1,
      b:2,
    }
  ];
  b = a.map(x => {
    return {
      c: x.a,
      d: x.b,
    };
  });

  b = [];
  for (let i=0; i<a.length; i++) {
    b.push({
      name: a[i].stateId,
      d: a[i].b,
    });
  }
  
  */

  chartOption: EChartOption = {
    tooltip: {
      trigger: 'item',
      formatter: '{a} <br/>{b} : {c} ({d}%)'
  },
    series: [{
      data: [
        this.GetA()
    ],
      name: 'Status',
      type: 'pie',
      emphasis: {
        itemStyle: {
            shadowBlur: 10,
            shadowOffsetX: 0,
            shadowColor: 'rgba(0, 0, 0, 0.5)'
        }
    },
      areaStyle: {}
    }]
  }
  
  

  isEdit: boolean = true;
  refeshdata: any;

  constructor(
    private http: HttpClient, private router:Router, private _Activatedroute: ActivatedRoute,
    @Inject("BASE_URL") baseUrl: string
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
    this.refeshdata = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.router.navigated = false;
      }
    });
  }
  ngOnDestroy() {
    if (this.refeshdata) {
      this.refeshdata.unsubscribe();
    }
  }
  ngOnInit() 
  {
    this.GetAllReportWithPagination(1);
    // this.getuseradminbyid(id);
  }
  
  
  

  GetA() {
    this.http.get("https://localhost:44380/api/Reports/GetA").subscribe(
      (result) => {
        this.ReportStr = result;
        this.ReportStr = this.ReportStr.data;
        this.chartOption.series[0].data=this.ReportStr;
        console.log(this.chartOption.series[0].data);
      }
      
    );
  }
  

  GetAllReportWithPagination(cPage) {
    
    //Tạo mới 2 parameter, page và size.
    let params = new HttpParams().set("page",cPage).set("size", "10");
    //Gọi Get method truyền vào 2 parameter.
    //Trả về danh sách Product với page = 1 và size = 10.
    this.http.get("https://localhost:44380/api/Reports", {params}).subscribe(
      result => {
        this.Reports = result;
        this.Reports = this.Reports.data;
        console.log(this.Reports);
      },error => console.error(error)
    );
}

Next()
{
  if(this.Reports.page < this.Reports.total_page)
  {
    let nextPage = this.Reports.page + 1;
    let params = new HttpParams().set("page",nextPage).set("size", "10");
    this.http.get("https://localhost:44380/api/Reports", {params}).subscribe(
        result => {
          this.Reports = result;
          this.Reports = this.Reports.data;
        },error => console.error(error)
      );
  }
    else
    {
      alert("Bạn đang ở trang cuối!");
    }
}

Previous()
{
  if(this.Reports.page>1)
  {
    let PrePage = this.Reports.page - 1;
    let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
    this.http.get("https://localhost:44380/api/Reports", {params}).subscribe(
        result => {
          this.Reports = result;
          this.Reports = this.Reports.data;
        },error => console.error(error)
      );
  }
  else
  {
    alert("Bạn đang ở trang đầu!");
  }
}

  
}
