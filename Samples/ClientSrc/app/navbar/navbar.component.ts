import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @Output() onAddClick = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  addClick() {
    this.onAddClick.emit();
  }
}
