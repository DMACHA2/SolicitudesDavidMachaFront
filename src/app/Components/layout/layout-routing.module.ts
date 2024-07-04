import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { UsuarioComponent } from './Pages/usuario/usuario.component';
import { SolicitudesComponent } from './Pages/solicitudes/solicitudes.component';
import { HistorialSolicitudEliminadaComponent } from './Pages/historial-solicitud-eliminada/historial-solicitud-eliminada.component';

const routes: Routes = [{
  path:'',
  component:LayoutComponent,
  children:[
    {path:'usuario',component:UsuarioComponent},
    {path:'solicitudes',component:SolicitudesComponent},
    {path:'historial-solicitud-eliminada',component:HistorialSolicitudEliminadaComponent}
  ]
}
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
