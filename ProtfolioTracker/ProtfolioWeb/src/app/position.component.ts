import { PositionService } from './position.service';
import { Component } from '@angular/core';

@Component({
  selector: 'position',
  templateUrl: './position.component.html',  
  styleUrls: ['./position.component.css']
})
export class PositionComponent {
  title = 'List of transactions';
  transactions;

  constructor(service:PositionService){
      this.transactions = service.getTransactions();
  }
}