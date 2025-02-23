import { BaseValueObjectViewModel } from "../../base-value-object.view-model";

export class GameCodePegViewModel extends BaseValueObjectViewModel {
    public index: number;

    public colour: CodePegColour;

    public gameId: string;
}