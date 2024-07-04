import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorialSolicitudEliminadaComponent } from './historial-solicitud-eliminada.component';

describe('HistorialSolicitudEliminadaComponent', () => {
  let component: HistorialSolicitudEliminadaComponent;
  let fixture: ComponentFixture<HistorialSolicitudEliminadaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HistorialSolicitudEliminadaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HistorialSolicitudEliminadaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
