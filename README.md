# Sitecore.Data.Transfer
Sitecore Data Transfer tool helps quickly migrate dozens of Sitecore content items. This tool uses SQL BULK INSERT.


# Configuration
In the `SerializingOptions.json` file:

![alt text](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Doc/Assets/Config.png)

* Specify the `ConnectionString` for the Master database of your Sitecore instance from which you would like to make content export
* Specify Sitecore content `RootItemId` under which your target content lives

Others parameters main remain as is

