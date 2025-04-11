import { Component } from "@angular/core";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: "notification-bar-component",
    styleUrl: "../../../wwwroot/src/styles/components/notifications/notification-bar.component.scss",
    templateUrl: "../../../wwwroot/app/templates/components/notifications/notification-bar.component.html"
})
export class NotificationBarComponent {
    constructor(private readonly notificationService: NotificationService) {

    }
}