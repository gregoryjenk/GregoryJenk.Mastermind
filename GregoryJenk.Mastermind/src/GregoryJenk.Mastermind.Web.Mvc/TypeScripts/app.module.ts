import { ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule, JsonpModule } from "@angular/http";
import { routing, appRoutingProviders } from "./app.route";
import { AppComponent } from "./Components/app.component";
import { AppErrorHandler } from "./app.error";
import { DashboardComponent } from "./Components/Dashboards/dashboard.component";
import { GameComponent } from "./Components/Games/game.component";
import { NavigationBarComponent } from "./Components/Navigations/navigation-bar.component";
import { PegCodeComponent } from "./Components/Pegs/peg-code.component";

//TODO: Notification and loading service.

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        DashboardComponent,
        GameComponent,
        NavigationBarComponent,
        PegCodeComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        routing
    ],
    providers: [
        appRoutingProviders,
        //LoadingService,
        //NotificationService,
        {
            provide: ErrorHandler,
            useClass: AppErrorHandler
        }
    ]
})
export class AppModule {

}