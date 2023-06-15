import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AreaModel } from "../models/AreaModel";

@Injectable({
    providedIn: "root"
})

export class AreaService {
    constructor(private http: HttpClient) {}

    getAreas() : any {
        // return this.http.get<AreaModel>();
        return [
            {
                id: "1",
                name: "Area 1",
                description: "desc",
                processes: [{
                    id: "1",
                    name: "Processo 1"
                }]
            },
            {
                id: "2",
                name: "Area 2",
                description: "desc",
            },
            {
                id: "3",
                name: "Area 3",
                description: "desc",
            }
        ]
    }
}