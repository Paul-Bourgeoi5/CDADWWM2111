const { Liquid } = require('liquidjs')
const path = require('path')


module.exports = (app) => {
    const viewEngine = new Liquid({
        root: path.join(__dirname, '../', 'views'),
        extname: '.html'
    })

    app.engine('html', viewEngine.express())

    app.set('view engine', 'html')
}