import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { SamplesGridComponent } from './samples-grid/samples-grid.component';
import { NavbarComponent } from './navbar/navbar.component';
import { AddSampleComponent } from './add-sample/add-sample.component';

@NgModule({
  declarations: [
    AppComponent,
    SamplesGridComponent,
    NavbarComponent,
    AddSampleComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    NgxDatatableModule,
    ModalModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
