import { PegCode } from "../Pegs/peg-code.model";

export class Guess {
    private _pegCodes: PegCode[] = [];
    private _pegCodesRightColourWrongPlace: number;
    private _pegCodesRightColourRightPlace: number;

    constructor() {
        for (var i = 0; i < 4; i++) {
            this._pegCodes.push(new PegCode(PegCodeColour.Empty));
        }
    }
}