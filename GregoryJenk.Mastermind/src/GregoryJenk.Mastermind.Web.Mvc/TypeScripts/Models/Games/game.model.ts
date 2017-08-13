import { Guess } from "./Guess.model";
import { PegCode } from "../Pegs/peg-code.model";

export class Game {
    public answer: PegCode[] = [];
    public guesses: Guess[] = [];

    constructor() {
        this.addGuess(new Guess());
    }

    public addGuess(guess: Guess): void {
        //TODO: Check answer.
        this.guesses.push(guess);
    }
}