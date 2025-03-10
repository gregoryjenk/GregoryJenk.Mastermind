import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { AuthenticationStoreStrategyItem } from "./authentication-store.strategy-item";
import { AuthenticationStrategyConstant } from "./authentication.strategy-constant";

@Injectable()
export class AuthenticationStoreCookieStrategy {
    constructor(private readonly cookieService: CookieService) {

    }

    public get(): AuthenticationStoreStrategyItem {
        let authenticationStoreStrategyItem = new AuthenticationStoreStrategyItem();

        authenticationStoreStrategyItem.scheme = this.cookieService.get(AuthenticationStrategyConstant.SCHEME_KEY);
        authenticationStoreStrategyItem.token = this.cookieService.get(AuthenticationStrategyConstant.TOKEN_KEY);

        return authenticationStoreStrategyItem;
    }
}