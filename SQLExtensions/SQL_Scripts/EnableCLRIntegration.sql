
-- CLR Integration is off by default in sql server, therefore, we must enable it.
-- see: http://msdn.microsoft.com/en-us/library/ms254506(VS.80).aspx for more details.
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO