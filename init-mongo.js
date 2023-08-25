db = db.getSiblingDB('Parameters');
db.parameters.createIndex({Name: 1}, {unique: true});
db.parameters.insertMany([{
    "name": "platforms", "values": [{
        "name": "eneba", "commonName": "xbox", "valueName": "xbox"
    }, {
        "name": "xbox", "commonName": "xbox", "valueName": "xboxseries"
    }]
}, {
    "name": "regions", "values": [{
        "name": "eneba", "commonName": "colombia", "valueName": "colombia"
    }]
}]);
// {
//     "name": "<string>",
//     "values": [
//     {
//         "name": "<string>",
//         "commonName": "<string>",
//         "valueName": "<string>"
//     },
//     {
//         "name": "<string>",
//         "commonName": "<string>",
//         "valueName": "<string>"
//     }
// ]
// }