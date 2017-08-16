import { Directive, ElementRef, Input, OnInit } from "@angular/core";
import { CodePeg } from "../../Models/Pegs/code-peg.model";

@Directive({
    selector: "[peg-code-draggable]"
})
export class PegCodeDraggableDirective implements OnInit {
    @Input("peg-code-draggable") pegCode: CodePeg;

    constructor(private elementRef: ElementRef) {

    }

    public ngOnInit() {
        let el = this.elementRef.nativeElement.querySelector("span");

        el.draggable = true;

        el.addEventListener("dragstart", (e: any) => {
            el.classList.add("peg-code__dragging")
            e.dataTransfer.effectAllowed = "move";
            e.dataTransfer.setData("value", JSON.stringify(this.pegCode));
        });

        el.addEventListener("dragend", (e: any) => {
            e.preventDefault();
            el.classList.remove("peg-code__dragging")
        });
    }
}