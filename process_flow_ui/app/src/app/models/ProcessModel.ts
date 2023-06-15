import { ProcessBaseModel } from './ProcessBaseModel';
import { SubProcessModel } from './SubProcessModel';

export class ProcessModel extends ProcessBaseModel {
  subProcessess?: SubProcessModel[] | null;
}
