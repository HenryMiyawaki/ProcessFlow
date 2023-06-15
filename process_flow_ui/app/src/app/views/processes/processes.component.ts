import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AreaModel } from 'src/app/models/AreaModel';
import { ProcessModel } from 'src/app/models/ProcessModel';
import { ProcessService } from 'src/app/services/ProcessService';
import { ConfirmModalComponent } from '../utils/confirm-modal/confirm-modal.component';
import { FontAwesome } from '../utils/font-awesome';

@Component({
  selector: 'app-processes',
  templateUrl: './processes.component.html',
  styleUrls: ['./processes.component.scss'],
})
export class ProcessesComponent implements OnInit {
  processes: ProcessModel[] = [];
  areaRelative: AreaModel = new AreaModel();
  processToDeleteId: string | null = null;
  areaName: string | null = null;
  areaId: string | null = null;
  icons = new FontAwesome();
  @ViewChild(ConfirmModalComponent)
  confirmModalComponent!: ConfirmModalComponent;

  constructor(
    private processService: ProcessService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.areaName = this.route.snapshot.paramMap.get('name');
    this.areaId = this.route.snapshot.paramMap.get('id');

    if (this.areaName && this.areaName != null) {
      this.searchProcesses();
    }
  }

  openDeleteConfirmationModal(selectedItemId: any): void {
    this.processToDeleteId = selectedItemId;

    this.confirmModalComponent.openModal();
  }

  handleConfirmDelete(): void {
    if (
      this.processToDeleteId &&
      this.processToDeleteId != null &&
      this.areaId != null
    ) {
      this.processService
        .deleteProcess(this.areaId, this.processToDeleteId)
        .subscribe(() => {
          this.searchProcesses();
        });
    }
  }

  handleCancelDelete(): void {
    this.processToDeleteId = null;
  }

  searchProcesses() {
    if (this.areaName != null) {
      this.processService.getProcesses(this.areaName).subscribe(
        (processes) => {
          this.processes = processes;
        },
        () => {
          this.processes = [];
        }
      );
    }
  }

  getBackPageText() {
    return this.areaId == null ? '' : this.areaName + ' / ';
  }
}
