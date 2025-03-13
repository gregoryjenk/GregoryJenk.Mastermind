import { Routes } from "@angular/router";
import { GameCreateComponent } from "./Components/Games/game-create.component";
import { GameComponent } from "./Components/Games/game.component";

export const appRoutes: Routes = [
    {
        component: GameCreateComponent,
        path: ""
    },
    {
        component: GameComponent,
        path: "game/:id"
    },
    {
        path: "**",
        redirectTo: redirectTo
    }
];

function redirectTo(): string {
    window.location.assign("not-found");

    return "";
}