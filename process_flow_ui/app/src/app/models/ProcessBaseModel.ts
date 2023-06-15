export class ProcessBaseModel {
  id?: string;
  name?: string;
  description?: string;
  usedSystems?: string[] | null;
  ownersIds?: string[] | null;
  areaName?: string;
  areaId?: string;
}
