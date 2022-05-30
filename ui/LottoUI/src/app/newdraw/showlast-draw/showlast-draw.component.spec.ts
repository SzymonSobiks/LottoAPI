import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowlastDrawComponent } from './showlast-draw.component';

describe('ShowlastDrawComponent', () => {
  let component: ShowlastDrawComponent;
  let fixture: ComponentFixture<ShowlastDrawComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowlastDrawComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowlastDrawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
