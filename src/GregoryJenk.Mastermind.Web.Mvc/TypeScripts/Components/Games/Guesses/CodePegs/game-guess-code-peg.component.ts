import { Component, Input } from "@angular/core";
import { GameCodePegColour } from "../../../../Models/Games/CodePegs/game-code-peg-colour";
import { GameGuessCodePegViewModel } from "../../../../ViewModels/Games/Guesses/CodePegs/game-guess-code-peg.view-model";

@Component({
    selector: "game-guess-code-peg-component",
    styleUrl: "../../../../../wwwroot/src/styles/components/games/guesses/code-pegs/game-guess-code-peg.component.scss",
    templateUrl: "../../../../../wwwroot/app/templates/components/games/guesses/code-pegs/game-guess-code-peg.component.html"
})
export class GameGuessCodePegComponent {
    @Input()
    public codePeg: GameGuessCodePegViewModel;

    public readColourClass(gameCodePegColour: GameCodePegColour): string {
        let colourClass: string;

        switch (gameCodePegColour) {
            case GameCodePegColour.None: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--none";

                break;
            }
            case GameCodePegColour.Blue: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--blue";

                break;
            }
            case GameCodePegColour.Green: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--green";

                break;
            }
            case GameCodePegColour.Orange: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--orange";

                break;
            }
            case GameCodePegColour.Purple: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--purple";

                break;
            }
            case GameCodePegColour.Red: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--red";

                break;
            }
            case GameCodePegColour.Yellow: {
                colourClass = "game-guess-code-peg-component__code-peg-colour--yellow";

                break;
            }
            default: {
                throw new TypeError(`Colour not supported with ${gameCodePegColour}.`);
            }
        }

        return colourClass;
    }
}