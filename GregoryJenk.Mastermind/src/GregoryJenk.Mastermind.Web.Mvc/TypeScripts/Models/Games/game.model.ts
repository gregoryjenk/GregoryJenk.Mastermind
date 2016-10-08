import { Guess } from "./Guess.model";

export class Game {
    //TODO: Implement answer so it is not accessible on the client-side.
    private _answer: Colour[];

    public guesses: Guess[];

    constructor() {
        //TODO: Generate a random answer.
        this._answer.push(Colour.Orange);
        this._answer.push(Colour.Purple);
        this._answer.push(Colour.Orange);
        this._answer.push(Colour.Blue);
    }

    public addGuess(guess: Guess): void {
        //TODO: Check answer.
        this.guesses.push(guess);
    }
}