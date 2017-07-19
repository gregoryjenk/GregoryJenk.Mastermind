import { ErrorHandler, NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpModule, JsonpModule } from "@angular/http";
import { BrowserModule } from "@angular/platform-browser";
import { SlimLoadingBarModule } from "ng2-slim-loading-bar";
import { AppErrorHandler } from "./app.error";
import { NotificationBarComponent } from "./Components/Notifications/notification-bar.component";
import { NotificationService } from "./Services/Notifications/notification.service";
import { SecComponent } from "./Components/sec.component";

@NgModule({
    bootstrap: [SecComponent],
    declarations: [
        SecComponent,
        NotificationBarComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        SlimLoadingBarModule
    ],
    providers: [
        NotificationService,
        {
            provide: ErrorHandler,
            useClass: AppErrorHandler
        }
    ]
})
export class SecModule {

}