import { Injectable } from "@angular/core";
import { Notification } from "../../Models/Notifications/notification.model";

@Injectable()
export class NotificationService {
    private notifications: Notification[] = [];

    private create(notification: Notification): void {
        this.notifications.push(notification);

        setTimeout(() => {
            notification.hide();
        },
        4000);
    }

    private delete(notification: Notification): void {
        var index = this.notifications.indexOf(notification);

        this.notifications.splice(index, 1);
    }
}