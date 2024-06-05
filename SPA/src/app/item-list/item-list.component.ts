// item-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from '../item.model';
import { ItemService } from '../item.service';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  items: Item[] = [];
  isLoading = false;
  isError = false;

  constructor(private itemService: ItemService, private router: Router) {}

  ngOnInit(): void {
    this.isLoading = true;
    this.itemService.getItems().subscribe(
      items => {
        this.items = items;
        this.isLoading = false;
      },
      error => {
        console.error(error);
        this.isLoading = false;
        this.isError = true;
      }
    );
  }

  navigateToItemDetail(itemId: number): void {
    this.router.navigate(['/item', itemId]);
  }
}
