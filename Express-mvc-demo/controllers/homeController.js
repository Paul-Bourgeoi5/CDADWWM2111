/**
 * GET /
 * Accueil
 * @param {Request} req 
 * @param {Response} res 
 */
exports.index = (req, res) => {
    res.redirect('/candidates')
}

/**
 * GET /about
 * A propos
 * @param {Request} req 
 * @param {Response} res 
 */
exports.about = (req, res) => {
    res.send('A Propos')
}

/**
 * GET /hello/:name
 * Affiche le prénom saisi dans l'url
 * @param {Request} req 
 * @param {Response} res 
 */
exports.sayHello = (req, res) => {
    let name = req.params.name
    console.log(req.params);
    res.send(`Bonjour ${name}`)
}