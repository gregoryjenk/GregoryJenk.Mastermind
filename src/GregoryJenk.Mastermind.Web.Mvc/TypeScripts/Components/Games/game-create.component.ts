import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { NotificationType } from "../../Models/Notifications/notification-type";
import { GameService } from "../../Services/Games/game.service";
import { NotificationService } from "../../Services/Notifications/notification.service";
import { GameViewModel } from "../../ViewModels/Games/game.view-model";

@Component({
    templateUrl: "../../../wwwroot/app/templates/components/games/game-create.component.html"
})
export class GameCreateComponent {
    constructor(private readonly gameService: GameService, private readonly router: Router, private readonly notificationService: NotificationService) {

    }

    public create(): void {
        this.gameService.create()
            .subscribe({
                next: (gameViewModel: GameViewModel) => {
                    let commands = [
                        "game",
                        gameViewModel.id
                    ];

                    let extras = {
                        state: gameViewModel
                    };

                    this.router.navigate(commands, extras);
                },
                error: (exception: any) => {
                    this.notificationService.createMessage(NotificationType.Danger, "Game Create Exception", "Could not complete the request to create a game.");
                }
            });
    }
}