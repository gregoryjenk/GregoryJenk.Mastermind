import { Component } from "@angular/core";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: "notification-panel-component",
    styleUrl: "../../../wwwroot/src/styles/components/notifications/notification-panel.component.scss",
    templateUrl: "../../../wwwroot/app/templates/components/notifications/notification-panel.component.html"
})
export class NotificationPanelComponent {
    constructor(private readonly notificationService: NotificationService) {

    }
}