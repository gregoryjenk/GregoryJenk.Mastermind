import { Component, Input } from "@angular/core";
import { GameCodePegColour } from "../../../Models/Games/CodePegs/game-code-peg-colour";
import { GameCodePegViewModel } from "../../../ViewModels/Games/CodePegs/game-code-peg.view-model";

@Component({
    selector: "game-code-peg-component",
    styleUrl: "../../../../wwwroot/src/styles/components/games/code-pegs/game-code-peg.component.scss",
    templateUrl: "../../../../wwwroot/app/templates/components/games/code-pegs/game-code-peg.component.html"
})
export class GameCodePegComponent {
    @Input()
    public codePeg: GameCodePegViewModel;

    public readColourClass(gameCodePegColour: GameCodePegColour): string {
        let colourClass: string;

        switch (gameCodePegColour) {
            case GameCodePegColour.None: {
                colourClass = "game-code-peg-component__code-peg-colour--none";

                break;
            }
            case GameCodePegColour.Blue: {
                colourClass = "game-code-peg-component__code-peg-colour--blue";

                break;
            }
            case GameCodePegColour.Green: {
                colourClass = "game-code-peg-component__code-peg-colour--green";

                break;
            }
            case GameCodePegColour.Orange: {
                colourClass = "game-code-peg-component__code-peg-colour--orange";

                break;
            }
            case GameCodePegColour.Purple: {
                colourClass = "game-code-peg-component__code-peg-colour--purple";

                break;
            }
            case GameCodePegColour.Red: {
                colourClass = "game-code-peg-component__code-peg-colour--red";

                break;
            }
            case GameCodePegColour.Yellow: {
                colourClass = "game-code-peg-component__code-peg-colour--yellow";

                break;
            }
            default: {
                throw new TypeError(`Colour not supported with ${gameCodePegColour}.`);
            }
        }

        return colourClass;
    }
}