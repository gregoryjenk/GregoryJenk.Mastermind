import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserViewModel } from "../../ViewModels/Users/user.view-model";

@Injectable()
export class UserService {
    constructor(private readonly httpClient: HttpClient) {

    }

    public read(): Observable<UserViewModel> {
        return this.httpClient.get<UserViewModel>("api/user");
    }
}