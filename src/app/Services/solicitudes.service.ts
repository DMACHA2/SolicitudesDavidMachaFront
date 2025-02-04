import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { ResponseApi } from '../Interfaces/response-api';
import { Login } from '../Interfaces/login';
import { Usuario } from '../Interfaces/usuario';
import { Solicitudes } from '../Interfaces/solicitudes';

@Injectable({
  providedIn: 'root'
})
export class SolicitudesService {

  private urlApi:string = environment.endpoint + "Solicitudes/"
  constructor(private http:HttpClient) { }

  lista():Observable<ResponseApi>{
    return this.http.get<ResponseApi>(`${this.urlApi}Lista`)
  }

  guardar(request:Solicitudes):Observable<ResponseApi>{
    return this.http.post<ResponseApi>(`${this.urlApi}Guardar`,request)
  }

  editar(request:Solicitudes):Observable<ResponseApi>{
    return this.http.put<ResponseApi>(`${this.urlApi}Editar`,request)
  }

  eliminar(id:number):Observable<ResponseApi>{
    return this.http.delete<ResponseApi>(`${this.urlApi}Eliminar/${id}`)
  }
}
