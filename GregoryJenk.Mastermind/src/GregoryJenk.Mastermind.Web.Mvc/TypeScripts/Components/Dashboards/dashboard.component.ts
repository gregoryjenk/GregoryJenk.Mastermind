import { Component } from "@angular/core";
import { Game } from "../../Models/Games/game.model";
import { GameService } from "../../Services/Games/game.service";
import { Notification } from "../../Models/Notifications/notification.model";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: ".dashboard-component",
    templateUrl: "/app/templates/components/dashboards/dashboard.component.html"
})
export class DashboardComponent {
    private games: Game[] = [];

    constructor(private gameService: GameService, private notificationService: NotificationService) {
        this.notificationService.start();

        this.gameService.readAll()
            .subscribe(
                response => {
                    this.games = response;

                    this.notificationService.complete();
                },
                error => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not load games", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }
}