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
        preprocessors: {
            "**/*.ts": [
                "karma-typescript"
            ]
        },
        reporters: [
            "progress",
            "karma-typescript"
        ]
    });
}