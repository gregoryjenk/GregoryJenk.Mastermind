interface String {
    isNullOrEmpty: () => boolean;
}

String.prototype.isNullOrEmpty = function () {
    return this == null || this == undefined || this == "";
};