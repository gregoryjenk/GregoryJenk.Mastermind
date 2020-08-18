import { Component, Input } from "@angular/core";

@Component({
    selector: "game-state",
    templateUrl: "/app/templates/components/games/states/game-state.component.html"
})
export class GameStateComponent {
    @Input() gameState: GameState;

    constructor() {

    }

    private readGameStateClass(): string {
        let gameStateClass: string;

        switch (this.gameState) {
            case GameState.Created:
                gameStateClass = "game-state__created";
                break;
            case GameState.Started:
                gameStateClass = "game-state__started";
                break;
            case GameState.Ended:
                gameStateClass = "game-state__ended";
                break;
            case GameState.Matched:
                gameStateClass = "game-state__matched";
                break;
            default:
                gameStateClass = "game-state__unknown";
                break;
                //The issue with throwing an exception is when components are still
                //loading the game state.
                //throw new TypeError("No matching game state found");
        }

        return gameStateClass;
    }

    private readGameStateTitle(): string {
        let gameStateName: string;

        switch (this.gameState) {
            case GameState.Created:
                gameStateName = "Created";
                break;
            case GameState.Started:
                gameStateName = "Started";
                break;
            case GameState.Ended:
                gameStateName = "Ended";
                break;
            case GameState.Matched:
                gameStateName = "Matched";
                break;
            default:
                gameStateName = "Unknown";
                break;
                //The issue with throwing an exception is when components are still
                //loading the game state.
                //throw new TypeError("No matching game state found");
        }

        return gameStateName;
    }
}