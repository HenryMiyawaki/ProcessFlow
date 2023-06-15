export class ProcessBaseModel {
    id?: string;
    name?: string;
    description?: string;
    usedSystems?: string[] | null;
    owners?: string[] | null;
    areaId?: string;
}