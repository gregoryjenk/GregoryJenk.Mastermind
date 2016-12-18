import { Guess } from "./Guess.model";
import { PegCode } from "../Pegs/peg-code.model";

export class Game {
    //TODO: Implement answer so it is not accessible on the client-side.
    private answer: PegCode[] = [];
    private guesses: Guess[] = [];

    constructor() {
        //TODO: Generate a random answer.
        this.answer.push(new PegCode(PegCodeColour.Orange));
        this.answer.push(new PegCode(PegCodeColour.Purple));
        this.answer.push(new PegCode(PegCodeColour.Orange));
        this.answer.push(new PegCode(PegCodeColour.Blue));

        this.addGuess(new Guess());
    }

    public addGuess(guess: Guess): void {
        //TODO: Check answer.
        this.guesses.push(guess);
    }
}