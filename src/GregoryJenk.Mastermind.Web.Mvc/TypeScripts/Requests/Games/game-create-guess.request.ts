import { GameGuessViewModel } from "../../ViewModels/Games/Guesses/game-guess.view-model";

export class GameCreateGuessRequest {
    public id: string;

    public version: number;

    public decoderUserId: string;

    public guess: GameGuessViewModel;
}