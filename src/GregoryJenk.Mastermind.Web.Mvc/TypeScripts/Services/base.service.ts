﻿import { Response } from "@angular/http";

export abstract class BaseService {
    constructor() {

    }

    protected convertResponseToObject(response: Response): any {
        let body = response;
        return body || {};
    }

    protected convertResponseToArray(response: Response): any {
        let body = response;
        return body || [];
    }
}