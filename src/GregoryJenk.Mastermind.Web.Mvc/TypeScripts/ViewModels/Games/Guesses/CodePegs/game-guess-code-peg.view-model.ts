import { GameCodePegColour } from "../../../../Models/Games/CodePegs/game-code-peg-colour";
import { BaseValueObjectViewModel } from "../../../base-value-object.view-model";

export class GameGuessCodePegViewModel extends BaseValueObjectViewModel {
    public index: number;

    public colour: GameCodePegColour;

    public guessId: number;
}