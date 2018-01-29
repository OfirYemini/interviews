import { PositionComponent } from './position.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PositionService } from './position.service';
import { HttpClientModule } from '@angular/common/http';
import {MatTableModule} from '@angular/material';



@NgModule({
  declarations: [
    AppComponent,PositionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatTableModule
    //MatTableDataSource, 
    //MatSort
  ],
  providers: [
    PositionService,HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
