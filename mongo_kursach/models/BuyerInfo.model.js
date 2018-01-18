'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var BuyerInfoSchema = new Schema({
	name: String,	
	lastName: {
		type: String,
		required: true
	},
	phone: {
		type: String,
		required: true
	},
	address: String
}) 

BuyerInfoSchema.set('redisCache', true)
BuyerInfoSchema.set('expires', 30)

module.exports = mongoose.model('BuyerInfo', BuyerInfoSchema);