const repo = require('../db/candidatesRepository')
const { validationResult } = require('express-validator')

const {randomBytes} = require('crypto')

/**
 * @method index       lister les candidats (accueil du controlleur)
 * @method getById     afficher les détails d'un candidat
 * @method add         ajouter un nouveau candidat
 * @method update      modifier un candidat existant
 * @method remove      supprimer un candidat existant
 */
module.exports = {

    /**
     * GET /candidates
     * Affiche la liste des candidats
     * @param {Request} req 
     * @param {Response} res 
     */
    async index(req, res) {
        try {
            let result = await repo.getAll()
            res.render('index', { model : result, title: 'Liste des candidats' })
        } catch (err) {
            res.status(500).end()
        }        
    },

    /**
     * GET /candidates/:id
     * Affiche un candidat ou erreur 404 si identifiant inexistant
     * @param {Request} req 
     * @param {Response} res 
     */
    async getById(req, res) {
        try {
            let result = await repo.getById(req.params.id)
            console.log(result)
            if(result === undefined){
                res.status(404).end()
            }
            res.render('candidate', { model : result, title: 'Fiche candidat' })
        } catch (err) {
            res.status(500).end()
        }  
    },

        /**
     * GET /candidates/:id
     * Affiche un candidat ou erreur 404 si identifiant inexistant
     * @param {Request} req 
     * @param {Response} res 
     */
         async getManyId(req, res) {
            let indices = req.body.test
            if (indices === undefined) {
                res.end()
            } else {
                let marqueurs = []

                for(indice of indices){
                    marqueurs.push('?')
                }
    
                try {
                    let result = await repo.getIndices(indices, marqueurs)
                    console.log(result)
                    if(result === undefined){
                        res.status(404).end()
                    }
                    res.render('index', { model : result})
                } catch (err) {
                    res.status(500).end()
                }  
            }

        },

    /**
     * GET /candidates/add
     * Affiche le formulaire permettant d'ajouter un candidat 
     * @param {Request} req 
     * @param {Response} res 
     */
     async add(req, res) {
        res.render('candidate_add')
    },

    /**
     * POST /candidates/add
     * @param {Request} req 
     * @param {Response} res 
     * @todo contrôle de saisie
     */
    async add_post(req, res){
        let model = req.body

        let result = await repo.create(model)

        res.redirect('/candidates')
    },

    /**
     * GET /candidates/edit/:id
     * Affiche le formulaire permettant de modifier un candidat 
     * @param {Request} req 
     * @param {Response} res 
     */
     async update(req, res) {
        // on vérifie la présence d'un token contre les attaques CSRF. S'il n'existe pas, on le crée.
        if (req.session.csrf_token === undefined) {
            req.session.csrf_token = randomBytes(100).toString('base64')
        }
        

        try {
            let result = await repo.getById(req.params.id)
            res.render('candidate_edit', { model : result, token: req.session.csrf_token })
        } catch (err){
            console.error(err)
            res.status(500).end()
        }
        
        
    },

    /**
     * POST /candidates/edit:id
     * @param {Request} req 
     * @param {Response} res 
     * @todo contrôle de saisie
     */
    async update_post(req, res) {
        // On vérifie la présence du token CSRF dans le body de notre requête. S'il n'est pas là, la requête de provient pas de notre site. 
        if (!req.body.csrf_token) {
            // Destruction du cookie de session 
            req.session = null
            return res.send(`<p style="font-size: 4rem; color: red;">
                     <strong>CSRF Token not included.</strong>
                     </p>`)
        }
        
        // On vérifie que le token CSRF dans le body de la requête correspond au token CSRF présent dans la session. S'ils ne correspondent pas, on annule la requête.
        if (req.body.csrf_token !== req.session.csrf_token) {
            // Destruction du cookie de session
            req.session = null
            return res.send(`<p style="font-size: 4rem; color: red;">
                             <strong>CSRF tokens do not match.</strong>
                             </p>`);
          }

        const validationErrors = validationResult(req)
        if (!validationErrors.isEmpty()){
            console.log(validationErrors.mapped())
            res.render('candidate_edit', {errors: validationErrors.mapped(), model: req.body, token: req.body.csrf_token})
        } else {
            let model = req.body
            let result = await repo.update(model)
            // Destruction du cookie de session ce qui forcera la création d'un nouveau pour une nouvelle modification.
            req.session = null
            res.redirect('/candidates')
        }
    },

    /**
     * GET /candidates/delete/:id
     * Affiche la page de confirmation de suppression d'un candidat 
     * @param {Request} req 
     * @param {Response} res 
     */
    async remove(req, res) {
        let result = await repo.getById(req.params.id)
        res.render('candidate_delete', { model : result })
    }
}