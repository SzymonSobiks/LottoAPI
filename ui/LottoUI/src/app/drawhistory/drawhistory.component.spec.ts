import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DrawhistoryComponent } from './drawhistory.component';

describe('DrawhistoryComponent', () => {
  let component: DrawhistoryComponent;
  let fixture: ComponentFixture<DrawhistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DrawhistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DrawhistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
