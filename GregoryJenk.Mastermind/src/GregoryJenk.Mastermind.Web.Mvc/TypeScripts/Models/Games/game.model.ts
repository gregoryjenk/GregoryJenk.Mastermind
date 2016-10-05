import { Guess } from "./Guess.model";

export class Game {
    //TODO: Implement answer so it is not accessible on the client-side.
    private _answer: Colour[];

    public guesses: Guess[];

    constructor() {

    }

    public AddGuess(guess: Guess): void {
        //TODO: Check answer.
        this.guesses.push(guess);
    }
}