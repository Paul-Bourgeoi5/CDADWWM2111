const repo = require('../db/candidatesRepository')
const { validationResult } = require('express-validator')

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
        try {
            let result = await repo.getById(req.params.id)

            res.render('candidate_edit', { model : result })
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
        
        const validationErrors = validationResult(req)
        if (!validationErrors.isEmpty()){
            console.log(validationErrors.array())
            res.render('candidate_edit', {errors: validationErrors.array(), model: req.body})
        } else {
            let model = req.body
            console.log(model)
            let result = await repo.update(model)

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