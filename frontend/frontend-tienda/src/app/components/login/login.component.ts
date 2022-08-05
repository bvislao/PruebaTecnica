import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  dni: string;
  password: string;

  constructor(public usuarioService: UsuarioService,public router: Router) {}

  ngOnInit(): void {
  }

  login() {
    this.usuarioService.loginUsuario(this.dni,this.password).subscribe( data => {
      if(data.statusCode == 200){
        this.usuarioService.setToken(data.responsedata);
        this.router.navigateByUrl('/home');
      }else{
        alert("Usuario o contraseña invalida");
      }
    });
  }
}
