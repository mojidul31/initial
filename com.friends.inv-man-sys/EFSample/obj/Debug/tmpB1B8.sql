DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'EFSample.DBContext.TrainingDBContext'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201702121312239_InitialCreate'
BEGIN
    CREATE TABLE [dbo].[Trainees] (
        [Id] [int] NOT NULL IDENTITY,
        [Name] [nvarchar](max),
        [SEID] [nvarchar](max),
        [EnrollDate] [datetime] NOT NULL,
        CONSTRAINT [PK_dbo.Trainees] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201702121312239_InitialCreate', N'EFSample.DBContext.TrainingDBContext',  0x1F8B0800000000000400CD57DB6EDB38107D2FB0FF20F0690BA4622E2F6D20B7487D59185B2741E5F69D96C60EB1BCA82415D8DFD687FDA4FD850EADABA538B1D3B45818302472E6CC99E15CA8FFBEFF1B7D584B11DC83B15CAB01390B4F49002AD12957AB01C9DDF2CD5BF2E1FD1FAFA2712AD7C1D74AEEC2CBA1A6B20372E75C7649A94DEE40321B4A9E186DF5D285899694A59A9E9F9EBEA36767141082205610449F73E5B884ED0BBE0EB54A20733913339D82B0E53AEEC45BD4E09A49B0194B6040C69398C94C4038FA886A0ED68E0457823364128358928029A51D73C8F3F28B85D819AD5671860B4CCC3719A0DC92090B25FFCB46FC50574ECFBD2BB451ACA092DC3A2D8F043CBB286343BBEACF8A30A96387D11B6394DDC67BBD8DE080CC0DE30AD0F7AEADCBA1305EAE15DFE228C252E524A8364EEA34C06CF1BF9360980B971B1828C89D61E224B8CD1782277FC366AEFF013550B9106D62480DF7761670E9D6E80C8CDB7C866549779A9280EEEAD1AE62ADD6D2293C992A77714E826B34CE1602EA736F791D3B6DE02F50609883F496390746790CD846AE67BD63CBFF57D630D1B066483063EB4FA056EE6E40F0910413BE86B45A29197C511C4B0C959CC9E12923F1783AFAE546C6CA6821461885CA947F9E73EF5F2F808F435DA5A9016B5F9872449B64EEA7B8EF043E4D4D3BCFD16CAB47F4321E9B4399F4B634B8EB56811C83EBD64E43A4683961BDF310E19A5AD3D468D1D5AAEE47F7B4BF68C6B20C9D68B5C37225888B5E387C131FDF2464814113FB40AFA8D9D696B042D80A3ABB681A994EB8B10EF3842D983FBD612A7B62FD83D813E4CADE6EACBB2DA2097D25EF9FCB14EE0D86700F4C13C809FA26B1D6B76E424D662F81AD6E9C30C1CC036D67A8452ED5BED6F59876D148DAFAC5CAE10845976823142B8723B45B401BA7BD7E385ADD05DA50F5621F27A29D23E91E3DED9D7D67307453E9B15AEC8AD4D6EB9AECD45E54D6C1D3F7935E61142224C000DDF3D41745BCB10E64E805C2F89B180A8EFE360233A6F812AC2B6627C12BC279E78AF3FFB96E506B5371D89DE3B7CF7FEE83FAE4843F72BAB547BEBA6726B963E64FC9D6AFDB48C78EF59F02EA8FEE149FDD0B8CEE23681D379EFBC3E3A7476F5165E8FB4223FD8266B9699F3D98FB451FD1F6A74B3402CB570D84FF905190F86A6A402B99A95AEA2ADEE85A9B5125D2398E19388667C9AE8CE34B9638DC4EF078B6D7A9AF4CE4FEF0E502D2A9BAC95D96BB2B6B412EC4CEB535A28FDBDFDE3E76394737997FB32FE102D2E43E1D6FD4C79C8BB4E63DE9A7E33E089F2C6501232BBC4E22DC6A53235D6B75205019BE1164A07CF9CF01AF0B08666F54CCEEE139DCF00EF909562CD954BD7B3FC8D307B11BF668C4D9CA30694B8C46DF7F8E53FF3DFEFE0790F595E5C10F0000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201702121324495_Add_Address_Trainee'
BEGIN
    ALTER TABLE [dbo].[Trainees] ADD [Address] [nvarchar](max)
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201702121324495_Add_Address_Trainee', N'EFSample.DBContext.TrainingDBContext',  0x1F8B0800000000000400CD57DB6EDB38107D2FB0FF20F0690BA4622E2F6D20B7487D59185B2741E5F69D96C60EB1BCA82415D8DFD687FDA4FD850EADABA538B1D3B45818302472E6CC99E15CA8FFBEFF1B7D584B11DC83B15CAB01390B4F49002AD12957AB01C9DDF2CD5BF2E1FD1FAFA2712AD7C1D74AEEC2CBA1A6B20372E75C7649A94DEE40321B4A9E186DF5D285899694A59A9E9F9EBEA36767141082205610449F73E5B884ED0BBE0EB54A20733913339D82B0E53AEEC45BD4E09A49B0194B6040C69398C94C4038FA886A0ED68E0457823364128358928029A51D73C8F3F28B85D819AD5671860B4CCC3719A0DC92090B25FFCB46FC50574ECFBD2BB451ACA092DC3A2D8F043CBB286343BBEACF8A30A96387D11B6394DDC67BBD8DE080CC0DE30AD0F7AEADCBA1305EAE15DFE228C252E524A8364EEA34C06CF1BF9360980B971B1828C89D61E224B8CD1782277FC366AEFF013550B9106D62480DF7761670E9D6E80C8CDB7C866549779A9280EEEAD1AE62ADD6D2293C992A77714E826B34CE1602EA736F791D3B6DE02F50609883F496390746790CD846AE67BD63CBFF57D630D1B066483063EB4FA056EE6E40F0910413BE86B45A29197C511C4B0C959CC9E12923F1783AFAE546C6CA6821461885CA947F9E73EF5F2F808F435DA5A9016B5F9872449B64EEA7B8EF043E4D4D3BCFD16CAB47F4321E9B4399F4B634B8EB56811C83EBD64E43A4683961BDF310E19A5AD3D468D1D5AAEE47F7B4BF68C6B20C9D68B5C37225888B5E387C131FDF2464814113FB40AFA8D9D696B042D80A3ABB681A994EB8B10EF3842D983FBD612A7B62FD83D813E4CADE6EACBB2DA2097D25EF9FCB14EE0D86700F4C13C809FA26B1D6B76E424D662F81AD6E9C30C1CC036D67A8452ED5BED6F59876D148DAFAC5CAE10845976823142B8723B45B401BA7BD7E385ADD05DA50F5621F27A29D23E91E3DED9D7D67307453E9B15AEC8AD4D6EB9AECD45E54D6C1D3F7935E61142224C000DDF3D41745BCB10E64E805C2F89B180A8EFE360233A6F812AC2B6627C12BC279E78AF3FFB96E506B5371D89DE3B7CF7FEE83FAE4843F72BAB547BEBA6726B963E64FC9D6AFDB48C78EF59F02EA8FEE149FDD0B8CEE23681D379EFBC3E3A7476F5165E8FB4223FD8266B9699F3D98FB451FD1F6A74B3402CB570D84FF905190F86A6A402B99A95AEA2ADEE85A9B5125D2398E19388667C9AE8CE34B9638DC4EF078B6D7A9AF4CE4FEF0E502D2A9BAC95D96BB2B6B412EC4CEB535A28FDBDFDE3E76394737997FB32FE102D2E43E1D6FD4C79C8BB4E63DE9A7E33E089F2C6501232BBC4E22DC6A53235D6B75205019BE1164A07CF9CF01AF0B08666F54CCEEE139DCF00EF909562CD954BD7B3FC8D307B11BF668C4D9CA30694B8C46DF7F8E53FF3DFEFE0790F595E5C10F0000 , N'6.1.3-40302')
END

