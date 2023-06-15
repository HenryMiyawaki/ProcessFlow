import { Component, OnInit, ViewChild } from '@angular/core';
import { AreaModel } from 'src/app/models/AreaModel';
import { AreaService } from 'src/app/services/AreaService';
import { ConfirmModalComponent } from '../utils/confirm-modal/confirm-modal.component';
import { FontAwesome } from '../utils/font-awesome';

@Component({
  selector: 'app-areas',
  templateUrl: './areas.component.html',
  styleUrls: ['./areas.component.scss'],
})
export class AreasComponent implements OnInit {
  areas: AreaModel[] = [];
  areaToDeleteId: string | null = null;
  icons = new FontAwesome();
  showModal: boolean = false;
  @ViewChild(ConfirmModalComponent)
  confirmModalComponent!: ConfirmModalComponent;

  constructor(private areaService: AreaService) {}

  ngOnInit(): void {
    this.getAreas();
  }

  getAreas(): void {
    this.areaService.getAreas().subscribe((areas) => {
      this.areas = areas;
    });
  }

  openModal() {
    this.showModal = true;
  }

  openDeleteConfirmationModal(selectedItemId: any): void {
    this.areaToDeleteId = selectedItemId;

    this.confirmModalComponent.openModal();
  }

  handleConfirmDelete(): void {
    if (this.areaToDeleteId && this.areaToDeleteId != null) {
      console.log('deleting');

      this.areaService.deleteArea(this.areaToDeleteId).subscribe(() => {
        this.getAreas();
      });
    }
  }

  handleCancelDelete(): void {
    this.areaToDeleteId = null;
  }
}
