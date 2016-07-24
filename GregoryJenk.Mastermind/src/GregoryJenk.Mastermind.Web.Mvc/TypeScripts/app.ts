import {Component} from "angular2/core";
import {Game} from "./games/game";

@Component({
    selector: `mastermind-app`,
    template: `<h1>Mastermind</h1>`
})

export class MastermindApp {
    game = new Game();
}