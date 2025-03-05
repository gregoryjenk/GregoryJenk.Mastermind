import { BaseValueObjectViewModel } from "../../base-value-object.view-model";
import { GameGuessCodePegViewModel } from "./CodePegs/game-guess-code-peg.view-model";

export class GameGuessViewModel extends BaseValueObjectViewModel {
    public correctIndexCorrectColour: number;

    public incorrectIndexCorrectColour: number;

    public gameId: string;

    public guessCodePegs: GameGuessCodePegViewModel[];
}