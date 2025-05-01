import { Directive, ElementRef, EventEmitter, OnInit, Output } from "@angular/core";
import { GameGuessCodePegViewModel } from "../../../../ViewModels/Games/Guesses/CodePegs/game-guess-code-peg.view-model";

@Directive({
    selector: "[gameGuessCodePegDroppableDirective]"
})
export class GameGuessCodePegDroppableDirective implements OnInit {
    constructor(private readonly elementRef: ElementRef) {

    }

    @Output()
    public codePegDrop = new EventEmitter<GameGuessCodePegViewModel>();

    public ngOnInit(): void {
        let droppableElement = this.elementRef.nativeElement.querySelector(".game-guess-code-peg-component > span");

        droppableElement.classList.add("game-guess-code-peg-component__droppable");

        droppableElement.addEventListener("dragenter", this.onDragEnter);
        droppableElement.addEventListener("dragover", this.onDragOver);
        droppableElement.addEventListener("dragleave", this.onDragLeave);
        droppableElement.addEventListener("drop", this.onDrop.bind(this));
    }

    public onDragEnter(dragEvent: DragEvent): void {
        let droppableElement = dragEvent.target as HTMLElement;

        droppableElement.classList.add("game-guess-code-peg-component__droppable--active");
    }

    public onDragOver(dragEvent: DragEvent): void {
        dragEvent.dataTransfer!.dropEffect = "copy";

        dragEvent.preventDefault();
    }

    public onDragLeave(dragEvent: DragEvent): void {
        let droppableElement = dragEvent.target as HTMLElement;

        droppableElement.classList.remove("game-guess-code-peg-component__droppable--active");
    }

    public onDrop(dragEvent: DragEvent): void {
        let droppableElement = dragEvent.target as HTMLElement;

        droppableElement.classList.remove("game-guess-code-peg-component__droppable--active");

        let codePegJson = dragEvent.dataTransfer!.getData("application/json");

        let codePeg = JSON.parse(codePegJson) as GameGuessCodePegViewModel;

        this.codePegDrop.emit(codePeg);

        dragEvent.stopPropagation();
    }
}