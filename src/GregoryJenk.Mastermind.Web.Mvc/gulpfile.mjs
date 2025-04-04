﻿/// <binding BeforeBuild="default" Clean="cleanAsync" />

import { deleteAsync } from "del";
import { dest, series, src, watch } from "gulp";
import cleanCss from "gulp-clean-css";
import rename from "gulp-rename";
import sassFactory from "gulp-sass";
import sourceMaps from "gulp-sourcemaps";
import * as sassCompiler from "sass";

const paths = {
    nodeModules: [
        "./node_modules/@gregoryjenk/aesthetic-default/dist/css/**/*",
        "./node_modules/@gregoryjenk/aesthetic-default/dist/fonts/**/*",
        "./node_modules/@gregoryjenk/aesthetic-default/dist/images/**/*",
        "./node_modules/animate.css/animate.min.css",
        "./node_modules/bootstrap/dist/css/bootstrap.min.css",
        "./node_modules/bootstrap/dist/js/bootstrap.bundle.min.js",
        "./node_modules/bootstrap-icons/font/bootstrap-icons.min.css",
        "./node_modules/bootstrap-icons/font/fonts/**/*"
    ],
    source: {
        scss: [
            "./wwwroot/src/scss/layout.scss"
        ]
    }
};

export async function cleanAsync() {
    return await deleteAsync([
        "./wwwroot/app/css",
        "./wwwroot/app/js",
        "./wwwroot/lib"
    ]);
}

export async function cleanCssAsync() {
    return await deleteAsync([
        "./wwwroot/app/css"
    ]);
}

export function copyLibraries() {
    let srcOptions = {
        base: "./node_modules",
        encoding: false
    };

    return src(paths.nodeModules, srcOptions)
        .pipe(dest("./wwwroot/lib"));
}

export function compileSass() {
    let sass = sassFactory(sassCompiler);

    return src(paths.source.scss)
        .pipe(sass().on("error", sass.logError))
        .pipe(dest("./wwwroot/app/css"));
}

export function minimiseCss() {
    let renameOptions = {
        suffix: ".min"
    };

    return src("./wwwroot/app/css/**/*.css")
        .pipe(sourceMaps.init())
        .pipe(cleanCss())
        .pipe(rename(renameOptions))
        .pipe(sourceMaps.write("."))
        .pipe(dest("./wwwroot/app/css"));
}

export function watchSass() {
    watch(paths.source.scss, series(cleanCssAsync, compileSass, minimiseCss));
}

export default series(cleanAsync, copyLibraries, compileSass, minimiseCss);