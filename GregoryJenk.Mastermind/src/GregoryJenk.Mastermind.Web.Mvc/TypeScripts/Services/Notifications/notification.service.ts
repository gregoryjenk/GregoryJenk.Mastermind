import { Injectable } from "@angular/core";
import { Notification } from "../../Models/Notifications/notification.model";

@Injectable()
export class NotificationService {
    public notifications: Notification[] = [];

    private create(notification: Notification): void {
        this.notifications.push(notification);

        setTimeout(() => {
            this.hide(notification);
        },
        4000);
    }

    private hide(notification: Notification): void {
        notification.hide = true;
    }

    private delete(notification: Notification): void {
        var index = this.notifications.indexOf(notification);

        this.notifications.splice(index, 1);
    }
}