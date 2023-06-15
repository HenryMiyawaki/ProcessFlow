import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AreaDetailsComponent } from './views/areas/area-details/area-details.component';
import { AreasComponent } from './views/areas/areas.component';
import { ProcessDetailsComponent } from './views/processes/process-details/process-details.component';
import { ProcessesComponent } from './views/processes/processes.component';

const routes: Routes = [
  {
    path: 'areas',
    component: AreasComponent,
  },
  {
    path: 'area',
    children: [
      { path: '', component: AreaDetailsComponent },
      { path: ':id', component: AreaDetailsComponent },
    ],
  },
  {
    path: 'processes',
    children: [
      { path: '', component: ProcessesComponent },
      { path: ':id', component: ProcessesComponent },
    ],
  },
  {
    path: 'process',
    children: [
      { path: '', component: ProcessDetailsComponent },
      { path: ':areaId/:id', component: ProcessDetailsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
