SQLExtentions
=============

This assembly fills in some gaps in SQL Server. 

Please feel free to contact Andrew Theken (theken.1@osu.edu) if you have questions, or would like to contribute.

LICENSE:

This library is made available under the MIT License (http://www.opensource.org/licenses/mit-license.php), some code is made available under different licensing - when this is the case, the appropriate license has been included at the top of the source file.

Copyright (c) 2009 Andrew Theken

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

INSTALLATION:

0) Enable CLR Integration on the target SQL Server:
	
	sp_configure 'clr enabled', 1;
	RECONFIGURE;

1) Compile the assembly and install it in one of the databases:

	USE [*<databasename>*];
	CREATE ASSEMBLY 'SQLExtensions' FROM '*<path to the compiled dll>*' SAFE;

2) Execute User-defined function in SQL ("_SQL_Scripts/CreateFunctions.sql_")

3) User-defined functions must be prefixed with their schema when used (typically '_dbo._'), so something like the following would remove anything but digits from the phone_number column of a Contacts table:

	SELECT dbo.RegexReplace('\D+', phone_number, '') as scrubbed_phone_number FROM Contacts;
