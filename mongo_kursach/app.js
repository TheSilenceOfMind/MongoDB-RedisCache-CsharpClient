var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var mongoose = require('mongoose');
var cachegoose = require('cachegoose');

var Provider = require('./models/Provider.model');
var StoragePoint = require('./models/StoragePoint.model');
var Product = require('./models/Product.model');
var Media = require('./models/Media.model');
var BuyerInfo = require('./models/BuyerInfo.model');
var BookingProduct = require('./models/BookingProduct.model');

var port = 8080;
var db = 'mongodb://localhost/test';
mongoose.connect(db);

cachegoose(mongoose, {
  engine: 'redis',    /* If you don't specify the redis engine,      */
  port: 6379,         /* the query results will be cached in memory. */
  host: 'localhost'
});

// PROVIDERS

// CREATE +
// curl -X POST "http://localhost:8080/provider?name=name111&contact=contact111&address=adresssss"
app.post('/provider', function(req, res) {
	var pr;
	if (!((req.param('name') == null) || (req.param('name') == ''))) {
		pr = new Provider({name: req.param('name'), contact: req.param('contact'), address: req.param('address')});
	} else {
		pr = new Provider({contact: req.param('contact'), address: req.param('address')});
	}

	pr.save (function(err, result) {
		if (err) {
			console.log(err);
			res.send(null);
		} else {
      cachegoose.clearCache('providers');
			console.log(result);
			res.send(result);
		}
	});
});

// READ (ALL) +
// curl -X GET "http://localhost:8080/providers"
app.get('/providers', function(req, res) {
	console.log('getting all providers');
	Provider.find({})
	.cache(0, 'providers') // The number of seconds to cache the query.  Defaults to 60 seconds.
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});


// READ (ONE) +
//
app.get('/provider/:id', function (req, res) {
	console.log('getting provider ', req.params.id);
	Provider.findOne( {
		_id: req.params.id
	})
	.cache(0, req.params.id) /* Will create a redis entry          */
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});


// UPDATE +
// curl -X PUT "http://localhost:8080/provider/5a2a9bd16f99b79af42cab70?name=namenmanmsn"
app.put('/provider/:id', function(req, res) {
	Provider.findOneAndUpdate({
		_id: req.params.id
	},
	{$set: {name: req.param('name')}},
	{upsert: true},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('providers');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("success");
		}
	});
});

// DELETE +
// curl -X DELETE "http://localhost:8080/provider/5a2aa55fa57bb7263c19a20e"
app.delete ('/provider/:id', function (req, res) {
	Provider.findOneAndRemove({
		_id: req.params.id
	},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache(req.params.id);
      cachegoose.clearCache('providers');
			console.log(result);
			res.send("success");
		}
	});
});

//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------

// STRORAGE_POINTS

// CREATE +
// curl -X POST "http://localhost:8080/storagepoint?address=name29837&contact=contact2222&rentprice=1231"
app.post('/storagepoint', function(req, res) {
	var sp = new StoragePoint();

	sp.address = req.param('address');
	sp.contact = req.param('contact');
	sp.rentPrice = req.param('rentprice');

	sp.save (function(err, result) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
      cachegoose.clearCache('storagepoint');
			console.log(result);
			res.send(result);
		}
	});
});

// READ (ALL) +
// curl -X GET "http://localhost:8080/storagepoints"
app.get('/storagepoints', function(req, res) {
	console.log('getting all storage points');
	StoragePoint.find({})
	.cache(60, 'storagepoint') // The number of seconds to cache the query.  Defaults to 60 seconds.
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});

// READ (ONE) +
// curl -X GET "http://localhost:8080/storagepoint/5a2c5ce99a019024a06ade83"
app.get('/storagepoint/:id', function (req, res) {
	console.log('getting storage point # ', req.params.id);
	StoragePoint.findOne( {
		_id: req.params.id
	})
	.cache(0, req.params.id) /* Will create a redis entry          */
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});


// UPDATE +
// curl -X PUT "http://localhost:8080/storagepoint/5a2c5d6f9a019024a06ade84?address=new+address"
app.put('/storagepoint/:id', function(req, res) {
	StoragePoint.findOneAndUpdate({
		_id: req.params.id
	},
	{$set: {address: req.param('address')}},
	{upsert: true},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
			console.log(result);
      cachegoose.clearCache(req.params.id);
      cachegoose.clearCache('storagepoint');
			res.send("Successfull updating");
		}
	});
});

// DELETE +
// curl -X DELETE "http://localhost:8080/storagepoint/5a2c5d6f9a019024a06ade84"
app.delete ('/storagepoint/:id', function (req, res) {
	StoragePoint.findOneAndRemove({
		_id: req.params.id
	},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			send('error');
		} else
		{
			console.log(result);
      cachegoose.clearCache(req.params.id);
      cachegoose.clearCache('storagepoint');
			res.send("success");
		}
	});
});

//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------

// MEDIA

// CREATE +
// curl -X POST "http://localhost:8080/media?medianame=name1111&mediacontent=9219381902&productid=5a3c176fe1937eeb20049915"
app.post('/media', function(req, res) {
	var med = new Media();

	med.mediaName = req.param('medianame');
	med.mediaContent = req.param('mediacontent');
	med.productId = req.param('productid');

	Product.findOne({
		_id: med.productId
	})
	.exec(function(err, results) {
		if (results == null || err) {
			console.log(err);
			res.send('error');
		} else {
			med.save (function(errr, result) {
			if (errr) {
				console.log(errr);
				res.send('error');
			} else {
        cachegoose.clearCache('media');
				console.log(result);
				res.send(result);
			}});
	}});
});

// READ (ALL) +
// curl -X GET "http://localhost:8080/media"
app.get('/media', function(req, res) {
	console.log('getting all media');
	Media.find({})
	.cache(60, 'media') // The number of seconds to cache the query.  Defaults to 60 seconds.
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});
// READ (ONE) +
// curl -X GET "http://localhost:8080/media/5a2c6a6894858b045000d812
app.get('/media/:id', function (req, res) {
	console.log('getting media # ', req.params.id);
	Media.findOne( {
		_id: req.params.id
	})
	.cache(0, req.params.id) /* Will create a redis entry          */
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});
// UPDATE +
// curl -X PUT "http://localhost:8080/media/5a2c6a6894858b045000d812?medianame=new+media+name"
app.put('/media/:id', function(req, res) {
	Media.findOneAndUpdate({
		_id: req.params.id
	},
	{$set: {mediaName: req.param('medianame')}},
	{upsert: true},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('media');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("Successfull updating");
		}
	});
});
// DELETE +
// curl -X DELETE "http://localhost:8080/media/5a3c176fe1937eeb20049917"
app.delete ('/media/:id', function (req, res) {
	Media.findOneAndRemove({
		_id: req.params.id
	},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('media');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("Successful deleting");
		}
	});
});

//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------

// PRODUCTS

// CREATE
// curl -X POST "http://localhost:8080/product?name=kek&price=234.5&isavail=true&storage=5a3c307488b77f2360fccbf5&provider=5a3c176ee1937eeb20049914"
app.post('/product', function(req, res) {
	var prod = new Product();

	prod.name = req.param('name');
	prod.price = req.param('price');
	prod.isavail = req.param('isavail');
	prod.storage = req.param('storage');
	prod.provider = req.param('provider');

	StoragePoint.findOne( {
		_id: prod.storage
	})
	.exec(function(err, results) {
		if (results == null || err) {
			console.log(err);
			res.send('error');
			return;
		} else {
			Provider.findOne( {
				_id: prod.provider
			})
			.exec(function(errr, resultss) {
				if (resultss == null || errr) {
					console.log(err);
					res.send('error');
					return;
				} else {
					prod.save (function(err, result) {
						if (err) {
							console.log(err);
							res.send('error');
						} else {
              cachegoose.clearCache('product');
							console.log(result);
							res.send(result);
						}
					});
				}
			});
		}
	});
});

// READ (ALL) +
// curl -X GET "http://localhost:8080/products"
app.get('/products', function(req, res) {
	console.log('getting all products');
	Product.find({})
	.cache(60, 'product') // The number of seconds to cache the query.  Defaults to 60 seconds.
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});

// READ (ONE) +-
// curl -X GET "http://localhost:8080/product/5a3d222ea995a13e5ca06f62
app.get('/product/:id', function (req, res) {
	console.log('getting product # ', req.params.id);
	Product.findOne( {
		_id: req.params.id
	})
	.cache(0, req.params.id) /* Will create a redis entry          */
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});

// UPDATE
// curl -X PUT "http://localhost:8080/product/5a3d222ea995a13e5ca06f62?name=newww+name"
app.put('/product/:id', function(req, res) {
	Product.findOneAndUpdate({
		_id: req.params.id
	},
	{$set: {name: req.param('name')}},
	{upsert: true},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('product');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("Successfull updating");
		}
	});
});

// DELETE
// curl -X DELETE "http://localhost:8080/product/5a3d222ea995a13e5ca06f62"
app.delete ('/product/:id', function (req, res) {
	Product.findOneAndRemove({
		_id: req.params.id
	},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('product');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("Successful deleting");
		}
	});
});

//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------

// BUYER_INFOS

// CREATE
// curl -X POST "http://localhost:8080/buyerinfo?name=name111&lastname=lastnameeee&phone=773837827382&address=adresssss"
app.post('/buyerinfo', function(req, res) {
	var bi = new BuyerInfo();

	bi.name = req.param('name');
	bi.lastName = req.param('lastname');
	bi.phone = req.param('phone');
	bi.address = req.param('address');

	bi.save (function(err, result) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
      cachegoose.clearCache('buyerinfo');
			console.log(result);
			res.send(result);
		}
	});
});

// READ (ALL)
// curl -X GET "http://localhost:8080/buyerinfos"
app.get('/buyerinfos', function(req, res) {
	console.log('getting all buyer infos');
	BuyerInfo.find({})
	.cache(60, 'buyerinfo') // The number of seconds to cache the query.  Defaults to 60 seconds.
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});
// READ (ONE)
// curl -X GET "http://localhost:8080/buyerinfo/5a3c176fe1937eeb20049916"
app.get('/buyerinfo/:id', function (req, res) {
	console.log('getting buyerinfo ', req.params.id);
	BuyerInfo.findOne( {
		_id: req.params.id
	})
	.cache(0, req.params.id) /* Will create a redis entry          */
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});

// UPDATE
// curl -X PUT "http://localhost:8080/buyerinfo/5a3c176fe1937eeb20049916?name=namenmanmsn"
app.put('/buyerinfo/:id', function(req, res) {
	BuyerInfo.findOneAndUpdate({
		_id: req.params.id
	},
	{$set: {name: req.param('name')}},
	{upsert: true},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('buyerinfo');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("success");
		}
	});
});


// DELETE
// curl -X DELETE "http://localhost:8080/buyerinfo/5a3c176fe1937eeb20049916"
app.delete ('/buyerinfo/:id', function (req, res) {
	BuyerInfo.findOneAndRemove({
		_id: req.params.id
	},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('buyerinfo');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("success");
		}
	});
});


//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------

// BOOKING_PRODUCT

// CREATE +
// curl -X POST "http://localhost:8080/bookingproduct?productid=5a3d2b8072c7ea3e40107a05&buyerid=5a3d2990cd44bb036cfdd9fe&quantity=5"
app.post('/bookingproduct', function(req, res) {
	var prod = new BookingProduct();

	prod.productId = req.param('productid');
	prod.buyerId = req.param('buyerid');
	prod.quantity = req.param('quantity');

	Product.findOne( {
		_id: prod.productId
	})
	.exec(function(err, results) {
		if (results == null || err) {
			console.log(err);
			res.send('error');
			return;
		} else {
			BuyerInfo.findOne( {
				_id: prod.buyerId
			})
			.exec(function(errr, resultss) {
				if (resultss == null || errr) {
					console.log(err);
					res.send('error');
					return;
				} else {
					prod.save (function(err, result) {
						if (err) {
							console.log(err);
							res.send('error');
						} else {
              cachegoose.clearCache('bookingproduct');
							console.log(result);
							res.send(result);
						}
					});
				}
			});
		}
	});
});

// READ (ALL) +
// curl -X GET "http://localhost:8080/bookingproducts"
app.get('/bookingproducts', function(req, res) {
	console.log('getting all booking products');
	BookingProduct.find({})
	.cache(60, 'bookingproduct') // The number of seconds to cache the query.  Defaults to 60 seconds.
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});

// READ (ONE) +
// curl -X GET "http://localhost:8080/bookingproduct/5a3c1770e1937eeb20049918"
app.get('/bookingproduct/:id', function (req, res) {
	console.log('getting booking product # ', req.params.id);
	BookingProduct.findOne( {
		_id: req.params.id
	})
	.cache(0, req.params.id) /* Will create a redis entry          */
	.exec(function(err, results) {
		if (err) {
			console.log(err);
			res.send('error');
		} else {
			console.log(results);
			res.json(results);
		}
	});
});

// UPDATE +
// curl -X PUT "http://localhost:8080/bookingproduct/5a3c1770e1937eeb20049918?quantity=7"
app.put('/bookingproduct/:id', function(req, res) {
	BookingProduct.findOneAndUpdate({
		_id: req.params.id
	},
	{$set: {quantity: req.param('quantity')}},
	{upsert: true},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('bookingproduct');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("Successfull updating");
		}
	});
});

// DELETE
// curl -X DELETE "http://localhost:8080/bookingproduct/5a3c1770e1937eeb20049918"
app.delete ('/bookingproduct/:id', function (req, res) {
	BookingProduct.findOneAndRemove({
		_id: req.params.id
	},
	function(err, result) {
		if (err || result == null) {
			console.log (err);
			res.send('error');
		} else
		{
      cachegoose.clearCache('bookingproduct');
      cachegoose.clearCache(req.params.id);
			console.log(result);
			res.send("Successful deleting");
		}
	});
});

//-------------------------------------------------------------------------------------------------

app.listen(port, function () {
	console.log('\n############## server started ##############\n');
})
