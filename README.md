# gQuote
repo for gQuote ckt mgr

gQuote is a MVC web-app that takes user input from a form, runs it through a controller, and then uses ADO.net to reach
into a SQL database.

Once the database returns the data, it is parsed, combined with a view, and sent to the user.

Paging is also implemented whereby the user can click a forward or back-arrow.  The URL contains embedded query parameters to the
query is run again to pull the "next-10." In other words, each page forward and back results in a new database query.

