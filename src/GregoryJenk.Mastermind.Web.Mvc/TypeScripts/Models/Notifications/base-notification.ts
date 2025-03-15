import { NotificationType } from "./notification-type";

export abstract class BaseNotification {
    public id: string;

    public type: NotificationType;

    public expired: Date;
}