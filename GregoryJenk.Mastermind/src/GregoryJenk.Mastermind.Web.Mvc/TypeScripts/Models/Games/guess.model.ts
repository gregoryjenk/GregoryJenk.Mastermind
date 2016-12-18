import { PegCode } from "../Pegs/peg-code.model";

export class Guess {
    public pegCodes: PegCode[] = [];
    public pegCodesRightColourWrongPlace: number;
    public pegCodesRightColourRightPlace: number;

    constructor() {
        for (var i = 0; i < 4; i++) {
            this.pegCodes.push(new PegCode(PegCodeColour.Empty));
        }
    }
}