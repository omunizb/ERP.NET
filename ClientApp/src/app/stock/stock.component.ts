import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {
  tableDataSrc: any;
  tableCols: string[] = ['name', 'category', 'description', 'price', 'stock', 'purchases', 'update', 'delete'];
  tableData: {}[] = [
    {
      name: "Earbuds 100X",
      category: "Electronics",
      description: "The best earbuds in the market!",
      price: 17.99,
      stock: 4500,
      purchases: 102
    },
    {
      name: "Blue shirt",
      category: "Men's Shirts",
      description: "A top-quality cotton shirt, in blue",
      price: 20.49,
      stock: 1200,
      purchases: 323
    },
    {
      name: "The Handmaid's Tale",
      category: "Books",
      description: `#1 New York Times bestseller. Look for The Testaments, the 
                    sequel to The Handmaid’s Tale, available now. An instant classic 
                    and eerily prescient cultural phenomenon, from “the patron saint 
                    of feminist dystopian fiction” (New York Times).Now an 
                    award-winning Hulu series starring Elizabeth Moss. In Margaret 
                    Atwood’s dystopian future, environmental disasters and declining 
                    birthrates have led to a Second American Civil War.The result is 
                    the rise of the Republic of Gilead, a totalitarian regime that 
                    enforces rigid social roles and enslaves the few remaining fertile 
                    women. Offred is one of these, a Handmaid bound to produce children 
                    for one of Gilead’s commanders.Deprived of her husband, her child, 
                    her freedom, and even her own name, Offred clings to her memories 
                    and her will to survive.At once a scathing satire, an ominous 
                    warning, and a tour de force of narrative suspense, The Handmaid’s 
                    Tale is a modern classic. Includes an introduction by Margaret 
                    Atwood. Paperback – March 16, 1998`,
      price: 7.99,
      stock: 3004,
      purchases: 2809
    }   
  ];
  
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor() { }

  ngOnInit() {
    this.tableDataSrc = new MatTableDataSource(this.tableData);
    this.tableDataSrc.sort = this.sort;
    this.tableDataSrc.paginator = this.paginator;
  }

  onSearchInput(ev) {
    const searchTarget = ev.target.value;
    this.tableDataSrc.filter = searchTarget.trim().toLowerCase();
  }

}
