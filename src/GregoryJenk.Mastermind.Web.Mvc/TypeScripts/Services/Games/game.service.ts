import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { GameCreateGuessRequest } from "../../Requests/Games/game-create-guess.request";
import { GameUpdateStateRequest } from "../../Requests/Games/game-update-state.request";
import { GameViewModel } from "../../ViewModels/Games/game.view-model";

@Injectable()
export class GameService {
    constructor(private readonly httpClient: HttpClient) {

    }

    public readById(id: string): Observable<GameViewModel> {
        return this.httpClient.get<GameViewModel>(`api/game/${id}`);
    }

    public create(): Observable<GameViewModel> {
        return this.httpClient.post<GameViewModel>("api/game", null);
    }

    public readByDecoderUserId(): Observable<GameViewModel[]> {
        return this.httpClient.get<GameViewModel[]>("api/game");
    }

    public createGuess(gameCreateGuessRequest: GameCreateGuessRequest): Observable<GameViewModel> {
        return this.httpClient.post<GameViewModel>(`api/game/${gameCreateGuessRequest.id}/guess`, gameCreateGuessRequest);
    }

    public updateState(gameUpdateStateRequest: GameUpdateStateRequest): Observable<GameViewModel> {
        return this.httpClient.put<GameViewModel>(`api/game/${gameUpdateStateRequest.id}/state`, gameUpdateStateRequest);
    }
}