import { BaseNotification } from "./base-notification";

export class NotificationMessage extends BaseNotification {
    public created: Date;

    public title: string;

    public message: string;

    public read: boolean = false;

    public setRead(read: boolean = true) {
        this.read = read;
    }
}