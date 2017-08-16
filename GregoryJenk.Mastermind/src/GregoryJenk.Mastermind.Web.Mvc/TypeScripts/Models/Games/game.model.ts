import { CodePeg } from "../Pegs/code-peg.model";
import { Guess } from "./Guess.model";

export class Game {
    public guesses: Guess[] = [];
    public answerCodePegs: CodePeg[] = [];

    constructor() {
        this.addGuess(new Guess());
    }

    public addGuess(guess: Guess): void {
        //TODO: Check answer.
        this.guesses.push(guess);
    }
}