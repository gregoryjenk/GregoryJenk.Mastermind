import { Response } from "@angular/http";

export abstract class BaseService {
    constructor() {

    }

    private convertResponseToArray(response: Response) {
        let body = response.json();
        return body || [];
    }
}