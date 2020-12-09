import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
declare var $: any;

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

    Departments: any = {
      data: [],
      total_record: Number,
      page: Number,
      size: Number,
      total_page: Number,
    };
  
    Department:any = {
      departmentId: Number,
      departmentName: String,
      
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
      this.GetAllDepartmentWithPagination(1);
      // this.getuseradminbyid(id);
    }
    
    GetAllDepartmentWithPagination(cPage) {
      
      //Tạo mới 2 parameter, page và size.
      let params = new HttpParams().set("page",cPage).set("size", "10");
      //Gọi Get method truyền vào 2 parameter.
      //Trả về danh sách Product với page = 1 và size = 10.
      this.http.get("https://localhost:44380/api/Departments", {params}).subscribe(
        result => {
          this.Departments = result;
          this.Departments = this.Departments.data;
          console.log(this.Departments);
        },error => console.error(error)
      );
  }
  
  
  
  Next()
  {
    if(this.Departments.page < this.Departments.total_page)
    {
      let nextPage = this.Departments.page + 1;
      let params = new HttpParams().set("page",nextPage).set("size", "10");
      this.http.get("https://localhost:44380/api/Departments", {params}).subscribe(
          result => {
            this.Departments = result;
            this.Departments = this.Departments.data;
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
    if(this.Departments.page>1)
    {
      let PrePage = this.Departments.page - 1;
      let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
      this.http.get("https://localhost:44380/api/Departments", {params}).subscribe(
          result => {
            this.Departments = result;
            this.Departments = this.Departments.data;
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
        this.Department = {
          departmentId: "",
          departmentName: "",
        };
      } else {
        this.isEdit = true;
        this.Department = index;
      }
      $('#exampleModal').modal("show");
    }
  
    openModalEdit(isNew, index) {
      if (isNew) {
        this.isEdit = false;
        this.Department = {
          departmentId: "",
          departmentName: "",
        };
      } else {
        this.isEdit = true;
        this.Department = index;
      }
      $('#exampleModal1').modal("show");
    }
  
    
    addDepartment()
    {
      var x = {
        departmentId: Number(this.Department.departmentId),
        departmentName: String(this.Department.departmentName) ,
      };
      console.log(x);
      this.http.post("https://localhost:44380/api/Departments", x).subscribe(
        result => {
          var res:any = result;
          if(res.success)
          {
            this.Department = res.data;
            window.location.reload();
          }
        },error => console.error(error)
      );
    }
  
   
  
    updateDepartment(Id) {
      //console.log(id);
      var x = {
        departmentId: Number(this.Department.departmentId),
        departmentName: String(this.Department.departmentName),
      };
      this.http.put("https://localhost:44380/api/Departments/" + Id, x).subscribe(
        (result) => {
          var res: any = result;
          if (res.success) {
            this.Department = res.data;
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
    deleteDepartment(Id)
    {
      this.http.delete("https://localhost:44380/api/Departments/" + Id).subscribe(
        result => {
          alert("Xóa thành công!");
          this.Department = result;
          this.deleteDepartment(Id);
          window.location.reload();
        },error => console.error(error)
      );
    }
  
  
  

}
