'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var ProductSchema = new Schema({
	name: {
		type: String,
		required: true
	},
	price: Number,
	isavail: Boolean,
	storage: {
		type: Schema.ObjectId,
		ref: 'StoragePoint'	
	},
	provider: {
		type: Schema.ObjectId,
		ref: 'Provider'		
	}	
}) 

ProductSchema.set('redisCache', true)
ProductSchema.set('expires', 30)

module.exports = mongoose.model('Product', ProductSchema);