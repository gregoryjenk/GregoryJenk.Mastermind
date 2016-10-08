import { Component, Input } from "@angular/core";

@Component({
    selector: "peg-code",
    templateUrl: "/app/templates/pegs/peg-code.component.html"
})
export class PegCodeComponent {
    @Input() colour: Colour;

    constructor() {

    }

    private readColourClass(colour: Colour): string {
        let colourClass: string;

        switch (colour) {
            case Colour.Blue:
                colourClass = "peg-code__blue";
                break;
            case Colour.Green:
                colourClass = "peg-code__green";
                break;
            case Colour.Orange:
                colourClass = "peg-code__orange";
                break;
            case Colour.Purple:
                colourClass = "peg-code__purple";
                break;
            case Colour.Red:
                colourClass = "peg-code__red";
                break;
            case Colour.Yellow:
                colourClass = "peg-code__yellow";
                break;
            default:
                throw new TypeError("No matching colour found");
        }

        return colourClass;
    }
}