export class Notification {
    private id: string;
    private title: string;
    private message: string;
    private description: string;
    private type: NotificationType;
    private hidden: boolean = false;

    constructor() {

    }

    public hide(hidden: boolean = true) {
        this.hidden = hidden;
    }
}