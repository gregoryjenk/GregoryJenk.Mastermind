import { Component, Input } from "@angular/core";
import { GameState } from "../../../Models/Games/States/game-state";

@Component({
    selector: "game-state-component",
    styleUrl: "../../../../wwwroot/src/styles/components/games/states/game-state.component.scss",
    templateUrl: "../../../../wwwroot/app/templates/components/games/states/game-state.component.html"
})
export class GameStateComponent {
    @Input()
    public state: GameState;

    public readStateClass(gameState: GameState): string {
        let stateClass: string;

        switch (gameState) {
            case GameState.Created: {
                stateClass = "game-state-component__state--created";

                break;
            }
            case GameState.Started: {
                stateClass = "game-state-component__state--started";

                break;
            }
            case GameState.Ended: {
                stateClass = "game-state-component__state--ended";

                break;
            }
            case GameState.Matched: {
                stateClass = "game-state-component__state--matched";

                break;
            }
            //default: {
            //    throw new TypeError(`State not supported with ${gameState}.`);
            //}
        }

        return stateClass;
    }

    public readStateName(gameState: GameState): string {
        let stateName: string;

        switch (gameState) {
            case GameState.Created: {
                stateName = "Created";

                break;
            }
            case GameState.Started: {
                stateName = "Started";

                break;
            }
            case GameState.Ended: {
                stateName = "Ended";

                break;
            }
            case GameState.Matched: {
                stateName = "Matched";

                break;
            }
            //default: {
            //    throw new TypeError(`State not supported with ${gameState}.`);
            //}
        }

        return stateName;
    }
}