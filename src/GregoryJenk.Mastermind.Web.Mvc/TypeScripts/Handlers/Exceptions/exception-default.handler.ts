import { ErrorHandler } from "@angular/core";

export class ExceptionDefaultHandler implements ErrorHandler {
    public handleError(error: any): void {
        window.location.replace("/error");
    }
}