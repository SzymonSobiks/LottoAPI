import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewdrawComponent } from './newdraw.component';

describe('NewdrawComponent', () => {
  let component: NewdrawComponent;
  let fixture: ComponentFixture<NewdrawComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewdrawComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewdrawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
