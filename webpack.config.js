const path = require('path');

const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const RemoveEmptyScriptsPlugin = require('webpack-remove-empty-scripts');
const TerserJSPlugin = require('terser-webpack-plugin');
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");


const babelLoader = () => ({
    loader: 'babel-loader',
    options: {
        presets: [['@babel/preset-env', { targets: 'last 2 versions, ie >= 10' }]],
        plugins: [
            '@babel/plugin-transform-destructuring',
            '@babel/plugin-proposal-object-rest-spread',
            '@babel/plugin-transform-template-literals',
            "@babel/plugin-proposal-class-properties"
        ],
        babelrc: false
    }
});

module.exports = (env, options) => {
    const isProduction = options.mode === "production";

    let webpackConfig = {
        module: {
            rules: [
                {
                    test: /\.tsx?$/,
                    use: 'ts-loader',
                    exclude: /node_modules/,
                },
                {
                    // Transpile sources
                    test: /\.es6$|\.js$/,
                    exclude: [path.resolve(__dirname, 'node_modules')],
                    use: [babelLoader()]
                },
                {
                    test: /\.css$/,
                    use: [
                        MiniCssExtractPlugin.loader,
                        'css-loader'
                    ]
                },
                {
                    test: /\.s[ac]ss$/i,
                    use: [
                        // Creates `style` nodes from JS strings
                        MiniCssExtractPlugin.loader,
                        // Translates CSS into CommonJS
                        "css-loader",
                        // Compiles Sass to CSS
                        "sass-loader",
                    ],
                },
            ]
        },
        resolve: {
            extensions: ['.tsx', '.ts', '.js']
        },
        optimization: {
            minimizer: [
            ],
        },
        externals: {
            jquery: 'jQuery'
        },
        plugins: [
            new RemoveEmptyScriptsPlugin(),
            new MiniCssExtractPlugin({
                filename: (pathData, assetInfo) => {
                    return pathData.chunk.filenameTemplate.replace('js', 'css');
                }
            }),
        ]
    };

    if (isProduction) {
        webpackConfig.optimization.minimizer.push(
            new TerserJSPlugin({
                terserOptions: {
                    compress: true,
                    mangle: true
                },
                test: /\.js(\?.*)?$/i,
                extractComments: "all"
            }),
            new CssMinimizerPlugin()
        );
    }


    return {
        entry: './ClientApplication/application.ts',
        output: {
            path: path.resolve(__dirname, 'wwwroot', 'locator'),
            filename: '[name].js',
        },
        ...webpackConfig
    };
}