import { Component } from "@angular/core";
import { CodePeg } from "../../Models/Pegs/code-peg.model";
import { Game } from "../../Models/Games/game.model";
import { GameService } from "../../Services/Games/game.service";
import { Notification } from "../../Models/Notifications/notification.model";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: ".game-component",
    templateUrl: "/app/templates/components/games/game.component.html"
})
export class GameComponent {
    //TODO: Guess feedback rule where duplicates colours and wrong places.
    //TODO: Point based scoring system.
    //TODO: Five guess algorithm.

    private colours: CodePeg[] = [];
    private currentGame: Game;
    private playedGames: Game[] = [];

    constructor(private gameService: GameService, private notificationService: NotificationService) {
        this.configureColours();
    }

    private onPegCodeDropped(pegCodeSource: CodePeg, pegCodeTarget: CodePeg) {
        let guess = this.currentGame.guesses.length - 1;
        let index = this.currentGame.guesses[guess].guessCodePegs.indexOf(pegCodeTarget);

        this.currentGame.guesses[length].guessCodePegs[index] = pegCodeSource;
    }

    private startGame() {
        this.notificationService.start();

        this.gameService.create(new Game())
            .subscribe(
                response => {
                    this.currentGame = response;

                    this.notificationService.complete();
                },
                error => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not create game", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }

    private configureColours() {
        //Cannot loop through const enum, so have to list them out.
        this.colours.push(new CodePeg(CodePegColour.Blue));
        this.colours.push(new CodePeg(CodePegColour.Green));
        this.colours.push(new CodePeg(CodePegColour.Orange));
        this.colours.push(new CodePeg(CodePegColour.Purple));
        this.colours.push(new CodePeg(CodePegColour.Red));
        this.colours.push(new CodePeg(CodePegColour.Yellow));
    }
}