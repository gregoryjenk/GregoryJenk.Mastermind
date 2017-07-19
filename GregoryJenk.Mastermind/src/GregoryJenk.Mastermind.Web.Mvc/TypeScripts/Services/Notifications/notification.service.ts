import { Injectable } from "@angular/core";
import { SlimLoadingBarService } from "ng2-slim-loading-bar";
import { Notification } from "../../Models/Notifications/notification.model";

@Injectable()
export class NotificationService {
    private notifications: Notification[] = [];

    constructor(private slimLoadingBarService: SlimLoadingBarService) {

    }

    public create(notification: Notification): void {
        this.notifications.push(notification);

        setTimeout(() => {
            notification.hide();
        },
        4000);
    }

    public delete(notification: Notification): void {
        var index = this.notifications.indexOf(notification);

        this.notifications.splice(index, 1);
    }

    public start(): void {
        this.slimLoadingBarService.start();
    }

    public complete(): void {
        this.slimLoadingBarService.complete();
    }
}