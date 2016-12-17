export class Notification {
    public id: string;
    public title: string;
    public message: string;
    public description: string;
    public type: NotificationType;
    public hide: boolean = false;

    constructor() {

    }
}