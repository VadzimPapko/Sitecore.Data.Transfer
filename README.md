# Sitecore.Data.Transfer
Sitecore Data Transfer tool helps quickly migrate dozens of Sitecore content items. This tool uses SQL BULK INSERT.

Full Description you can find [here](https://www.sam-solutions.com/blog/sitecore-data-transfer-tool-sql-bulk-insert/)


# Configuration
In the `SerializingOptions.json` file:

![alt text](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Doc/Assets/Config.png)

* Specify the `ConnectionString` for the Master database of your Sitecore instance from which you would like to make content export
* Specify Sitecore content `RootItemId` under which your target content lives

Others parameters main remain as is


# How To Run
*   Download or clone this repository
*   Configure `SerializingOptions.json` 
*   Open the solution, make a build and run `ScDataTransfer.UI` project (this is a console application). You will see a simple screen:

![alt text](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Doc/Assets/RunOptions.png)

*   Press 2 for running
*   After, you will see quite the same picture:

![alt text](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Doc/Assets/TimeSpent.png)

* When is completed, navigate to App_data folder and observe that the following files (the names of these go from the `SerializingOptions.json`):

![alt text](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Doc/Assets/SerializedFiles.png)

To **complete the whole content data transferring**, we need to perform some more steps:

* Make sure to export the **Root Sitecore Item** (configured in the `SerializingOptions.json`) from the old Sitecore instance to a new one

* Use **SQL Management Studio** to execute **BULK INSERT SCRIPT** located [here](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Sources/Sitecore_Data_Transfer_BULK_INSERT.sql)

* Log into your target **Sitecore Admin Panel — Control Panel — Rebuild link databases**:

![alt text](https://github.com/VadzimPapko/Sitecore.Data.Transfer/blob/master/Doc/Assets/RebuildLinks.png)

* Certainly, you can publish migrated content if needed

# How Much Time It Takes
In my case *43 000 items* - **two minutes** for both **Serialization** and **BULK INSERT** processes. 

