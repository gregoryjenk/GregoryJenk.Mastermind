import { Directive, ElementRef, EventEmitter, OnInit, Output } from "@angular/core";

@Directive({
    selector: "[peg-code-droppable]"
})
export class PegCodeDroppableDirective implements OnInit {
    @Output() pegCodeDropped = new EventEmitter();

    constructor(private _elementRef: ElementRef) {

    }

    public ngOnInit() {
        let el = this._elementRef.nativeElement;

        el.addEventListener("dragenter", (e: any) => {
            el.classList.add("over");
        });

        el.addEventListener("dragleave", (e: any) => {
            el.classList.remove("over");
        });

        el.addEventListener("dragover", (e: any) => {
            if (e.preventDefault) {
                e.preventDefault();
            }

            e.dataTransfer.dropEffect = "move";

            return false;
        });

        el.addEventListener("drop", (e: any) => {
            if (e.stopPropagation) {
                e.stopPropagation();
            }

            el.classList.remove("over");

            let data = JSON.parse(e.dataTransfer.getData("value"));

            this.pegCodeDropped.emit(data);

            return false;
        })
    }
}