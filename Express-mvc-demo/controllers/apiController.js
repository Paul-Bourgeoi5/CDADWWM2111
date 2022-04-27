const repository = require('../db/candidatesRepository')

/**
 * GET /api
 * Affiche la liste des candidats
 * @param {Request} req 
 * @param {Response} res 
 */
exports.index = async (req, res) => {

    /* repository.getAll().then(result => res.json(result)).catch(err => { console.error(err) }) */

    try {
        let result = await repository.getAll()
        res.json(result)

    } catch(err) {
        console.error(err)
        res.status(500).end()
    }
}

/**
 * GET /api/:id
 * Affiche un candidat ou erreur 404 si identifiant inexistant
 * @param {Request} req 
 * @param {Response} res 
 */
exports.getById = async (req, res) => {
    try {
        //const id = req.params.id
        const { id } = req.params
        let result = await repository.getById(id)

        if(result === undefined) {
            res.status(404).json({error: "404"})
        }

        res.json(result)
    } catch(err) {
        console.error(err)
        res.status(500).end()
    }
}

/**
 * POST /api
 * Ajoute un candidat 
 * @param {Request} req 
 * @param {Response} res 
 */
exports.add = async (req, res) => {
    console.log(req.body)
    const model = req.body // nécessite body-parser (inclus dans app.js)
    
    // TODO: contrôle de saisie dans l'objet model
    
    let result = await repository.create(model)
    res.status(201).json(result)
}

/**
 * PUT /api/:id
 * Modifie un candidat 
 * @param {Request} req 
 * @param {Response} res 
 */
 exports.update = async (req, res) => {
    console.log(req.body)
    const model = req.body // nécessite body-parser (inclus dans app.js)

    model.id = req.params.id
    
    // TODO: contrôle de saisie dans l'objet model
    
    let result = await repository.update(model)
    res.status(202).json(result)
}

/**
 * DELETE /api/:id
 * Supprime un candidat
 * @param {Request} req 
 * @param {Response} res 
 */
exports.remove = async (req, res) => {
    let { id } = req.params
    let result = await repository.delete(id)
    res.status(202).end()
}
