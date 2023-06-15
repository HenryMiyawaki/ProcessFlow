import { ProcessModel } from "./ProcessModel";

export class AreaModel {
    id?: string;
    name?: string;
    description?: string;
    processes?: ProcessModel[] | null;
}