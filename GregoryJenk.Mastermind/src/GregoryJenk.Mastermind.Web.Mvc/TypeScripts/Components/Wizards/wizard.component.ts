import { Component, EventEmitter, Input, Output } from "@angular/core";
import { WizardStepComponent } from "./wizard-step.component";

@Component({
    selector: "wizard",
    templateUrl: "/app/templates/components/wizards/wizard.component.html",
})
export class WizardComponent {
    @Input() completeText: string = "Done";
    @Input() step: number = 1;
    @Output() completed = new EventEmitter();
    @Output() stepChange = new EventEmitter();

    private nextText: string = "Next";
    private steps: WizardStepComponent[] = [];

    constructor() {

    }

    public addStep(wizardStep: WizardStepComponent) {
        const addedStepNumber = this.steps.length + 1;

        this.steps.push(wizardStep);

        return addedStepNumber;
    }

    public backStepVisible() {
        var currentWizardStep: WizardStepComponent = this.steps.find(x => x.current == true);

        return !(this.step === 1) && (currentWizardStep.backVisible == true);
    }

    public backStep() {
        this.stepChange.emit(this.step - 1);

        this.nextStepText();
    }

    public nextStepEnable() {
        var currentWizardStep: WizardStepComponent = this.steps.find(x => x.current == true);

        return (currentWizardStep.nextEnable == true);
    }

    public nextStepText() {
        var currentWizardStep: WizardStepComponent = this.steps.find(x => x.current == true);

        this.nextText = currentWizardStep.nextText;
    }

    public nextStepVisible() {
        var currentWizardStep: WizardStepComponent = this.steps.find(x => x.current == true);

        return !(this.step === this.steps.length) && (currentWizardStep.nextVisible == true);
    }

    public nextStep() {
        if (this.nextStepEnable()) {
            var currentWizardStep: WizardStepComponent = this.steps.find(x => x.current == true);

            currentWizardStep.nextClicked.emit();

            this.stepChange.emit(this.step + 1);

            this.nextStepText();
        }
    }

    public completeVisible() {
        return this.step === this.steps.length;
    }

    public complete() {
        this.completed.emit()
    }
}