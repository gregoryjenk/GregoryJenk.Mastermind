import { Injectable } from "@angular/core";
import { NotificationAction } from "../../Models/Notifications/notification-action";
import { NotificationMessage } from "../../Models/Notifications/notification-message";
import { NotificationType } from "../../Models/Notifications/notification-type";

@Injectable()
export class NotificationService {
    constructor() {
        this.messages = [];
        this.actions = [];
    }

    public messages: NotificationMessage[];

    public actions: NotificationAction[];

    public createMessage(type: NotificationType, title: string, message: string): string {
        let id: string;
        let expired = new Date();
        let created = new Date();
        let notificationMessage = new NotificationMessage();

        id = crypto.randomUUID();

        expired.setDate(expired.getDate() + 1);

        notificationMessage.id = id;
        notificationMessage.type = type;
        notificationMessage.expired = expired;
        notificationMessage.created = created;
        notificationMessage.title = title;
        notificationMessage.message = message;

        this.messages.push(notificationMessage);

        return notificationMessage.id;
    }

    public deleteMessage(id: string): void {
        let index: number;

        index = this.messages.findIndex(notificationMessage => notificationMessage.id === id);

        this.messages.splice(index, 1);
    }

    public startAction(type: NotificationType, action: string): string {
        let id: string;
        let expired = new Date();
        let started = new Date();
        let notificationAction = new NotificationAction();

        id = crypto.randomUUID();

        expired.setDate(expired.getDate() + 1);

        notificationAction.id = id;
        notificationAction.type = type;
        notificationAction.expired = expired;
        notificationAction.started = started;
        notificationAction.action = action;

        this.actions.push(notificationAction);

        return notificationAction.id;
    }

    public endAction(id: string, type: NotificationType, result: string): void {
        let index: number;
        let ended = new Date();
        let notificationAction: NotificationAction;

        index = this.actions.findIndex(notificationAction => notificationAction.id === id);

        notificationAction = this.actions.at(index) as NotificationAction;

        notificationAction.type = type;
        notificationAction.ended = ended;
        notificationAction.result = result;
    }
}