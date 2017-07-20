var path = require("path");

module.exports = {
    entry: {
        app: "./TypeScripts/app.main.ts",
        sec: "./TypeScripts/sec.main.ts"
    },
    module: {
        //TODO: Look at why there is a context critical warning.
        exprContextCritical: false,
        loaders: [
            {
                include: [/TypeScripts/],
                loader: "ts-loader",
                query: {
                    silent: true
                },
                test: /\.ts$/
            },
            {
                loader: "raw",
                test: /\.html$/
            },
            {
                loader: "to-string!css",
                test: /\.css$/
            },
            {
                loader: "url",
                query: {
                    limit: 25000
                },
                test: /\.(png|jpg|jpeg|gif|svg)$/
            },
            {
                exclude: /node_modules/,
                loaders: ["raw-loader", "sass-loader"],
                test: /\.scss$/
            }
        ]
    },
    output: {
        filename: "[name].js",
        path: path.resolve(__dirname, "wwwroot/app/js")
    },
    resolve: {
        extensions: [".js", ".ts"]
    }
};