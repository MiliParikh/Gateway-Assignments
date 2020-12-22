CREATE TABLE [dbo].[Table] (
    [IdUser]      INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   VARCHAR (50)   NOT NULL,
    [LastName]    VARCHAR (50)   NOT NULL,
    [EmailID]     NVARCHAR (MAX) NOT NULL,
    [PhoneNumber] NVARCHAR (50)  NOT NULL,
    [Age]         INT            NOT NULL,
    [DateOfBirth] DATETIME       NOT NULL,
    [Image]       NVARCHAR (MAX) NOT NULL,
    [Password]    NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUser] ASC)
);

