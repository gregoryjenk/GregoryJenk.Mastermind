import { Guess } from "./Guess.model";
import { PegCode } from "../Pegs/peg-code.model";

export class Game {
    //TODO: Implement answer so it is not accessible on the client-side.
    private _answer: PegCode[] = [];
    private _guesses: Guess[] = [];

    constructor() {
        //TODO: Generate a random answer.
        this._answer.push(new PegCode(Colour.Orange));
        this._answer.push(new PegCode(Colour.Purple));
        this._answer.push(new PegCode(Colour.Orange));
        this._answer.push(new PegCode(Colour.Blue));

        this.addGuess(new Guess());
    }

    public addGuess(guess: Guess): void {
        //TODO: Check answer.
        this._guesses.push(guess);
    }
}