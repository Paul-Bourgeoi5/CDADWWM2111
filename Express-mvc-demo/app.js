// importer le module express
const express = require('express');
const bodyParser = require('body-parser')

// application express
const app = express();

// import des modules pour parser les cookies et créer des cookies de session
const cookieParser = require('cookie-parser')
const cookieSession = require('cookie-session')


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

app.use(cookieParser())
// création d'un cookie de session
app.use(cookieSession({
    name: 'session',                              // name of the cookie
    secret: 'MAKE_THIS_SECRET_SUPER_SECUR',       // key to encode session
    maxAge: 1000*10,                              // cookie's lifespan
    sameSite: 'strict',                           // controls when cookies are sent
    path: '/',                                    // explicitly set this for security purposes
    secure: process.env.NODE_ENV === 'production',// cookie only sent on HTTPS
    httpOnly: true                                // cookie is not available to JavaScript (client)
  }));

require('./middlewares/liquid')(app)


// import des routes (voir le fichier routes/index.js)
const router = require('./routes')
// association du router à l'app
app.use('/', router)

// démarrage du serveur
app.listen(8000, () => {
    console.log("Serveur prêt (http://localhost)")
});

