import { Component, OnInit } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { NotificationType } from "../Models/Notifications/notification-type";
import { NotificationService } from "../Services/Notifications/notification.service";
import { UserService } from "../Services/Users/user.service";
import { UserViewModel } from "../ViewModels/Users/user.view-model";
import { NavigationBarComponent } from "./Navigations/navigation-bar.component";
import { NotificationPanelComponent } from "./Notifications/notification-panel.component";

let imports = [
    NavigationBarComponent,
    NotificationPanelComponent,
    RouterOutlet
];

@Component({
    imports: imports,
    selector: "app-component",
    templateUrl: "../../wwwroot/app/templates/components/app.component.html"
})
export class AppComponent implements OnInit {
    constructor(public readonly userService: UserService, public readonly notificationService: NotificationService) {

    }

    public user: UserViewModel;

    public ngOnInit(): void {
        this.userService.read()
            .subscribe({
                next: (userViewModel: UserViewModel) => {
                    this.user = userViewModel;
                },
                error: (exception: any) => {
                    this.notificationService.createMessage(NotificationType.Danger, "User Read Exception", "Could not complete the request to read user.");
                }
            });
    }
}