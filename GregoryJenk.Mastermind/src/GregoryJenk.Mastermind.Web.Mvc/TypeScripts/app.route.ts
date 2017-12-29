import { Routes, RouterModule } from "@angular/router";
import { DashboardComponent } from "./Components/Dashboards/dashboard.component";
import { GameComponent } from "./Components/Games/game.component";
import { GameConfigureComponent } from "./Components/Games/game-configure.component";

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
        component: GameConfigureComponent,
        path: "play"
    },
    {
        component: GameComponent,
        path: "game/:id"
    }
    //{
    //    component: PageNotFoundComponent,
    //    path: "**"
    //}
];

export const appRoutingProviders: any[] = [

];

export const routing = RouterModule.forRoot(appRoutes);