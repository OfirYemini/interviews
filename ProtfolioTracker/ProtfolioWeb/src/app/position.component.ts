import { PositionService, ITransaction } from './position.service';
import { Component,OnInit } from '@angular/core';
//import {MatTableModule} from '@angular/material';
import {MatTableDataSource} from '@angular/material';


@Component({
  selector: 'position',
  templateUrl: './position.component.html',  
  styleUrls: ['./position.component.css']
})
export class PositionComponent implements OnInit{
  
  title = 'List of transactions';
  transactions;
  dataSource : MatTableDataSource<ITransaction>;
  
  constructor(private service:PositionService){
      
  }

  ngOnInit(): void {
    this.service.getTransactions().subscribe(data=>{
      //debugger
      this.dataSource = new MatTableDataSource<ITransaction>(data);
      this.transactions = data;
    });
    
  }
}