export default config => {
    config.set({
        autoWatch: true,
        browsers: [
            "PhantomJS"
        ],
        files: [
            {
                pattern: "TypeScripts/**/*.ts"
            }
        ],
        frameworks: [
            "jasmine",
            "karma-typescript"
        ],
        phantomjsLauncher: {
            exitOnResourceError: true
        },
        plugins: [
            "karma-jasmine",
            "karma-phantomjs-launcher",
            "karma-spec-reporter",
            "karma-typescript"
        ],
        preprocessors: {
            "**/*.ts": [
                "karma-typescript"
            ]
        },
        reporters: [
            "dots",
            "karma-typescript",
            "progress",
            "spec"
        ],
        specReporter: {
            failFast: true,
            showSpecTiming: true,
            suppressErrorSummary: true,
            suppressFailed: false,
            suppressPassed: false,
            suppressSkipped: false
        }
    });
}