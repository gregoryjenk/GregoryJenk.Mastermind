import { ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule, JsonpModule } from "@angular/http";
import { AppComponent } from "./Components/app.component";
import { NavigationBarComponent } from "./Components/Navigations/navigation-bar.component";

//TODO: Notification and loading service.

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavigationBarComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule
        //routing
    ],
    providers: [
        //appRoutingProviders,
        //{
        //    provide: ErrorHandler,
        //    useClass: AppErrorHandler
        //}
        //LoadingService,
        //NotificationService
    ]
})
export class AppModule {

}