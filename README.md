# AzureWeatherWebAppDocumentDB
Store and retrieve weather alerts from a Doc DB Database and publish it to Azure App Services. The sample uses the local offline Doc DB emulator. Store Doc DB credentials in App Service App Settings.

Refer to file AzureFunctionBlobToDocDB for the source code which is used to transform large blob into multiple doc db documents below .
This function also fetches address information from the virtual earth geo coding service and appends that data to the JSON document. Note that the function triggers on a single blob and outputs a collection of JSON documents. (ICollector implementation)
