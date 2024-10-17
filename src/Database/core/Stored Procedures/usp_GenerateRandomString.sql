﻿/*
<object type="p" schema="core" name="usp_GenerateRandomString">
	<summary>Generates an alpha numeric random string with length provided</summary>
	<author>Jheison J. Mayta C.</author>
	<createdAt>2024.10.14</createdAt>
	<sourceLink>https://github.com/ktaranov/sqlserver-kit/blob/master/Scripts/Databases_Report.sql</sourceLink>
</object>
*/
CREATE PROCEDURE [core].[usp_GenerateRandomString]
	@stringLength	INT,
	@randomString	VARCHAR(MAX) OUTPUT
AS
BEGIN
	DECLARE
		@_asciiLowercase	VARCHAR(26),
		@_asciiUppercase	VARCHAR(26),
		@_charPool			VARCHAR(62),
		@_digits			VARCHAR(10),
		@_loopCount			INT,
		@_poolLength		INT,
		@_randomChar		VARCHAR(1),
		@_randomString		VARCHAR(50)

	SET @_asciiLowercase	= 'abcdefghijklmnopqrstuvwxyz'
	SET @_asciiUppercase	= 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
	SET @_digits			= '0123456789'
	SET @_charPool			= CONCAT(@_asciiLowercase, @_asciiUppercase, @_digits)
	SET @_loopCount			= 0
	SET @_poolLength		= LEN(@_charPool)
	SET @_randomString		= ''

	WHILE (@_loopCount < @stringLength)
	BEGIN
		-- get a random character from pool
		SET @_randomChar =
			SUBSTRING(
				@_charPool,
				CAST(RAND() * @_poolLength AS INT) + 1,
				1
			)

		-- add selected char to string
		SET @_randomString = @_randomString + @_randomChar

		-- increment the loop counter by one
		SET @_loopCount = @_loopCount + 1
	END

	SET @randomString = ISNULL(@_randomString, '')
END
GO