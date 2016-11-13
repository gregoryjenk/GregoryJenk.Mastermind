import { Component, Input } from "@angular/core";
import { PegCode } from "../../Models/Pegs/peg-code.model";

@Component({
    selector: "peg-code",
    templateUrl: "/app/templates/pegs/peg-code.component.html"
})
export class PegCodeComponent {
    @Input() pegCode: PegCode;

    constructor() {

    }

    private readColourClass(colour: PegCodeColour): string {
        let colourClass: string;

        switch (colour) {
            case PegCodeColour.Blue:
                colourClass = "peg-code__blue";
                break;
            case PegCodeColour.Green:
                colourClass = "peg-code__green";
                break;
            case PegCodeColour.Orange:
                colourClass = "peg-code__orange";
                break;
            case PegCodeColour.Purple:
                colourClass = "peg-code__purple";
                break;
            case PegCodeColour.Red:
                colourClass = "peg-code__red";
                break;
            case PegCodeColour.Yellow:
                colourClass = "peg-code__yellow";
                break;
            case PegCodeColour.Empty:
                colourClass = "peg-code__empty";
                break;
            default:
                throw new TypeError("No matching colour found");
        }

        return colourClass;
    }
}