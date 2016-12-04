import { ErrorHandler, NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpModule, JsonpModule } from "@angular/http";
import { BrowserModule } from "@angular/platform-browser";
import { ChartsModule } from "ng2-charts/ng2-charts";
import { DragulaModule, DragulaService } from "ng2-dragula/ng2-dragula";
import { AppErrorHandler } from "./app.error";
import { routing, appRoutingProviders } from "./app.route";
import { AppComponent } from "./Components/app.component";
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
        ChartsModule,
        DragulaModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        routing
    ],
    providers: [
        appRoutingProviders,
        DragulaService,
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