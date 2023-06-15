import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcessModel } from 'src/app/models/ProcessModel';
import { ProcessService } from 'src/app/services/ProcessService';
import { FontAwesome } from '../../utils/font-awesome';

@Component({
  selector: 'app-process-details',
  templateUrl: './process-details.component.html',
  styleUrls: ['./process-details.component.scss'],
})
export class ProcessDetailsComponent implements OnInit {
  id: string | null = null;
  process: ProcessModel = new ProcessModel();
  areaId: string | null = null;
  areaName: string | null = null;
  icons = new FontAwesome();

  constructor(
    private processService: ProcessService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.areaId = this.route.snapshot.paramMap.get('areaId');
    this.areaName = this.route.snapshot.paramMap.get('areaName');
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.areaId && this.areaId != null && this.id != null) {
      this.processService
        .getProcessById(this.areaId, this.id)
        .subscribe((process) => {
          this.process = process;
        });
    }
  }

  submit() {
    if (this.areaId != null && this.id != null) {
      this.processService
        .updateProcess(this.areaId, this.id, this.process)
        .subscribe();
    } else if (this.areaId != null) {
      this.processService
        .createProcess(this.areaId, this.process)
        .subscribe(() => {
          this.router.navigate([
            '/processes',
            { id: this.areaId, name: this.areaName },
          ]);
        });
    }
  }

  getTitleMethod() {
    return !this.id ? 'Create' : 'Edit';
  }
}
