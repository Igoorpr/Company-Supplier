import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { routes } from './app.routes';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        BrowserModule,
        RouterModule.forRoot(routes),
        AppComponent,
        FormsModule 
    ],
    bootstrap: []
})
export class AppModule { }
