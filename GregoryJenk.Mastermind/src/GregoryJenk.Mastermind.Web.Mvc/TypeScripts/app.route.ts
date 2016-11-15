import { Routes, RouterModule } from "@angular/router";
import { DashboardComponent } from "./Components/Dashboards/dashboard.component";
import { GameComponent } from "./Components/Games/game.component";

const appRoutes: Routes = [
    {
        component: DashboardComponent,
        path: ""
        //pathMatch: "full",
        //redirectTo: "dashboard"
    },
    {
        component: DashboardComponent,
        path: "dashboard"
    },
    {
        component: GameComponent,
        path: "play"
    },
    //{
    //    component: PageNotFoundComponent,
    //    path: "**"
    //}
];

export const appRoutingProviders: any[] = [

];

export const routing = RouterModule.forRoot(appRoutes);