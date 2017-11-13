import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { BaseService } from "../base.service";
import { User } from "../../Models/Users/user.model";

@Injectable()
export class UserService extends BaseService {
    private userUrl = "api/user";

    constructor(private httpClient: HttpClient) {
        super();
    }

    public read(): Observable<User> {
        return this.httpClient.get(this.userUrl)
            .map(this.convertResponseToObject);
    }
}