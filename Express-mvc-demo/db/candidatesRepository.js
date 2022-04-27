 const repo = require('./repository')

/**
 * Retourne la liste des candidats
 * @returns {Promise} le jeu de résultats dans un tableau
 */
exports.getAll = () => {

    return repo.getAll("SELECT id, lastname, firstname, slogan FROM candidates")

}

/**
 * Retourne un candidat 
 * @param {Int} id Identifiant du candidat à retourner 
 * @returns {Promise} le candidat sous forme d'objet ou undefined si identifiant inexistant
 */
exports.getById = (id) => {

    return repo.getOne("SELECT id, lastname, firstname, slogan FROM candidates WHERE id=?", [id]);

}

/**
 * Crée un candidat
 * @param {Object} model { lastname: String, firstname: String, slogan: String }
 * @returns {Promise}
 */
exports.create = (model) => {
    const sql = `INSERT INTO candidates (lastname, firstname, slogan) VALUES (?, ?, ?)`
    const params = [model.lastname, model.firstname, model.slogan]

    return repo.execute(sql, params)
}

/**
 * Modifie un candidat
 * @param {Object} model { lastname: String, firstname: String, slogan: String, id: Int }
 * @returns {Promise}
 */
exports.update = (model) => {

    const sql = `UPDATE candidates SET lastname=?, firstname=?, slogan=? WHERE id=?`
    const params = [model.lastname, model.firstname, model.slogan, model.id]
    return repo.execute(sql, params)

}

/**
 * Supprime un candidat
 * @param {Int} id Identifiant du candidat à supprimer 
 * @returns {Promise}
 */
exports.delete = (id) => {

    return repo.execute('DELETE FROM candidates WHERE id=?', [id])

}
