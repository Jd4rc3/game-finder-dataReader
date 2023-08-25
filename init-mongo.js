db = db.getSiblingDB('Parameters');
db.parameters.createIndex({ Name: 1 }, { unique: true });
db.parameters.insertMany([
    {
        "Name": "platforms", "Values": [
            { "Name": "eneba", "CommonName": "xbox", "ValueName": "xbox" },
            { "Name": "xbox", "CommonName": "xbox", "ValueName": "xboxseries" }
        ]
    },
    {
        "Name": "regions", "Values": [{ "Name": "eneba", "CommonName": "colombia", "ValueName": "colombia" }]
    }
]);
