import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { BaseService } from "../base.service";
import { User } from "../../Models/Users/user.model";

@Injectable()
export class UserService extends BaseService {
    private userUrl = "api/user";

    constructor(private http: Http) {
        super();
    }

    public read(): Observable<User> {
        return this.http.get(this.userUrl)
            .map(this.convertResponseToObject);
    }
}