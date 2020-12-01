import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Router , NavigationEnd} from "@angular/router";
declare var $: any;


@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.css']
})
export class StateComponent implements OnInit {
  States: any = {
    data: [],
    total_record: Number,
    page: Number,
    size: Number,
    total_page: Number,
  };

  State:any = {
    stateId: Number,
    stateName: String,
    
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
    this.GetAllStateWithPagination(1);
    // this.getuseradminbyid(id);
  }
  
  GetAllStateWithPagination(cPage) {
    
    //Tạo mới 2 parameter, page và size.
    let params = new HttpParams().set("page",cPage).set("size", "10");
    //Gọi Get method truyền vào 2 parameter.
    //Trả về danh sách Product với page = 1 và size = 10.
    this.http.get("https://localhost:44380/api/States", {params}).subscribe(
      result => {
        this.States = result;
        this.States = this.States.data;
        console.log(this.States);
      },error => console.error(error)
    );
}



Next()
{
  if(this.States.page < this.States.total_page)
  {
    let nextPage = this.States.page + 1;
    let params = new HttpParams().set("page",nextPage).set("size", "10");
    this.http.get("https://localhost:44380/api/States", {params}).subscribe(
        result => {
          this.States = result;
          this.States = this.States.data;
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
  if(this.States.page>1)
  {
    let PrePage = this.States.page - 1;
    let params = new HttpParams().set("page",PrePage.toString()).set("size", "10");
    this.http.get("https://localhost:44380/api/States", {params}).subscribe(
        result => {
          this.States = result;
          this.States = this.States.data;
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
      this.State = {
        stateId: "",
        stateName: "",
      };
    } else {
      this.isEdit = true;
      this.State = index;
    }
    $('#exampleModal').modal("show");
  }

  openModalEdit(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.State = {
        stateId: "",
        stateName: "",
      };
    } else {
      this.isEdit = true;
      this.State = index;
    }
    $('#exampleModal1').modal("show");
  }

  
  addState()
  {
    var x = {
      stateId: Number(this.State.stateId),
      stateName: String(this.State.stateName) ,
    };
    console.log(x);
    this.http.post("https://localhost:44380/api/States", x).subscribe(
      result => {
        var res:any = result;
        if(res.success)
        {
          this.State = res.data;
          window.location.reload();
        }
      },error => console.error(error)
    );
  }

 

  updateState(Id) {
    //console.log(id);
    var x = {
      stateId: Number(this.State.stateId),
      stateName: String(this.State.stateName),
    };
    this.http.put("https://localhost:44380/api/States/" + Id, x).subscribe(
      (result) => {
        var res: any = result;
        if (res.success) {
          this.State = res.data;
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
  deleteState(Id)
  {
    this.http.delete("https://localhost:44380/api/States/" + Id).subscribe(
      result => {
        alert("Xóa thành công!");
        this.State = result;
        this.deleteState(Id);
        window.location.reload();
      },error => console.error(error)
    );
  }


}