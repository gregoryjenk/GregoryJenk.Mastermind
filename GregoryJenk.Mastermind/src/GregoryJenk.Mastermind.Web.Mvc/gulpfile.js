/// <binding Clean="clean" />

var del = require("del");
var gulp = require("gulp");
var minify = require('gulp-minify');

gulp.task("clean", function () {
    return del([
        "./wwwroot/app/js/**/*"
    ]);
});

gulp.task("minify", function () {
    gulp.src("./wwwroot/app/js/*.js")
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
        .pipe(gulp.dest("./wwwroot/app/js/"))
});