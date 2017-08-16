import { CodePeg } from "../../Models/Pegs/code-peg.model";
import { Component, Input } from "@angular/core";

@Component({
    selector: "peg-code",
    templateUrl: "/app/templates/components/pegs/peg-code.component.html"
})
export class PegCodeComponent {
    @Input() pegCode: CodePeg;

    constructor() {

    }

    private readColourClass(colour: CodePegColour): string {
        let colourClass: string;

        switch (colour) {
            case CodePegColour.Locked:
                colourClass = "peg-code__locked";
                break;
            case CodePegColour.Blue:
                colourClass = "peg-code__blue";
                break;
            case CodePegColour.Green:
                colourClass = "peg-code__green";
                break;
            case CodePegColour.Orange:
                colourClass = "peg-code__orange";
                break;
            case CodePegColour.Purple:
                colourClass = "peg-code__purple";
                break;
            case CodePegColour.Red:
                colourClass = "peg-code__red";
                break;
            case CodePegColour.Yellow:
                colourClass = "peg-code__yellow";
                break;
            case CodePegColour.Empty:
                colourClass = "peg-code__empty";
                break;
            default:
                throw new TypeError("No matching colour found");
        }

        return colourClass;
    }
}