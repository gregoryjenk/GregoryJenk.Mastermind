import { BaseNotification } from "./base-notification";

export class NotificationAction extends BaseNotification {
    public started: Date;

    public ended: Date | null;

    public action: string;

    public result: string | null;
}