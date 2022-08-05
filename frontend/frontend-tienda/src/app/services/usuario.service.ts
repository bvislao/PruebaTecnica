import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { CookieService } from "ngx-cookie-service";

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  constructor(private http: HttpClient,private cookies: CookieService) {}

  loginUsuario(user: string,pwd:string): Observable<any> {
    
    let params = new HttpParams();
      params = params.append('usuario', user);
      params = params.append('password', pwd);
      /*header('Access-Control-Allow-Origin: *');**/
    const httpOptions = {
        headers: { 'Content-Type': 'application/json',
        'Access-Control-Allow-Origin' : '*'},
        params: params
    };
    return this.http.get("https://localhost:7263/api/Usuario/login", 
    httpOptions);
  }

  setToken(token: any) {
    this.cookies.set("token", JSON.stringify(token));
  }
  getToken() {
    return this.cookies.get("token");
  }
}
