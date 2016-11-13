import { Component } from "@angular/core";
import { Game } from "../../Models/Games/game.model";
import { PegCode } from "../../Models/Pegs/peg-code.model";

@Component({
    selector: ".game-component",
    templateUrl: "/app/templates/games/game.component.html"
})
export class GameComponent {
    //******************************************************************************
    //TODO: Guess feedback rule where duplicates colours and wrong places.
    //TODO: Point based scoring system.
    //TODO: Five guess algorithm.

    private _colours: PegCode[] = [];
    private _currentGame: Game;
    private _playedGames: Game[] = [];

    constructor() {
        this.configureColours();
    }

    private createGame() {
        this._currentGame = new Game();
    }

    private startGame() {
        //this._currentGame.start();
    }

    private configureColours() {
        //Cannot loop through const enum, so have to list them out.
        this._colours.push(new PegCode(PegCodeColour.Blue));
        this._colours.push(new PegCode(PegCodeColour.Green));
        this._colours.push(new PegCode(PegCodeColour.Orange));
        this._colours.push(new PegCode(PegCodeColour.Purple));
        this._colours.push(new PegCode(PegCodeColour.Red));
        this._colours.push(new PegCode(PegCodeColour.Yellow));
    }

    //******************************************************************************
}