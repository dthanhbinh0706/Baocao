import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams} from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
import { Message } from "@angular/compiler/src/i18n/i18n_ast";
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { error } from "protractor";
declare var $: any;

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  Tasks: any = {
    data: [],
    total_record: Number,
    page: Number,
    size: Number,
    total_page: Number,
  };

  Task:any = {
    taskId: Number,
    taskName: String,
    
  }

  


  isEdit: boolean = true;
  refeshdata: any;

  constructor(
    private http: HttpClient, private router:Router,
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
    this.GetAllTaskWithPagination(1);
    // this.getuseradminbyid(id);
  }
 
  

  GetAllTaskWithPagination(cPage) {
    
    //Tạo mới 2 parameter, page và size.
    let params = new HttpParams().set("page",cPage).set("size", "10");
    //Gọi Get method truyền vào 2 parameter.
    //Trả về danh sách Product với page = 1 và size = 10.
    this.http.get("https://localhost:44380/api/Tasks", {params}).subscribe(
      result => {
        this.Tasks = result;
        this.Tasks = this.Tasks.data;
        console.log(this.Tasks);
      },error => console.error(error)
    );
}



Next()
{
  if(this.Tasks.page < this.Tasks.total_page)
  {
    let nextPage = this.Tasks.page + 1;
    let params = new HttpParams().set("page",nextPage).set("size", "10");
    this.http.get("https://localhost:44380/api/Tasks", {params}).subscribe(
        result => {
          this.Tasks = result;
          this.Tasks = this.Tasks.data;
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
  if(this.Tasks.page>1)
  {
    let PrePage = this.Tasks.page - 1;
    let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
    this.http.get("https://localhost:44380/api/Tasks", {params}).subscribe(
        result => {
          this.Tasks = result;
          this.Tasks = this.Tasks.data;
        },error => console.error(error)
      );
  }
  else
  {
    alert("Bạn đang ở trang đầu!");
  }
}

//Modal
  openModal(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.Task = {
        taskId: "",
        taskName: "",
      };
    } else {
      this.isEdit = true;
      this.Task = index;
    }
    $('#exampleModal').modal("show");
  }

  openModalEdit(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.Task = {
        taskId: "",
        taskName: "",
      };
    } else {
      this.isEdit = true;
      this.Task = index;
    }
    $('#exampleModal1').modal("show");
  }

  
  addTask()
  {
    var x = {
      taskId: Number(this.Task.taskId),
      taskName: String(this.Task.taskName) 
    };
    console.log(x);
    this.http.post("https://localhost:44380/api/Tasks", x).subscribe(
      result => {
        var res:any = result;
        if(res.success)
        {
          this.Task = res.data;
          window.location.reload();
          alert("Bạn đã thêm thành công !");
        }
      },error => console.error(error)
    )
  }

  

  updateTask(Id) {
    //console.log(id);
    var x = {
      taskId: Number(this.Task.taskId),
      taskName: String(this.Task.taskName),
    };
    this.http.put("https://localhost:44380/api/Tasks/" + Id, x).subscribe(
      (result) => {
        var res: any = result;
        if (res.success) {
          this.Task = res.data;
          window.location.reload();
          alert("Bạn đã cập nhật thành công !");
        }
      },
      (error) => {
        console.error(error);
        alert("Bạn cập nhật thất bại !");

      }
    );
  }
  deleteTask(Id)
  {
    this.http.delete("https://localhost:44380/api/Tasks/" + Id).subscribe(
      result => {
        alert("Xóa thành công!");
        this.Task = result;
        this.deleteTask(Id);
        window.location.reload();
      },error => console.error(error)
    );
  }


 
  


}


