import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
declare var $: any;


@Component({
  selector: 'app-assignee',
  templateUrl: './assignee.component.html',
  styleUrls: ['./assignee.component.css']
})
export class AssigneeComponent implements OnInit {
  Assignees: any = {
    data: [],
    total_record: Number,
    page: Number,
    size: Number,
    total_page: Number,
  };

  Assignee:any = {
    assigneeId: Number,
    assigneeName: String,
    
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
    this.GetAllAssigneeWithPagination(1);
    // this.getuseradminbyid(id);
  }
  
  GetAllAssigneeWithPagination(cPage) {
    
    //Tạo mới 2 parameter, page và size.
    let params = new HttpParams().set("page",cPage).set("size", "10");
    //Gọi Get method truyền vào 2 parameter.
    //Trả về danh sách Product với page = 1 và size = 10.
    this.http.get("https://localhost:44380/api/Assignees", {params}).subscribe(
      result => {
        this.Assignees = result;
        this.Assignees = this.Assignees.data;
        console.log(this.Assignees);
      },error => console.error(error)
    );
}



Next()
{
  if(this.Assignees.page < this.Assignees.total_page)
  {
    let nextPage = this.Assignees.page + 1;
    let params = new HttpParams().set("page",nextPage).set("size", "10");
    this.http.get("https://localhost:44380/api/Assignees", {params}).subscribe(
        result => {
          this.Assignees = result;
          this.Assignees = this.Assignees.data;
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
  if(this.Assignees.page>1)
  {
    let PrePage = this.Assignees.page - 1;
    let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
    this.http.get("https://localhost:44380/api/Assignees", {params}).subscribe(
        result => {
          this.Assignees = result;
          this.Assignees = this.Assignees.data;
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
      this.Assignee = {
        assigneeId: "",
        assigneeName: "",
      };
    } else {
      this.isEdit = true;
      this.Assignee = index;
    }
    $('#exampleModal').modal("show");
  }

  openModalEdit(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.Assignee = {
        assigneeId: "",
        assigneeName: "",
      };
    } else {
      this.isEdit = true;
      this.Assignee = index;
    }
    $('#exampleModal1').modal("show");
  }

  
  addAssignee()
  {
    var x = {
      assigneeName: String(this.Assignee.assigneeName) ,
    };
    console.log(x);
    this.http.post("https://localhost:44380/api/Assignees", x).subscribe(
      result => {
        var res:any = result;
        if(res.success)
        {
          this.Assignee = res.data;
          window.location.reload();
        }
      },error => console.error(error)
    );
  }

 

  updateAssignee(Id) {
    //console.log(id);
    var x = {
      assigneeId: Number(this.Assignee.assigneeId),
      assigneeName: String(this.Assignee.assigneeName),
    };
    this.http.put("https://localhost:44380/api/Assignees/" + Id, x).subscribe(
      (result) => {
        var res: any = result;
        if (res.success) {
          this.Assignee = res.data;
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
  deleteAssignee(Id)
  {
    this.http.delete("https://localhost:44380/api/Assignees/" + Id).subscribe(
      result => {
        alert("Xóa thành công!");
        this.Assignee = result;
        this.deleteAssignee(Id);
        window.location.reload();
      },error => console.error(error)
    );
  }


}