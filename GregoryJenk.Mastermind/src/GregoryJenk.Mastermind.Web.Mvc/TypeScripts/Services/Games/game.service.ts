import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { BaseService } from "../base.service";

@Injectable()
export class GameService extends BaseService {
    private gameUrl = "api/game";

    constructor(private http: Http) {
        super();
    }
}