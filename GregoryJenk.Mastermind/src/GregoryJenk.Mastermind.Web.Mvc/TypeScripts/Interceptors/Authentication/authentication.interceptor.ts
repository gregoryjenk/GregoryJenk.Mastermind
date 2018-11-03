import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpResponse, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    intercept(httpRequest: HttpRequest<any>, httpHandler: HttpHandler): Observable<HttpEvent<any>> {
        var authenticationHeaderScheme = this.readCookieValueByName("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Scheme");
        var authenticationHeaderValue = this.readCookieValueByName("GregoryJenk.Mastermind.Web.Mvc.Controllers.Mvc.JwtToken.Value");

        const httpRequestCloned = httpRequest.clone({ headers: httpRequest.headers.set("Authorization", `${authenticationHeaderScheme} ${authenticationHeaderValue}`) });

        return httpHandler.handle(httpRequestCloned)
            .do((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    //Add any logic to successfull request responses here.
                }
            },
            (error: any) => {
                if (error instanceof HttpErrorResponse) {
                    if (error.status === 401) {
                        window.location.replace("/login");
                    }
                }
            });
    }

    private readCookieValueByName(name: string): string {
        const nameLength = name.length + 1;

        return document.cookie
            .split(";")
            .map(callback => callback.trim())
            .filter(cookie => {
                return cookie.substring(0, nameLength) === `${name}=`;
            })
            .map(cookie => {
                return decodeURIComponent(cookie.substring(nameLength));
            })[0] || null;
    }
}