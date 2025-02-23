import { BaseEntityViewModel } from "../base-entity.view-model";
import { GameCodePegViewModel } from "./CodePegs/game-code-peg.view-model";
import { GameGuessViewModel } from "./Guesses/game-guess.view-model";

export class GameViewModel extends BaseEntityViewModel<string> {
    public state: GameState;

    public started: Date;

    public decoderUserId: string;

    public answerCodePegs: GameCodePegViewModel[] = [];

    public guesses: GameGuessViewModel[] = [];
}