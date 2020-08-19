import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { CodePeg } from "../../Models/Pegs/code-peg.model";
import { Game } from "../../Models/Games/game.model";
import { GameService } from "../../Services/Games/game.service";
import { Guess } from "../../Models/Games/Guess.model";
import { Notification } from "../../Models/Notifications/notification.model";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: "game",
    templateUrl: "/app/templates/components/games/game.component.html"
})
export class GameComponent {
    //TODO: Guess feedback rule where duplicates colours and wrong places.
    //TODO: Point based scoring system.
    //TODO: Five guess algorithm.

    private colours: CodePeg[] = [];
    private currentGame: Game;
    private currentGuess: Guess = new Guess();
    private playedGames: Game[] = [];

    constructor(private activatedRoute: ActivatedRoute, private gameService: GameService, private notificationService: NotificationService) {
        this.configureColours();

        this.notificationService.start();

        this.gameService.readById(activatedRoute.snapshot.params["id"])
            .subscribe(
                (response: any) => {
                    this.currentGame = response;

                    this.notificationService.complete();
                },
                (error: any) => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not load game", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }

    private startGame() {
        var gameClone = Object.assign({}, this.currentGame);

        gameClone.state = GameState.Started;

        this.notificationService.start();

        this.gameService.updateState(this.currentGame.id, gameClone)
            .subscribe(
                (response: any) => {
                    this.currentGame = response;

                    this.notificationService.complete();
                },
                (error: any) => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not start game", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }

    private createGuess() {
        this.notificationService.start();

        this.gameService.createGuess(this.currentGame.id, this.currentGame, this.currentGuess)
            .subscribe(
                (response: any) => {
                    this.currentGame = response;

                    this.currentGuess = new Guess();

                    this.notificationService.complete();
                },
                (error: any) => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not create guess", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }

    private onPegCodeDropped(pegCodeSource: CodePeg, pegCodeTarget: CodePeg) {
        let guess = this.currentGame.guesses.length - 1;
        let index = this.currentGame.guesses[guess].guessCodePegs.indexOf(pegCodeTarget);

        this.currentGame.guesses[length].guessCodePegs[index] = pegCodeSource;
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