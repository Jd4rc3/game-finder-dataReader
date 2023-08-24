db = db.getSiblingDB('Parameters');
db.parameters.createIndex({Name: 1}, {unique: true});
