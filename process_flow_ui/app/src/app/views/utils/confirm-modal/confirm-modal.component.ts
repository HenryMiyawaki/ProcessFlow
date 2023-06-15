import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.scss'],
})
export class ConfirmModalComponent implements OnInit {
  @Input() title: string = '';
  @Input() message: string = '';
  @Input() confirmButtonText: string = '';
  @Output() confirmEmitter: EventEmitter<void> = new EventEmitter<void>();
  @Output() cancelEmitter: EventEmitter<void> = new EventEmitter<void>();

  isOpen: boolean = false;

  ngOnInit(): void {}

  openModal(): void {
    this.isOpen = true;
  }

  closeModal(): void {
    this.isOpen = false;
    this.cancelEmitter.emit();
  }

  confirm(): void {
    this.isOpen = false;
    this.confirmEmitter.emit();
  }
}
