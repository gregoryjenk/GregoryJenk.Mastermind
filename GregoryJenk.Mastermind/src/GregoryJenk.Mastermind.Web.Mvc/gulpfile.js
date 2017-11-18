/// <binding BeforeBuild="less, lib, webpack" Clean="clean" />

var del = require("del");
var gulp = require("gulp");
var less = require("gulp-less");
var minify = require("gulp-minify");
var typeScript = require("gulp-typescript");
var typeScriptProject = typeScript.createProject("tsconfig.json");
var webpack = require("webpack");
var webpackConfig = require("./webpack.config.js");

var paths = {
    lib: [
        {
            src: "./node_modules/@angular/common/bundles/common.umd.js",
            dest: "./wwwroot/lib/@angular/common/bundles/"
        },
        {
            src: "./node_modules/@angular/compiler/bundles/compiler.umd.js",
            dest: "./wwwroot/lib/@angular/compiler/bundles/"
        },
        {
            src: "./node_modules/@angular/core/bundles/core.umd.js",
            dest: "./wwwroot/lib/@angular/core/bundles/"
        },
        {
            src: "./node_modules/@angular/forms/bundles/forms.umd.js",
            dest: "./wwwroot/lib/@angular/forms/bundles/"
        },
        {
            src: "./node_modules/@angular/http/bundles/http.umd.js",
            dest: "./wwwroot/lib/@angular/http/bundles/"
        },
        {
            src: "./node_modules/@angular/platform-browser/bundles/platform-browser.umd.js",
            dest: "./wwwroot/lib/@angular/platform-browser/bundles/"
        },
        {
            src: "./node_modules/@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js",
            dest: "./wwwroot/lib/@angular/platform-browser-dynamic/bundles/"
        },
        {
            src: "./node_modules/@angular/router/bundles/router.umd.js",
            dest: "./wwwroot/lib/@angular/router/bundles/"
        },
        {
            src: "./node_modules/animate.css/animate.min.css",
            dest: "./wwwroot/lib/animate.css/"
        },
        {
            src: "./node_modules/bootstrap/dist/css/bootstrap.min.css",
            dest: "./wwwroot/lib/bootstrap/dist/css/"
        },
        {
            src: "./node_modules/bootstrap/dist/js/bootstrap.min.js",
            dest: "./wwwroot/lib/bootstrap/dist/js/"
        },
        {
            src: "./node_modules/chart.js/dist/**/*.js",
            dest: "./wwwroot/lib/chart.js/dist/"
        },
        {
            src: "./node_modules/core-js/client/shim.min.js",
            dest: "./wwwroot/lib/core-js/client/"
        },
        {
            src: "./node_modules/font-awesome/css/font-awesome.css",
            dest: "./wwwroot/lib/font-awesome/css/"
        },
        {
            src: "./node_modules/font-awesome/fonts/*",
            dest: "./wwwroot/lib/font-awesome/fonts/"
        },
        {
            src: "./node_modules/jquery/dist/jquery.min.js",
            dest: "./wwwroot/lib/jquery/dist/"
        },
        {
            src: "./node_modules/moment/moment.js",
            dest: "./wwwroot/lib/moment/"
        },
        {
            src: "./node_modules/ng2-charts/ng2-charts.js",
            dest: "./wwwroot/lib/ng2-charts/"
        },
        {
            src: "./node_modules/ng2-charts/components/charts/charts.js",
            dest: "./wwwroot/lib/ng2-charts/components/charts/"
        },
        {
            src: "./node_modules/reflect-metadata/Reflect.js",
            dest: "./wwwroot/lib/reflect-metadata/"
        },
        {
            src: "./node_modules/rxjs/**/*.js",
            dest: "./wwwroot/lib/rxjs/"
        },
        {
            src: "./node_modules/systemjs/dist/system.src.js",
            dest: "./wwwroot/lib/systemjs/dist/"
        },
        {
            src: "./node_modules/zone.js/dist/zone.js",
            dest: "./wwwroot/lib/zone.js/dist/"
        }
    ]
};

gulp.task("clean", function () {
    return del([
        "./wwwroot/app/css/**/*",
        "./wwwroot/app/js/**/*",
        "./wwwroot/lib/**/*"
    ]);
});

gulp.task("less", function () {
    return gulp.src("./wwwroot/app/less/**/*.less")
        .pipe(less())
        .pipe(gulp.dest("./wwwroot/app/css"));
});

gulp.task("lib", function () {
    for (var i = 0; i < paths.lib.length; i++) {
        gulp.src(paths.lib[i].src).pipe(gulp.dest(paths.lib[i].dest));
    }
});

gulp.task("minify", function () {
    gulp.src("./wwwroot/app/js/**/*.js")
        .pipe(minify({
            ext: {
                src: ".js",
                min: ".min.js"
            },
            exclude: ["tasks"],
            ignoreFiles: [
                ".combo.js",
                "-min.js"
            ]
        }))
        .pipe(gulp.dest("./wwwroot/app/js/"));
});

gulp.task("typescript", function () {
    return typeScriptProject.src()
        .pipe(typeScriptProject())
        .js.pipe(gulp.dest(typeScriptProject.config.compilerOptions.outDir));
});

gulp.task("watch-less", function () {
    return gulp.watch("./wwwroot/app/less/**/*", ["less"]);
});

gulp.task("watch-webpack", function () {
    return gulp.watch("./Typescripts/**/*", ["webpack"]);
});

gulp.task("webpack", function () {
    return webpack(webpackConfig).run(function (done) {
        if (done) {
            done();
        }
    });
});