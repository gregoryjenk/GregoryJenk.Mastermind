import { ErrorHandler, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule, JsonpModule } from "@angular/http";
import { AppComponent } from "./Components/app.component";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule
        //routing
    ],
    providers: [
        //appRoutingProviders,
        //{
        //    provide: ErrorHandler,
        //    useClass: AppErrorHandler
        //}
    ]
})
export class AppModule {

}