import { Directive, ElementRef, Input, OnInit } from "@angular/core";
import { GameGuessCodePegViewModel } from "../../../../ViewModels/Games/Guesses/CodePegs/game-guess-code-peg.view-model";

@Directive({
    selector: "[gameGuessCodePegDraggableDirective]"
})
export class GameGuessCodePegDraggableDirective implements OnInit {
    constructor(private readonly elementRef: ElementRef) {

    }

    @Input()
    public codePeg: GameGuessCodePegViewModel;

    public ngOnInit(): void {
        let draggableElement = this.elementRef.nativeElement.querySelector(".game-guess-code-peg-component > span");

        draggableElement.classList.add("game-guess-code-peg-component__draggable");

        draggableElement.draggable = true;

        draggableElement.addEventListener("dragstart", this.onDragStart.bind(this));
        draggableElement.addEventListener("dragend", this.onDragEnd);
    }

    public onDragStart(dragEvent: DragEvent): void {
        let draggableElement = dragEvent.target as HTMLElement;

        draggableElement.classList.add("game-guess-code-peg-component__draggable--active");

        let codePegJson = JSON.stringify(this.codePeg);

        dragEvent.dataTransfer!.effectAllowed = "copy";

        dragEvent.dataTransfer!.setData("application/json", codePegJson);
    }

    public onDragEnd(dragEvent: DragEvent): void {
        let draggableElement = dragEvent.target as HTMLElement;

        draggableElement.classList.remove("game-guess-code-peg-component__draggable--active");
    }
}