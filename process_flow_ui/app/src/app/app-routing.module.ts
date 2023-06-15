import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AreaDetailsComponent } from './views/areas/area-details/area-details.component';
import { AreasComponent } from './views/areas/areas.component';

const routes: Routes = [
  {
    path: 'areas',
    component: AreasComponent
  },
  {
    path: 'area/:id', component: AreaDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
