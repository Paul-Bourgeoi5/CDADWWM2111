// importer le module express
const express = require('express');
const bodyParser = require('body-parser')

// application express
const app = express();


// body parser (analyse le contenu du corps des requêtes)
app.use(bodyParser.urlencoded())
//app.use(bodyParser.json())


// middleware : s'exécute à chaque requête
app.use((req, res, next) => {
    let method = req.method;
    let path = req.originalUrl;
    console.log(`${method} ${path}`);
    next()
})


// middleware, s'execute pour les requêtes dont le chemin commence par /public
// gestion des fichiers statiques
app.use('/public', express.static(__dirname + '/public'))


require('./middlewares/liquid')(app)


// import des routes (voir le fichier routes/index.js)
const router = require('./routes')
// association du router à l'app
app.use('/', router)

// démarrage du serveur
app.listen(8000, () => {
    console.log("Serveur prêt (http://localhost)")
});

