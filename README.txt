SQL Profiler Query Cleaner

This is a little project I cooked up in less than an hour to save me some time.

SQL Profiler is a great tool to show you exactly what SQL is being executed, along with the parameters. This is especially useful when debugging, because sometimes you aren't sure what SQL is being executed.

However, often times I will find myself having to pull that SQL+parameters out of SQL Profiler and paste it into SQL Server Studio in order to analyze, tweak, debug, etc. SQL Profiler's output looks like:

exec sp_execute sql N'my sql with ''quotes'' escaped string',@MyParam1 datetime, @MyParam2 datetime,@MyParam1='2009-02-11',@MyParam2='2013-03-15'

Which is fine, and *executes* in SQL Studio, but if there's a syntax error, you can't really pinpoint exactly where in the query the error is, and it's harder to manipulate the parameters because you have to do it in two spots, and it's just time-consuming if you're doing this a lot (which I was).

So, fire up this program, paste the SQL Profiler output into the top text box, click the "Clean" button, and the bottom text box will have a more SQL Studio friendly query, like:

DECLARE @MyParam1 datetime='2009-02-11'
DECLARE @MyParam2 datetime='2013-03-15'

MY SQL STRING with 'quotes' that AREN'T ESCAPED

To do:

* Make this into a SQL Studio extension
* Make a command line/PowerShell version

Acknowledgements:

* Andrew Whitaker's [sql-formatter C# project](https://github.com/AndrewWhitaker/sql-formatter), which is based on
* Jeremy Dorn's [sql-formatter project for php](https://github.com/jdorn/sql-formatter), both MIT Licensed.
