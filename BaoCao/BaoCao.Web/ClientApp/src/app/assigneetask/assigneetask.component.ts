import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
declare var $: any;


@Component({
  selector: 'app-assigneetask',
  templateUrl: './assigneetask.component.html',
  styleUrls: ['./assigneetask.component.css']
})
export class AssigneeTaskComponent implements OnInit {
  AssigneeTasks: any = {
    data: [],
    total_record: Number,
    page: Number,
    size: Number,
    total_page: Number,
  };

  AssigneeTask:any = {
    assigneeTaskId: Number,
    assigneeId: Number,
    stateId: Number,
    taskId: Number,
    schedule: Date
    
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
    this.GetAllAssigneeTaskWithPagination(1);
    // this.getuseradminbyid(id);
  }
  
  GetAllAssigneeTaskWithPagination(cPage) {
    
    //Tạo mới 2 parameter, page và size.
    let params = new HttpParams().set("page",cPage).set("size", "10");
    //Gọi Get method truyền vào 2 parameter.
    //Trả về danh sách Product với page = 1 và size = 10.
    this.http.get("https://localhost:44380/api/AssigneeTasks/GetAll", {params}).subscribe(
      result => {
        this.AssigneeTasks = result;
        this.AssigneeTasks = this.AssigneeTasks.data;
        console.log(this.AssigneeTasks);
      },error => console.error(error)
    );
}



Next()
{
  if(this.AssigneeTasks.page < this.AssigneeTasks.total_page)
  {
    let nextPage = this.AssigneeTasks.page + 1;
    let params = new HttpParams().set("page",nextPage).set("size", "10");
    this.http.get("https://localhost:44380/api/AssigneeTasks/GetAll", {params}).subscribe(
        result => {
          this.AssigneeTasks = result;
          this.AssigneeTasks = this.AssigneeTasks.data;
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
  if(this.AssigneeTasks.page>1)
  {
    let PrePage = this.AssigneeTasks.page - 1;
    let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
    this.http.get("https://localhost:44380/api/AssigneeTasks/GetAll", {params}).subscribe(
        result => {
          this.AssigneeTasks = result;
          this.AssigneeTasks = this.AssigneeTasks.data;
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
      this.AssigneeTask = {
        assigneeTaskId: "",
        assigneeId: "",
        stateId:"",
        taskId: "",
        schedule: "",
      };
    } else {
      this.isEdit = true;
      this.AssigneeTask = index;
    }
    $('#exampleModal').modal("show");
  }

  openModalEdit(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.AssigneeTask = {
        assigneeTaskId: "",
        assigneeId: "",
        stateId:"",
        taskId: "",
        schedule: "",
      };
    } else {
      this.isEdit = true;
      this.AssigneeTask = index;
    }
    $('#exampleModal1').modal("show");
  }

  
  addAssigneeTask()
  {
    var x = {
      assigneeId: Number(this.AssigneeTask.assigneeId),
      stateId: Number(this.AssigneeTask.stateId),
      taskId: Number(this.AssigneeTask.taskId),
      schedule: String(this.AssigneeTask.schedule)
    };
    console.log(x);
    this.http.post("https://localhost:44380/api/AssigneeTasks", x).subscribe(
      result => {
        var res:any = result;
        if(res.success)
        {
          this.AssigneeTask = res.data;
          window.location.reload();
        }
      },error => console.error(error)
    );
  }

 

  updateAssigneeTask(Id) {
    //console.log(id);
    var x = {
      assigneeId: Number(this.AssigneeTask.assigneeId),
      stateId: Number(this.AssigneeTask.stateId),
      taskId: Number(this.AssigneeTask.taskId),
      schedule: String(this.AssigneeTask.schedule)
    };
    this.http.put("https://localhost:44380/api/AssigneeTasks/" + Id, x).subscribe(
      (result) => {
        var res: any = result;
        if (res.success) {
          this.AssigneeTask = res.data;
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
  deleteAssigneeTask(Id)
  {
    this.http.delete("https://localhost:44380/api/AssigneeTasks/" + Id).subscribe(
      result => {
        alert("Xóa thành công!");
        this.AssigneeTask = result;
        this.deleteAssigneeTask(Id);
        window.location.reload();
      },error => console.error(error)
    );
  }


}