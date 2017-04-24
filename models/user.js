var mongoose = require("mongoose"),
  schema = mongoose.Schema;


var User = new schema({
  name: {type: String},
  lastname: {type: String}
});

module.exports = moongose.model('User', User);
