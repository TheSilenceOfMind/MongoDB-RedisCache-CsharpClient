'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var BookingProductSchema = new Schema({
	productId: {
		type: Schema.ObjectId,
		ref: 'Product',
		required: true		
	},
	buyerId: {
		type: Schema.ObjectId,
		ref: 'BuyerInfo',
		required: true		
	},
	quantity: Number
}) 

BookingProductSchema.set('redisCache', true)
BookingProductSchema.set('expires', 30)

module.exports = mongoose.model('BookingProduct', BookingProductSchema);