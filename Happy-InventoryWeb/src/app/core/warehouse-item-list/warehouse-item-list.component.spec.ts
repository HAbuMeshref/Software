import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarehouseItemListComponent } from './warehouse-item-list.component';

describe('WarehouseItemListComponent', () => {
  let component: WarehouseItemListComponent;
  let fixture: ComponentFixture<WarehouseItemListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WarehouseItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WarehouseItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
