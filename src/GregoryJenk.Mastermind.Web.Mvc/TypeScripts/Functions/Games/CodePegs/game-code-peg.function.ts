import { GameCodePegColour } from "../../../Models/Games/CodePegs/game-code-peg-colour";

export function readColourName(gameCodePegColour: GameCodePegColour): string {
    let colourName: string;

    switch (gameCodePegColour) {
        case GameCodePegColour.None: {
            colourName = "None";

            break;
        }
        case GameCodePegColour.Blue: {
            colourName = "Blue";

            break;
        }
        case GameCodePegColour.Green: {
            colourName = "Green";

            break;
        }
        case GameCodePegColour.Orange: {
            colourName = "Orange";

            break;
        }
        case GameCodePegColour.Purple: {
            colourName = "Purple";

            break;
        }
        case GameCodePegColour.Red: {
            colourName = "Red";

            break;
        }
        case GameCodePegColour.Yellow: {
            colourName = "Yellow";

            break;
        }
        default: {
            throw new TypeError(`Colour not supported with ${gameCodePegColour}.`);
        }
    }

    return colourName;
}