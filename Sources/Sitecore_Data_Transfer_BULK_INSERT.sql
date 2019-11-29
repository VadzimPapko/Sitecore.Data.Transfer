use [sc92empty_Master] --your Sitecore Master DB
go

bulk insert [dbo].[items]
	from 'C:\App_data\items.txt'
	with(
		DATAFILETYPE ='widechar',
		FIELDTERMINATOR ='=^.^=',
		ROWTERMINATOR ='(*(oo)*)'
	);

bulk insert [dbo].[versionedfields]
	from 'C:\App_data\versioned_f.txt'
	with(
		DATAFILETYPE ='widechar',
		FIELDTERMINATOR ='=^.^=',
		ROWTERMINATOR ='(*(oo)*)'
	);

bulk insert [dbo].[unversionedfields]
	from 'C:\App_data\unversioned_f.txt'
	with(
		DATAFILETYPE ='widechar',
		FIELDTERMINATOR ='=^.^=',
		ROWTERMINATOR ='(*(oo)*)'
	);
	
	bulk insert [dbo].[sharedfields]
	from 'C:\App_data\shared_f.txt'
	with(
		DATAFILETYPE ='widechar',
		FIELDTERMINATOR ='=^.^=',
		ROWTERMINATOR ='(*(oo)*)'
	);
	
	bulk insert [dbo].[descendants]
	from 'C:\App_data\descendants.txt'
	with(
		DATAFILETYPE ='widechar',
		FIELDTERMINATOR ='=^.^=',
		ROWTERMINATOR ='(*(oo)*)'
	);