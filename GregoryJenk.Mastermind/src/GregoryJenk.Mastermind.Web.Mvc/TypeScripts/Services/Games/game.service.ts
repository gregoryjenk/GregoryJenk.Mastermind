import { Headers, Http, RequestOptions } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { BaseService } from "../base.service";
import { Game } from "../../Models/Games/game.model";

@Injectable()
export class GameService extends BaseService {
    private gameUrl = "api/game";

    constructor(private http: Http) {
        super();
    }

    public create(game: Game): Observable<Game> {
        let headers = new Headers({ "Content-Type": "application/json" });
        let requestOptions = new RequestOptions({ headers: headers });

        return this.http.post(this.gameUrl, game, requestOptions)
            .map(this.convertResponseToObject);
    }

    public readById(id: string): Observable<Game> {
        return this.http.get(this.gameUrl + "/" + id)
            .map(this.convertResponseToObject);
    }
}