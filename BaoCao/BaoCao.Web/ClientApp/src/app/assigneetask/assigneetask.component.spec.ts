import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssigneetaskComponent } from './assigneetask.component';

describe('AssigneetaskComponent', () => {
  let component: AssigneetaskComponent;
  let fixture: ComponentFixture<AssigneetaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssigneetaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssigneetaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
