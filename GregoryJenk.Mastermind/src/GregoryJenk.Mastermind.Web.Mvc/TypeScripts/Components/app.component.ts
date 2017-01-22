import { Component } from "@angular/core";
import { NotificationService } from "../Services/Notifications/notification.service";
import { User } from "../Models/Users/user.model";
import { UserService } from "../Services/Users/user.service";

@Component({
    selector: ".app-component",
    templateUrl: "/app/templates/app.component.html"
})
export class AppComponent {
    public user: User = new User();

    constructor(public notificationService: NotificationService, public userService: UserService) {
        this.readUser();
    }

    private readUser() {
        //TODO: this.notificationService.start();

        this.userService.read()
            .subscribe(
            response => {

                this.user = response;

                //this.notificationService.complete();
            },
            error => {
                //this.notificationService.create("Uh oh!", "Could not read user", error);

                //this.notificationService.complete();
            });
    }
}