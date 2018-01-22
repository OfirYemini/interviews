import { PositionService } from './position.service';
import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'position',
  templateUrl: './position.component.html',  
  styleUrls: ['./position.component.css']
})
export class PositionComponent implements OnInit{
  
  title = 'List of transactions';
  transactions;

  constructor(private service:PositionService){
      
  }

  ngOnInit(): void {
    this.service.getTransactions().subscribe(data=>{
      this.transactions = data;
    });
    
  }
}