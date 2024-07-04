import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { UsuarioComponent } from './Pages/usuario/usuario.component';
import { HistorialSolicitudEliminadaComponent } from './Pages/historial-solicitud-eliminada/historial-solicitud-eliminada.component';
import { SolicitudesComponent } from './Pages/solicitudes/solicitudes.component';
import { SharedModule } from '../../Reutilizable/shared/shared.module';
import { ModalUsuarioComponent } from './Modales/modal-usuario/modal-usuario.component';


@NgModule({
  declarations: [
    UsuarioComponent,
    HistorialSolicitudEliminadaComponent,
    SolicitudesComponent,
    ModalUsuarioComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    SharedModule
  ]
})
export class LayoutModule { }
