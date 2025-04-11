import { Component, Input } from "@angular/core";
import { RouterModule } from "@angular/router";
import { UserViewModel } from "../../ViewModels/Users/user.view-model";

let imports = [
    RouterModule
];

@Component({
    imports: imports,
    selector: "navigation-bar-component",
    styleUrl: "../../../wwwroot/src/styles/components/navigations/navigation-bar.component.scss",
    templateUrl: "../../../wwwroot/app/templates/components/navigations/navigation-bar.component.html"
})
export class NavigationBarComponent {
    @Input()
    public user: UserViewModel;
}