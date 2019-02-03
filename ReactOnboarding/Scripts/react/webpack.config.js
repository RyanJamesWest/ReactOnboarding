module.exports = {
    mode: 'development',
    context: __dirname,
    entry: {
        Home: "./index.jsx",
        Customers: "./Customers/CustomerIndex.jsx",
        Sales: "./Sales/SalesIndex.jsx",
        Product: "./Products/ProductIndex.jsx",
        Stores: './Stores/StoreIndex.jsx'
    },
    output: {
        path: __dirname + "/dist",
        filename: "[name].bundle.js"
    },
    watch: true,
    module: {
        rules: [{
            test: /\.jsx?$/,
            exclude: /(node_modules)/,
            use: {
                loader: 'babel-loader',
                options: {
                    presets: ['babel-preset-env', 'babel-preset-react']
                }
            }
        }]
    }
}
