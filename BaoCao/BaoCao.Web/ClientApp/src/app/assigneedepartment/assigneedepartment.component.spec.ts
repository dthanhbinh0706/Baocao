import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssigneedepartmentComponent } from './assigneedepartment.component';

describe('AssigneedepartmentComponent', () => {
  let component: AssigneedepartmentComponent;
  let fixture: ComponentFixture<AssigneedepartmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssigneedepartmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssigneedepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
