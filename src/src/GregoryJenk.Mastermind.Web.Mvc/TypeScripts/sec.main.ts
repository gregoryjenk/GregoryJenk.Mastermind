import { enableProdMode } from "@angular/core";
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { SecModule } from "./sec.module";

enableProdMode();

platformBrowserDynamic().bootstrapModule(SecModule);