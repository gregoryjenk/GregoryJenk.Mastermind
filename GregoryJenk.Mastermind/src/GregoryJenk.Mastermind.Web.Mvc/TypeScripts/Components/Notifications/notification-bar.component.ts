import { Component } from "@angular/core";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Component({
    selector: "notification-bar",
    templateUrl: "/app/templates/notifications/notification-bar.component.html"
})
export class NotificationBarComponent {
    constructor(private notificationService: NotificationService) {

    }
}