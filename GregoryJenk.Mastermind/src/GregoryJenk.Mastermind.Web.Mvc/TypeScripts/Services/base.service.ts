import { Response } from "@angular/http";

export class BaseService {
    constructor() {

    }

    private convertResponseToArray(response: Response) {
        let body = response.json();
        return body || [];
    }
}