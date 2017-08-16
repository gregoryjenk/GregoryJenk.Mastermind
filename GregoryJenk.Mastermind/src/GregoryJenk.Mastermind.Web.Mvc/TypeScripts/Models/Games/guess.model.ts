import { PegCode } from "../Pegs/peg-code.model";

export class Guess {
    public guessCodePegs: PegCode[] = [];

    constructor() {
        for (var i = 0; i < 4; i++) {
            this.guessCodePegs.push(new PegCode(PegCodeColour.Empty));
        }
    }
}