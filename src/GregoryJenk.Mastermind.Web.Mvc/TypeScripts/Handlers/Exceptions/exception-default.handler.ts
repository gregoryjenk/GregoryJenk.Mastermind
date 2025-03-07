import { ErrorHandler } from "@angular/core";

export class AppErrorHandler extends ErrorHandler {
    //TODO: Add proper constructor(rethrowError?: boolean) in error handling.
    constructor() {
        super();
    }

    handleError(error: any): void {
        //This will cause client-side processing to pause when the developer tools are open.
        debugger;

        //TODO: Check for production mode in error handling.
        window.location.replace("/error");
    }
}