import { BaseEntityViewModel } from "../base-entity.view-model";

export class UserViewModel extends BaseEntityViewModel<string> {
    public name: string;

    public email: string;

    public scheme: string;

    public image: string;

    public externalId: string;
}