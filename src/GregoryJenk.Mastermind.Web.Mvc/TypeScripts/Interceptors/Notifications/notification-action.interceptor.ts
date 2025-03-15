import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { NotificationType } from "../../Models/Notifications/notification-type";
import { NotificationService } from "../../Services/Notifications/notification.service";

@Injectable()
export class NotificationActionInterceptor implements HttpInterceptor {
    constructor(private readonly notificationService: NotificationService) {

    }

    public intercept(httpRequest: HttpRequest<any>, httpHandler: HttpHandler): Observable<HttpEvent<any>> {
        let id = this.notificationService.startAction(NotificationType.Information, `${httpRequest.method} ${httpRequest.url}`);

        return httpHandler.handle(httpRequest)
            .pipe(
                tap({
                    next: (httpEvent: HttpEvent<any>) => {
                        if (httpEvent instanceof HttpResponse) {
                            this.notificationService.endAction(id, NotificationType.Success, `${httpEvent.status} ${httpEvent.statusText}`);
                        }
                    },
                    error: (exception: any) => {
                        if (exception instanceof HttpErrorResponse) {
                            this.notificationService.endAction(id, NotificationType.Danger, `${exception.status} Exception`);
                        }
                    }
                })
            );
    }
}