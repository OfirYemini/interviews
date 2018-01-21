import { environment } from '../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';

@Injectable()
export class PositionService{    
    private apiUrl:string = environment.apiURL;
    constructor(private http:HttpClient){
        let apiUrl = environment.apiURL + 'position';
    }

    getTransactions() {
        
        return ["trans1","trans2",this.apiUrl];
    }
}