'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var StoragePointSchema = new Schema({
	address:{
		type: String,
		required: true,
	},
	contact: String,
	rentPrice: Number 
}) 

StoragePointSchema.set('redisCache', true)
StoragePointSchema.set('expires', 30)

module.exports = mongoose.model('StoragePoint', StoragePointSchema);