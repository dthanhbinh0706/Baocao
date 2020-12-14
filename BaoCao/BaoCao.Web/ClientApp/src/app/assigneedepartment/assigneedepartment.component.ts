import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
declare var $: any;
@Component({
  selector: 'app-assigneedepartment',
  templateUrl: './assigneedepartment.component.html',
  styleUrls: ['./assigneedepartment.component.css']
})
export class AssigneeDepartmentComponent implements OnInit {
  

  AssigneeDepartments: any = {
    data: [],
    total_record: Number,
    page: Number,
    size: Number,
    total_page: Number,
  };


  Departments: any ={
    data: []
  }
  Department:any={
    departmentId: Number,
    departmentName:String
  }
  Assignees: any ={
    data: []
  }
  Assignee:any={
    assigneeId: Number,
    AssigneeName:String
  }
 

  

  AssigneeDepartment:any = {
    assigneeDepartmentId: Number,
    assigneeId: Number,
    departmentId: Number
    
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

  events: string[] = [];


  ngOnDestroy() {
    if (this.refeshdata) {
      this.refeshdata.unsubscribe();
    }
  }
  ngOnInit() 
  {
    this.GetAllAssigneeDepartmentWithPagination(1);
    this.GetAllDepartments();
    this.GetAllAssignees();
    // this.getuseradminbyid(id);
  }
  
  GetAllDepartments() {
    this.http.get("https://localhost:44380/api/AssigneeDepartments/GetAllDepartments").subscribe(
      result => {
        this.Departments = result;
        this.Departments = this.Departments.data;
        console.log(this.Departments);
      },error => console.error(error)
    );
}

GetAllAssignees() {
  this.http.get("https://localhost:44380/api/AssigneeDepartments/GetAllAssignees").subscribe(
    result => {
      this.Assignees = result;
      this.Assignees = this.Assignees.data;
      console.log(this.Assignees);
    },error => console.error(error)
  );
}

selectedOptionAI: any; 
  public onValueChangedAI(selected: any): void {
    this.selectedOptionAI = selected;
    //console.log(this.selectedOption); // should display the selected option.
  }
  selectedOptionSI: any; 
  public onValueChangedSI(selected: any): void {
    this.selectedOptionSI = selected;
    //console.log(this.selectedOption); // should display the selected option.
  }
  




  GetAllAssigneeDepartmentWithPagination(cPage) {
    
    //Tạo mới 2 parameter, page và size.
    let params = new HttpParams().set("page",cPage).set("size", "10");
    //Gọi Get method truyền vào 2 parameter.
    //Trả về danh sách Product với page = 1 và size = 10.
    this.http.get("https://localhost:44380/api/AssigneeDepartments/GetAll", {params}).subscribe(
      result => {
        this.AssigneeDepartments = result;
        this.AssigneeDepartments = this.AssigneeDepartments.data;
        console.log(this.AssigneeDepartments);
      },error => console.error(error)
    );
}



Next()
{
  if(this.AssigneeDepartments.page < this.AssigneeDepartments.total_page)
  {
    let nextPage = this.AssigneeDepartments.page + 1;
    let params = new HttpParams().set("page",nextPage).set("size", "10");
    this.http.get("https://localhost:44380/api/AssigneeDepartments/GetAll", {params}).subscribe(
        result => {
          this.AssigneeDepartments = result;
          this.AssigneeDepartments = this.AssigneeDepartments.data;
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
  if(this.AssigneeDepartments.page>1)
  {
    let PrePage = this.AssigneeDepartments.page - 1;
    let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
    this.http.get("https://localhost:44380/api/AssigneeDepartments/GetAll", {params}).subscribe(
        result => {
          this.AssigneeDepartments = result;
          this.AssigneeDepartments = this.AssigneeDepartments.data;
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
      this.AssigneeDepartment = {
        assigneeDepartmentId: "",
        assigneeId: "",
        departmentId:""
      };
    } else {
      this.isEdit = true;
      this.AssigneeDepartment = index;
    }
    $('#exampleModal').modal("show");
  }

  openModalEdit(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.AssigneeDepartment = {
        assigneeDepartmentId: "",
        assigneeId: "",
        departmentId:""
      };
    } else {
      this.isEdit = true;
      this.AssigneeDepartment = index;
    }
    $('#exampleModal1').modal("show");
  }

  
  addAssigneeDepartment()
  {
    var x = {
      assigneeDepartmentId: Number(this.AssigneeDepartment.assigneeDepartmentId),
      assigneeId: Number(this.selectedOptionAI),
      departmentId: Number(this.selectedOptionSI)
    };
    console.log(x);
    this.http.post("https://localhost:44380/api/AssigneeDepartments", x).subscribe(
      result => {
        var res:any = result;
        if(res.success)
        {
          this.AssigneeDepartment = res.data;
          window.location.reload();
        }
      },error => console.error(error)
    );
  }

 

  updateAssigneeDepartment(Id) {
    //console.log(id);
    var x = {
      assigneeDepartmentId: Number(this.AssigneeDepartment.assigneeDepartmentId),
      assigneeId: Number(this.selectedOptionAI),
      departmentId: Number(this.selectedOptionSI)
    };
    this.http.put("https://localhost:44380/api/AssigneeDepartments/" + Id, x).subscribe(
      (result) => {
        var res: any = result;
        if (res.success) {
          this.AssigneeDepartment = res.data;
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
  deleteAssigneeDepartment(Id)
  {
    this.http.delete("https://localhost:44380/api/AssigneeDepartments/" + Id).subscribe(
      result => {
        alert("Xóa thành công!");
        this.AssigneeDepartment = result;
        this.deleteAssigneeDepartment(Id);
        window.location.reload();
      },error => console.error(error)
    );
  }

  private SelectedCountry: any;
onChangeCountry($event) {
        this.SelectedCountry = $event.target.options[$event.target.options.selectedIndex].text;
      }

}

