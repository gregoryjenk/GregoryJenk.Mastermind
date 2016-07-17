/// <binding AfterBuild="default" Clean="clean" />

var gulp = require("gulp");
var del = require("del");

var paths = {
    scripts: [
        "wwwroot/**/*.js",
        "wwwroot/**/*.ts",
        "wwwroot/**/*.map"
    ]
};

gulp.task("clean", function () {
    return del([
        "wwwroot/app/js/**/*"
    ]);
});

gulp.task("default", function () {
    gulp.src(paths.scripts).pipe(gulp.dest("wwwroot/app/js/"));
});