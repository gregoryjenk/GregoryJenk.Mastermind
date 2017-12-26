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
                throw new TypeError("No matching game state found");
        }

        return gameStateClass;
    }
}