import { Component } from "@angular/core";
import { Game } from "../../Models/Games/game.model";
import { GameService } from "../../Services/Games/game.service";
import { PegCode } from "../../Models/Pegs/peg-code.model";

@Component({
    selector: ".game-component",
    templateUrl: "/app/templates/components/games/game.component.html"
})
export class GameComponent {
    //TODO: Guess feedback rule where duplicates colours and wrong places.
    //TODO: Point based scoring system.
    //TODO: Five guess algorithm.

    private colours: PegCode[] = [];
    private currentGame: Game;
    private playedGames: Game[] = [];

    constructor(private gameService: GameService) {
        this.configureColours();
    }

    private onPegCodeDropped(pegCodeSource: PegCode, pegCodeTarget: PegCode) {
        let guess = this.currentGame.guesses.length - 1;
        let index = this.currentGame.guesses[guess].pegCodes.indexOf(pegCodeTarget);

        this.currentGame.guesses[length].pegCodes[index] = pegCodeSource;
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
}