import { ErrorHandler } from "@angular/core";

export class AppErrorHandler extends ErrorHandler {
    //TODO: Add proper constructor(rethrowError?: boolean) in error handling.
    constructor() {
        super(false);
    }

    handleError(error: any): void {
        //TODO: Check for production mode in error handling.
        window.location.replace("/error");
    }
}