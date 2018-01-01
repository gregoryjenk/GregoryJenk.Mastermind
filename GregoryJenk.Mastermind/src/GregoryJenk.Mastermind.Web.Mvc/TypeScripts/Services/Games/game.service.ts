import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { BaseService } from "../base.service";
import { Game } from "../../Models/Games/game.model";

//TODO: Convert result to proper response objects.
@Injectable()
export class GameService extends BaseService {
    private gameUrl = "api/game";

    constructor(private httpClient: HttpClient) {
        super();
    }

    public create(game: Game): Observable<Game> {
        let headers = new HttpHeaders({ "Content-Type": "application/json" });
        let requestOptions = { headers: headers };

        return this.httpClient.post(this.gameUrl, game, requestOptions)
            .map(this.convertResponseToObject);
    }

    public updateState(id: string, game: Game): Observable<Game> {
        let headers = new HttpHeaders({ "Content-Type": "application/json" });
        let requestOptions = { headers: headers };

        return this.httpClient.put(this.gameUrl + "/" + id + "/state", game, requestOptions)
            .map(this.convertResponseToObject);
    }

    public readById(id: string): Observable<Game> {
        return this.httpClient.get(this.gameUrl + "/" + id)
            .map(this.convertResponseToObject);
    }

    public readAll(): Observable<Game[]> {
        return this.httpClient.get(this.gameUrl)
            .map(this.convertResponseToArray);
    }
}