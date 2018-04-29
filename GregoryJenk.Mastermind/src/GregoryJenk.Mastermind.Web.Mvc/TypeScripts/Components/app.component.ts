import { Component } from "@angular/core";
import { Notification } from "../Models/Notifications/notification.model";
import { NotificationService } from "../Services/Notifications/notification.service";
import { User } from "../Models/Users/user.model";
import { UserService } from "../Services/Users/user.service";

@Component({
    selector: ".app-component",
    templateUrl: "/app/templates/components/app.component.html"
})
export class AppComponent {
    public user: User = new User();

    constructor(public notificationService: NotificationService, public userService: UserService) {
        this.readUser();
    }

    private readUser() {
        this.notificationService.start();

        this.userService.read()
            .subscribe(
                (response: any) => {
                    this.user = response;

                    this.notificationService.complete();
                },
                (error: any) => {
                    this.notificationService.create(new Notification("Uh oh!", "Could not read user", NotificationType.Danger));

                    this.notificationService.complete();
                }
            );
    }
}