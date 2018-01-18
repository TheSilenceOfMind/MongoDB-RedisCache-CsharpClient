'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var MediaSchema = new Schema({
	mediaName: {
		type: String,
		required: true
	},
	mediaContent: Buffer,
	productId: {
		type: Schema.ObjectId,
		ref: 'Product'			 // kind of ForeignKey
	}
}) 

MediaSchema.set('redisCache', true)
MediaSchema.set('expires', 30)

module.exports = mongoose.model('Media', MediaSchema);