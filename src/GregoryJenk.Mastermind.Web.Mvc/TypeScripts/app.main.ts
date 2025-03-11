import { bootstrapApplication } from "@angular/platform-browser";
import { appConfig } from "./app.config";
import { AppComponent } from "./Components/app.component";

bootstrapApplication(AppComponent, appConfig)
    .catch((exception: any) => {
        console.error("Exception", exception);
    });