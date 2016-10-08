import { Component, Input } from "@angular/core";

@Component({
    selector: "peg-code",
    templateUrl: "/app/templates/pegs/peg-code.component.html"
})
export class PegCodeComponent {
    @Input() colour: Colour;

    constructor() {

    }
}