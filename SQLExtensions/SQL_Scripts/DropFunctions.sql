/****** Object:  UserDefinedFunction [dbo].[GroupMatch]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupMatch]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GroupMatch]
GO
/****** Object:  UserDefinedFunction [dbo].[IsMatch]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsMatch]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[IsMatch]
GO
/****** Object:  UserDefinedFunction [dbo].[Match]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Match]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Match]
GO
/****** Object:  UserDefinedFunction [dbo].[Metaphone]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Metaphone]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Metaphone]
GO
/****** Object:  UserDefinedFunction [dbo].[MetaphoneAlternate]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MetaphoneAlternate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[MetaphoneAlternate]
GO
/****** Object:  UserDefinedFunction [dbo].[RegexReplace]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RegexReplace]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[RegexReplace]
GO
/****** Object:  UserDefinedFunction [dbo].[ShortMetaphone]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShortMetaphone]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ShortMetaphone]
GO
/****** Object:  UserDefinedFunction [dbo].[ShortMetaphoneAlternate]    Script Date: 12/06/2009 10:18:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShortMetaphoneAlternate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ShortMetaphoneAlternate]