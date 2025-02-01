/// <binding BeforeBuild="default" Clean="clean" />
//TODO: Review file.
var del = require("del");
var gulp = require("gulp");
var cleanCSS = require("gulp-clean-css");
var rename = require("gulp-rename");
var sass = require("gulp-sass")(require("sass"));
var sourcemaps = require("gulp-sourcemaps");

var paths = {
    lib: [
        "./node_modules/animate.css/animate.min.css",
        "./node_modules/bootstrap/dist/css/bootstrap.min.css",
        "./node_modules/bootstrap/dist/js/bootstrap.bundle.min.js",
        "./node_modules/bootstrap-icons/font/bootstrap-icons.min.css",
        "./node_modules/bootstrap-icons/font/fonts/**/*"
    ],
    sass: [
        "./wwwroot/src/scss/app.scss",
        "./wwwroot/src/scss/layout.scss"
    ]
};

gulp.task("clean", function () {
    return del([
        "./wwwroot/app/css",
        "./wwwroot/app/js",
        "./wwwroot/lib"
    ]);
});

gulp.task("clean-css", function () {
    return del([
        "./wwwroot/app/css/"
    ]);
});

gulp.task("lib", function () {
    return gulp.src(paths.lib, { base: "node_modules" })
        .pipe(gulp.dest("./wwwroot/lib/"));
});

gulp.task("min-css", function () {
    return gulp.src("./wwwroot/app/css/**/*.css")
        //.pipe(sourcemaps.init())
        .pipe(cleanCSS())
        //.pipe(sourcemaps.write())
        .pipe(rename({
            suffix: ".min"
        }))
        .pipe(gulp.dest("./wwwroot/app/css/"));
});

gulp.task("sass", function () {
    return gulp.src(paths.sass)
        //.pipe(sourcemaps.init())
        .pipe(sass().on("error", sass.logError))
        //.pipe(sourcemaps.write())
        .pipe(gulp.dest("./wwwroot/app/css/"));
});

gulp.task("watch-sass", function () {
    return gulp.watch("./wwwroot/src/scss/**/*", gulp.series("clean-css", "sass", "min-css"));
});

gulp.task("default", gulp.series("clean", "lib", "sass", "min-css"));