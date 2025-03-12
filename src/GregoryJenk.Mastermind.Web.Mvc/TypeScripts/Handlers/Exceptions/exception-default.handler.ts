import { ErrorHandler, isDevMode } from "@angular/core";
import { appEnvironment } from "../../Environments/app.environment";
import { EnvironmentConstant } from "../../Environments/environment-constant";

export class ExceptionDefaultHandler implements ErrorHandler {
    public handleError(exception: any): void {
        if (isDevMode() && appEnvironment.name === EnvironmentConstant.DEVELOPMENT_NAME) {
            debugger;
        }

        window.location.assign("error");
    }
}