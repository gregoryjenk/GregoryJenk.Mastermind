var path = require("path");
var webpack = require("webpack");

module.exports = {
    entry: {
        app: "./TypeScripts/app.main.ts",
        sec: "./TypeScripts/sec.main.ts"
    },
    module: {
        exprContextCritical: true,
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
    plugins: [
        new webpack.ContextReplacementPlugin(
            /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
            __dirname
        )
    ],
    resolve: {
        extensions: [".js", ".ts"]
    }
};