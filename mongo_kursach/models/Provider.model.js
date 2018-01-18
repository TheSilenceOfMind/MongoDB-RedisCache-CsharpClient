'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var ProviderSchema = new Schema({
	name: {
		type: String,
		default: "no nameeeeee"		
	},
	contact: {
		type: String		
	},
 	address: String
}) 


module.exports = mongoose.model('Provider', ProviderSchema);