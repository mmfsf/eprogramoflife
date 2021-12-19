"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AuthToken = void 0;
var AuthToken = /** @class */ (function () {
    function AuthToken() {
    }
    AuthToken.Set = function (token) {
        localStorage.setItem("epl_token", JSON.stringify(token));
    };
    AuthToken.GetToken = function () {
        var token = JSON.parse(String(localStorage.getItem("epl_token")));
        return token;
    };
    AuthToken.ClearToken = function () {
        localStorage.clear();
    };
    AuthToken.isLoggedIn = function () {
        return true;
    };
    return AuthToken;
}());
exports.AuthToken = AuthToken;
//# sourceMappingURL=auth.token.js.map