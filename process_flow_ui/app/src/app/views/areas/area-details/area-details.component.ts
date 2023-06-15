import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AreaModel } from 'src/app/models/AreaModel';
import { AreaService } from '../../../services/AreaService';
import { FontAwesome } from '../../utils/font-awesome';

@Component({
  selector: 'app-area-details',
  templateUrl: './area-details.component.html',
  styleUrls: ['./area-details.component.scss'],
})
export class AreaDetailsComponent implements OnInit {
  id: string | null = null;
  area: AreaModel = new AreaModel();
  icons = new FontAwesome();

  constructor(
    private areaService: AreaService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id != null) {
      this.areaService.getAreaById(this.id).subscribe((area) => {
        this.area = area;
      });
    }
  }

  submit() {
    if (this.id != null) {
      this.areaService.updateArea(this.id, this.area).subscribe();
    } else {
      this.areaService.createArea(this.area).subscribe((area) => {
        this.router.navigate(['/areas']);
      });
    }
  }

  getTitleMethod() {
    return !this.id ? 'Create' : 'Edit';
  }
}
