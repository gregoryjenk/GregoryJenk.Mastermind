import { BaseValueObjectViewModel } from "../../../base-value-object.view-model";

export class GameGuessCodePegViewModel extends BaseValueObjectViewModel {
    public index: number;

    public colour: CodePegColour;

    public guessId: number;
}