import { Response } from "@angular/http";

export abstract class BaseService {
    constructor() {

    }

    protected convertResponseToObject(response: Response) {
        let body = response.json();
        return body || {};
    }

    protected convertResponseToArray(response: Response) {
        let body = response.json();
        return body || [];
    }
}