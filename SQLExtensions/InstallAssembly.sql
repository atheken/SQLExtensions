--enables CLR access, which is disabled by default.
sp_configure 'clr enabled', 1;
RECONFIGURE;

--installs the sql extensions dll into sql server.
USE [<THE_DATABASE_TO_INSTALL_INTO>];
CREATE ASSEMBLY SQLExtensions FROM 'C:\Code\SQLExtensions\SQLExtensions\bin/Debug/SQLExtensions.dll' WITH PERMISSION_SET = SAFE;

--installs the UDFs
--TODO--