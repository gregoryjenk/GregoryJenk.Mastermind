﻿import { ErrorHandler, NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { ChartsModule } from "ng2-charts/ng2-charts";
import { MomentModule } from "angular2-moment";
import { SlimLoadingBarModule } from "ng2-slim-loading-bar";
import { AppErrorHandler } from "./app.error";
import { routing, appRoutingProviders } from "./app.route";
import { AppComponent } from "./Components/app.component";
import { AuthenticationInterceptor } from "./Interceptors/Authentication/authentication.interceptor";
import { DashboardComponent } from "./Components/Dashboards/dashboard.component";
import { GameComponent } from "./Components/Games/game.component";
import { GameConfigureComponent } from "./Components/Games/game-configure.component";
import { GameService } from "./Services/Games/game.service";
import { GameStateComponent } from "./Components/Games/States/game-state.component";
import { NavigationBarComponent } from "./Components/Navigations/navigation-bar.component";
import { NotificationBarComponent } from "./Components/Notifications/notification-bar.component";
import { NotificationService } from "./Services/Notifications/notification.service";
import { PegCodeComponent } from "./Components/Pegs/peg-code.component";
import { PegCodeDraggableDirective } from "./Directives/Pegs/peg-code-draggable.directive";
import { PegCodeDroppableDirective } from "./Directives/Pegs/peg-code-droppable.directive";
import { UserService } from "./Services/Users/user.service";

//Adding extension like function to map objects from service requests.
import "rxjs/Rx";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        DashboardComponent,
        GameComponent,
        GameConfigureComponent,
        GameStateComponent,
        NavigationBarComponent,
        NotificationBarComponent,
        PegCodeComponent,
        PegCodeDraggableDirective,
        PegCodeDroppableDirective
    ],
    imports: [
        BrowserModule,
        ChartsModule,
        FormsModule,
        HttpClientModule,
        MomentModule,
        SlimLoadingBarModule,
        routing
    ],
    providers: [
        appRoutingProviders,
        GameService,
        {
            multi: true,
            provide: HTTP_INTERCEPTORS,
            useClass: AuthenticationInterceptor
        },
        NotificationService,
        {
            provide: ErrorHandler,
            useClass: AppErrorHandler
        },
        UserService
    ]
})
export class AppModule {

}