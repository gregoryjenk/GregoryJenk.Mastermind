import { Component, EventEmitter, Input, Output } from "@angular/core";
import { WizardComponent } from "./wizard.component";

@Component({
    selector: "wizard-step",
    host: {
        "[style.display]": "current ? 'block' : 'none'",
    },
    templateUrl: "/app/templates/wizards/wizard-step.component.html",
})
export class WizardStepComponent {
    @Input() name: string = "";
    @Input() backVisible: boolean = true;
    @Input() iconClass: string;
    @Input() nextEnable: boolean = true;
    @Input() nextText: string = "Next";
    @Input() nextVisible: boolean = true;
    @Output() nextClicked = new EventEmitter();
    @Output() stepEvent = new EventEmitter();

    private step: number;

    public current: boolean = false;

    constructor(private parent: WizardComponent) {

    }

    ngOnInit() {
        this.step = this.parent.addStep(this);

        this.current = (this.step === this.parent.step);

        this.parent.stepChange.subscribe((step: number) => {
            this.current = (this.step === step);

            if (this.current) {
                this.stepEvent.emit();
            }
        });
    }
}