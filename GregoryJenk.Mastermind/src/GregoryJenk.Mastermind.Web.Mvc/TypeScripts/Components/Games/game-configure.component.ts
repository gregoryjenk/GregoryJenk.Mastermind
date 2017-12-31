import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Game } from "../../Models/Games/game.model";
import { GameService } from "../../Services/Games/game.service";
import { Notification } from "../../Models/Notifications/notification.model";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: "game-configure",
    templateUrl: "/app/templates/components/games/game-configure.component.html"
})
export class GameConfigureComponent {
    constructor(private gameService: GameService, private notificationService: NotificationService, private router: Router) {

    }

    private createGame() {
        this.notificationService.start();

        this.gameService.create(new Game())
            .subscribe(
                response => {
                    this.router.navigate(["/game/" + response.id])

                    this.notificationService.complete();
                },
                error => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not create game", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }
}