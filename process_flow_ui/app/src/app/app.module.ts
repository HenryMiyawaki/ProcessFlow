import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AreasComponent } from './views/areas/areas.component';
import { NavbarComponent } from './views/utils/navbar/navbar.component';

import { FormsModule } from '@angular/forms';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faFilm } from '@fortawesome/free-solid-svg-icons';
import { AreaDetailsComponent } from './views/areas/area-details/area-details.component';
import { ProcessDetailsComponent } from './views/processes/process-details/process-details.component';
import { ProcessesComponent } from './views/processes/processes.component';
import { ConfirmModalComponent } from './views/utils/confirm-modal/confirm-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    AreasComponent,
    NavbarComponent,
    AreaDetailsComponent,
    ConfirmModalComponent,
    ProcessesComponent,
    ProcessDetailsComponent,
    ProcessDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor() {
    library.add(faFilm);
  }
}
