const { body } = require('express-validator')

exports.candidateValidator = [
    body('lastname')
        .notEmpty().withMessage("Champ requis")
        .isLength({min: 2}).withMessage("Taille minimale de 2 caractères")
        .matches(/^[a-zA-ZÀ-ÿ]+([ -][a-zA-ZÀ-ÿ]+)*$/).withMessage("Accepte uniquement des noms ou des noms composés"),
    body('firstname').not().isEmpty().withMessage("Champ requis"),
    body('slogan').isLength({min: 5, max: 45}).withMessage("Taille minimale de 5 caractères et 45 maximum")
]

