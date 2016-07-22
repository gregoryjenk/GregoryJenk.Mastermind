/// <binding BeforeBuild="lib" Clean="clean" />

var del = require("del");
var gulp = require("gulp");
var minify = require("gulp-minify");

var paths = {
    lib: [
        //"./node_modules/angular2/bundles/angular2.js",
        //"./node_modules/angular2/bundles/angular2-polyfills.js",
        //"./node_modules/systemjs/dist/system.src.js",
        //"./node_modules/rxjs/bundles/Rx.js"
    ]
};

gulp.task("clean", function () {
    return del([
        "./wwwroot/app/js/**/*",
        "./wwwroot/lib/**/*"
    ]);
});

gulp.task("lib", function () {
    gulp.src(paths.lib).pipe(gulp.dest("./wwwroot/lib/"));
});

gulp.task("minify", function () {
    gulp.src("./wwwroot/app/js/**/*.js")
        .pipe(minify({
            ext: {
                src: ".js",
                min: ".min.js"
            },
            exclude: [ "tasks" ],
            ignoreFiles: [
                ".combo.js",
                "-min.js"
            ]
        }))
        .pipe(gulp.dest("./wwwroot/app/js/"));
});