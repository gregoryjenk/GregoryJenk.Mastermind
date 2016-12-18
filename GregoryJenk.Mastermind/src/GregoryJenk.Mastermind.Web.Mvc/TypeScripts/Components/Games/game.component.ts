import { Component } from "@angular/core";
import { DragulaService } from "ng2-dragula/ng2-dragula";
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

    private colours: PegCode[] = [];
    private currentGame: Game;
    private playedGames: Game[] = [];

    constructor(private dragulaService: DragulaService) {
        this.configureColours();
    }

    private onPegCodeDropped(pegCodeSource: PegCode, pegCodeTarget: PegCode) {
        var index = this.currentGame.guesses[0].pegCodes.indexOf(pegCodeTarget);

        console.log("Dropped " + pegCodeSource.colour + " onto index " + index);
    }

    private startGame() {
        this.currentGame = new Game();
        //this._currentGame.start();
    }

    private configureColours() {
        //Cannot loop through const enum, so have to list them out.
        this.colours.push(new PegCode(PegCodeColour.Blue));
        this.colours.push(new PegCode(PegCodeColour.Green));
        this.colours.push(new PegCode(PegCodeColour.Orange));
        this.colours.push(new PegCode(PegCodeColour.Purple));
        this.colours.push(new PegCode(PegCodeColour.Red));
        this.colours.push(new PegCode(PegCodeColour.Yellow));
    }

    //******************************************************************************
}