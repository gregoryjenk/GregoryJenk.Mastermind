import { CodePeg } from "../Pegs/code-peg.model";

export class Guess {
    public guessCodePegs: CodePeg[] = [];

    constructor() {
        for (var i = 0; i < 4; i++) {
            this.guessCodePegs.push(new CodePeg(CodePegColour.Empty));
        }
    }
}