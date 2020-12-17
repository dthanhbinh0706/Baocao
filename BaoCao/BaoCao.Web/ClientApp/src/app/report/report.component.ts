import { Component, OnInit, Inject,ViewChild,ElementRef } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
import { EChartOption, ECharts, EChartsResizeOption, EChartsSeriesType } from 'echarts';
import { ActivatedRoute } from "@angular/router";
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { JsonExporterService, TxtExporterService } from 'mat-table-exporter';
import { DataSource } from '@angular/cdk/table';
import { MatSort } from '@angular/material';
import * as xlsx from 'xlsx';

declare var $: any;

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  @ViewChild('epltable', { static: false }) epltable: ElementRef;
 
  Exs: any = [
  {
    assigneeId: Number,
    assigneeTaskId: Number,
    assigneeName: String,
    departmentName: String,
    taskName: String,
    schedule: Date
  }
 ];
  
  Temp: Number;
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
  Day: any =[];
 
  Dta: any = [];

  chartOption: EChartOption = {
    tooltip: {
      trigger: 'item',
      formatter: '{a} <br/>{b} : {c} ({d}%)'
  },
    series: [{
      data: [this.GetA()
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

option: EChartOption = {
    color: ['#C23531','#2F4554', '#61A0A8', '#E98F6F'],
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'shadow'
        }
    },
    legend: {
        data: ['ToDo', 'Processing', 'TimeOut', 'Completed']
    },
    toolbox: {
        show: true,
        orient: 'vertical',
        left: 'right',
        top: 'center',
        feature: {
            mark: {show: true},
            dataView: {show: true, readOnly: false},
            magicType: {show: true, type: ['line', 'bar', 'stack', 'tiled']},
            restore: {show: true},
            saveAsImage: {show: true}
        }
    },
    xAxis: [
        {
            type: 'category',
            axisTick: {show: false},
            data: [this.GetDay()]
        }
    ],
    yAxis: [
        {
            type: 'value'
        }
    ],
    series: [
        {
            name: 'ToDo',
            type: 'bar',
            barGap: 0,
            data: [this.getAssigneeByState(1)]
        },
        {
            name: 'Processing',
            type: 'bar',
            barGap: 0,
            data: [this.getAssigneeByState(2)]
        },
        {
            name: 'TimeOut',
            type: 'bar',
            barGap: 0,
            data: [this.getAssigneeByState(3)]
        },
        {
            name: 'Completed',
            type: 'bar',
            barGap: 0,
            data:  [this.getAssigneeByState(4)]
        }
    ]
};


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
    this.GetA();
    this.Exs = null;
    // this.getuseradminbyid(id);
  }
  exportToExcel() {
    const ws: xlsx.WorkSheet =   
    xlsx.utils.table_to_sheet(this.epltable.nativeElement);
    const wb: xlsx.WorkBook = xlsx.utils.book_new();
    xlsx.utils.book_append_sheet(wb, ws, 'Sheet1');
    xlsx.writeFile(wb, 'epltable.xlsx');
   }
  
  getAssigneeByState(id) {
    this.http
      .get("https://localhost:44380/api/Reports/getAssigneeByState/" + id)
      .subscribe(
        (result) => {
        this.Dta = result;
        this.Dta = this.Dta.data;
        this.option.series[id-1].data=this.Dta;
        console.log(this.option.series[id-1].data);
        }
      );
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
  GetEx() 
  {
    
      var id = this.Temp ;
    console.log(id);
    this.http.get("https://localhost:44380/api/Reports/GetEx?Id="+id).subscribe(
      (result) => {
        this.Exs = result;
        this.Exs = this.Exs.data;
        console.log(this.Exs);
      },error => console.error(error)
      
    );
    
    
  }
  
  GetDay() {
    this.http.get("https://localhost:44380/api/Reports/GetDistinctiveDate").subscribe(
      (result) => {
        this.Day = result;
        this.Day = this.Day.data;
        this.option.xAxis[0].data=this.Day;
        console.log(this.option.xAxis[0].data);
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

