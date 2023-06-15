import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id != null) {
      this.areaService.getAreaById(this.id).subscribe((area) => {
        console.log(area);

        this.area = area;
      });
    }
  }

  getTitleId() {
    return this.id != null ? '# ' + this.id : null;
  }
}
