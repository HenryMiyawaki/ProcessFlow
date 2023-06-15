import { Component, OnInit } from '@angular/core';
import { AreaModel } from 'src/app/models/AreaModel';
import { AreaService } from 'src/app/services/AreaService';
import { FontAwesome } from '../utils/font-awesome';

@Component({
  selector: 'app-areas',
  templateUrl: './areas.component.html',
  styleUrls: ['./areas.component.scss']
})

export class AreasComponent implements OnInit {

  areas: AreaModel[] = [];
  icons = new FontAwesome()

  constructor(private areaService: AreaService) { }

  ngOnInit(): void {
    this.getAreas();
  }

  getAreas(): void {
    this.areas = this.areaService.getAreas();
  }

}
