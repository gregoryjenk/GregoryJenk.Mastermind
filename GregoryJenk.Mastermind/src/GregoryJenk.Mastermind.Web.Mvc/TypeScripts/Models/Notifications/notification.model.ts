export class Notification {
    public id: string;
    public title: string;
    public message: string;
    public description: string;
    public type: NotificationType;
    public hidden: boolean = false;

    constructor() {

    }

    public hide(hidden: boolean = true) {
        this.hidden = hidden;
    }
}