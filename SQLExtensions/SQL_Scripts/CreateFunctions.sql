/****** Object:  UserDefinedFunction [dbo].[GroupMatch]    Script Date: 12/06/2009 10:18:26 ******/
CREATE FUNCTION [dbo].[GroupMatch](@regexPattern [nvarchar](max), @data [nvarchar](max), @group [int])
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlRegularExpressions].[GroupMatch]
GO
/****** Object:  UserDefinedFunction [dbo].[IsMatch]    Script Date: 12/06/2009 10:18:26 ******/
CREATE FUNCTION [dbo].[IsMatch](@regexPattern [nvarchar](max), @data [nvarchar](max))
RETURNS [bit] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlRegularExpressions].[IsMatch]
GO
/****** Object:  UserDefinedFunction [dbo].[Match]    Script Date: 12/06/2009 10:18:27 ******/
CREATE FUNCTION [dbo].[Match](@regexPattern [nvarchar](max), @data [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlRegularExpressions].[Match]
GO
/****** Object:  UserDefinedFunction [dbo].[Metaphone]    Script Date: 12/06/2009 10:18:27 ******/
CREATE FUNCTION [dbo].[Metaphone](@data [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlSoundsLike].[Metaphone]
GO
/****** Object:  UserDefinedFunction [dbo].[MetaphoneAlternate]    Script Date: 12/06/2009 10:18:28 ******/
CREATE FUNCTION [dbo].[MetaphoneAlternate](@data [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlSoundsLike].[MetaphoneAlternate]
GO
/****** Object:  UserDefinedFunction [dbo].[RegexReplace]    Script Date: 12/06/2009 10:18:28 ******/
CREATE FUNCTION [dbo].[RegexReplace](@regexPattern [nvarchar](max), @data [nvarchar](max), @replacement [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlRegularExpressions].[RegexReplace]
GO
/****** Object:  UserDefinedFunction [dbo].[ShortMetaphone]    Script Date: 12/06/2009 10:18:29 ******/
CREATE FUNCTION [dbo].[ShortMetaphone](@data [nvarchar](max))
RETURNS [smallint] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlSoundsLike].[ShortMetaphone]
GO
/****** Object:  UserDefinedFunction [dbo].[ShortMetaphoneAlternate]    Script Date: 12/06/2009 10:18:29 ******/
CREATE FUNCTION [dbo].[ShortMetaphoneAlternate](@data [nvarchar](max))
RETURNS [smallint] WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [SQLExtensions].[SQLExtensions.SqlSoundsLike].[ShortMetaphoneAlternate]