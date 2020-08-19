export class Notification {
    public id: string;
    public title: string;
    public message: string;
    public description: string;
    public type: NotificationType;
    public hidden: boolean = false;

    constructor(title: string = "", message: string = "", type: NotificationType = NotificationType.Information) {
        this.title = title;
        this.message = message;
        this.type = type;
    }

    public hide(hidden: boolean = true) {
        this.hidden = hidden;
    }
}