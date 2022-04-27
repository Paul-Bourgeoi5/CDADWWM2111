const db = require('./index')

class Repository 
{
    /**
     * 
     * @param {sqlite3.Database} _db 
     */
    constructor(_db) 
    {
        this.db = _db
    }

    /**
     * execute une requête de lecture et retourne le jeu de résultats sous forme de tableau
     * @param {String} sql la requête SQL à exécuter
     * @param {Array} params le tableau des paramètres de la requête SQL
     * @returns {Promise} le résultat du traitement
     */
    getAll(sql, params = []) {
        return new Promise((resolve, reject) => {
            this.db.all(sql, params, (err, rows) => {
                if(err) {
                    console.error('Erreur SQL : ' + err)
                    reject(err)
                } else { 
                    //console.log(rows)
                    resolve(rows)
                }
            })
        })
    }

    /**
     * execute une requête de lecture (select) et retourne la 1ère ligne correspondante sous forme d'objet
     * @param {String} sql la requête SQL à exécuter
     * @param {Array} params le tableau des paramètres de la requête SQL
     * @returns {Promise} le résultat du traitement
     */
    getOne(sql, params = []) {
        return new Promise((resolve, reject) => {
            this.db.get(sql, params, (err, row) => {
                if(err) {
                    console.error('Erreur SQL : ' + err)
                    reject(err)
                } else { 
                    //console.log(rows)
                    resolve(row)
                }
            })
        })
    }

    /**
     * execute une requête d'écriture (insert, update, delete) 
     * @param {String} sql la requête SQL à exécuter
     * @param {Array} params le tableau des paramètres de la requête SQL
     * @returns {Promise} le résultat du traitement
     */
    execute(sql, params = []) {
        return new Promise((resolve, reject) => {
            this.db.run(sql, params, (err, result) => {
                if(err) {
                    console.error('Erreur SQL : ' + err)
                    reject(false)
                } else { 
                    resolve(true)
                }
            })
        })
    }


}

module.exports = new Repository(db);