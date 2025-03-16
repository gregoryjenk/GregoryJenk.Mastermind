import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";
import { ApplicationConfig, ErrorHandler, provideZoneChangeDetection } from "@angular/core";
import { provideRouter, withComponentInputBinding } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { appRoutes } from "./app.route";
import { ExceptionDefaultHandler } from "./Handlers/Exceptions/exception-default.handler";
import { AuthenticationHeaderInterceptor } from "./Interceptors/Authentication/authentication-header.interceptor";
import { NotificationActionInterceptor } from "./Interceptors/Notifications/notification-action.interceptor";
import { GameService } from "./Services/Games/game.service";
import { NotificationService } from "./Services/Notifications/notification.service";
import { UserService } from "./Services/Users/user.service";
import { AuthenticationStoreCookieStrategy } from "./Strategies/Authentication/authentication-store-cookie.strategy";

let ngZoneOptions = {
    eventCoalescing: true
};

export const appConfig: ApplicationConfig = {
    providers: [
        provideHttpClient(withInterceptorsFromDi()),
        provideRouter(appRoutes, withComponentInputBinding()),
        provideZoneChangeDetection(ngZoneOptions),
        {
            multi: true,
            provide: HTTP_INTERCEPTORS,
            useClass: AuthenticationHeaderInterceptor
        },
        {
            multi: true,
            provide: HTTP_INTERCEPTORS,
            useClass: NotificationActionInterceptor
        },
        {
            provide: ErrorHandler,
            useClass: ExceptionDefaultHandler
        },
        AuthenticationStoreCookieStrategy,
        CookieService,
        GameService,
        NotificationService,
        UserService
    ]
};