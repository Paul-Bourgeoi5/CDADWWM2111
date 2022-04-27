const express = require('express')
const router = express.Router()

const validator = require('../middlewares/validator')

const homeController = require('../controllers/homeController')
const apiController = require('../controllers/apiController')
const candidatesController = require('../controllers/candidatesController')

/*
router.get('/', (request, response) => {
    response.send('Accueil')
})*/


/* HOME CONTROLLER */

router.get('/hello/:name', homeController.sayHello)
router.get('/about', homeController.about)
router.get('/', homeController.index)




/* API CONTROLLER */

router.get('/api/:id', apiController.getById) 

router.put('/api/:id', apiController.update)

router.delete('/api/:id', apiController.remove)

router.get('/api', apiController.index)

router.post('/api', apiController.add)


/* CANDIDATES CONTROLLER */

router.get('/candidates/edit/:id', candidatesController.update)
router.post('/candidates/edit/:id', validator.candidateValidator, candidatesController.update_post)

router.get('/candidates/delete/:id', candidatesController.remove)

router.get('/candidates/add', candidatesController.add)
router.post('/candidates/add', candidatesController.add_post)

router.get('/candidates/:id', candidatesController.getById)
router.get('/candidates', candidatesController.index)


/* ROUTES PAR DEFAUT & ERREURS */

// erreur 404 toujours en dernier
router.all('*', (req, res) => {
    res.status(404).send('Erreur 404 : page non trouvée')
})

module.exports = router
