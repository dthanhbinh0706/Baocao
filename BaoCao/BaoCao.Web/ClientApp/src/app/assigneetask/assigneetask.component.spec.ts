import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssigneeTaskComponent } from './assigneetask.component';

describe('AssigneetaskComponent', () => {
  let component: AssigneeTaskComponent;
  let fixture: ComponentFixture<AssigneeTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssigneeTaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssigneeTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
