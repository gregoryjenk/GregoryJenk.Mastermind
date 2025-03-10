import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable, isDevMode } from "@angular/core";
import { Observable, tap } from "rxjs";
import { appEnvironment } from "../../Environments/app.environment";
import { EnvironmentConstant } from "../../Environments/environment-constant";
import { AuthenticationStoreCookieStrategy } from "../../Strategies/Authentication/authentication-store-cookie.strategy";

@Injectable()
export class AuthenticationHeaderInterceptor implements HttpInterceptor {
    constructor(private readonly authenticationStoreCookieStrategy: AuthenticationStoreCookieStrategy) {

    }

    public intercept(httpRequest: HttpRequest<any>, httpHandler: HttpHandler): Observable<HttpEvent<any>> {
        let authenticationStoreStrategyItem = this.authenticationStoreCookieStrategy.get();

        let update = {
            headers: httpRequest.headers.set("Authorization", `${authenticationStoreStrategyItem.scheme} ${authenticationStoreStrategyItem.token}`)
        };

        const cloneHttpRequest = httpRequest.clone(update);

        return httpHandler.handle(cloneHttpRequest)
            .pipe(
                tap({
                    next: (httpEvent: HttpEvent<any>) => {
                        if (httpEvent instanceof HttpResponse) {
                            //Add any logic to successfull request responses here.
                        }
                    },
                    error: (exception: any) => {
                        if (exception instanceof HttpErrorResponse && isDevMode() && appEnvironment.name === EnvironmentConstant.DEVELOPMENT_NAME) {
                            debugger;
                        }
                    }
                })
            );
    }
}