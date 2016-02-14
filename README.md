Client Library for Eloqua Bulk API SDK for .NET
=================
A software development kit for .NET that helps developers build applications that integrate with Oracle Eloqua.
Currently, contains clients for the Bulk API version 2. This project was forked from
[fredsakr's repository] (https://github.com/fredsakr/eloqua-csharp-sdk). This one changes slightly the API of the
library. The main differences are:
	- You have asynchronous methods whenever it is possible, so your application can continue performing other
	operations while the request is running.
	- All the properties are in PascalCase format instead of camelCase (the serializer was configured to accept this
	convention).
	- Some of the requests are strongly typed. Please note that enums are actually strings because Eloqua does not
	offer documentation about all its possible values. Those that are known are in static classes.
	- This is built with C#6 features, but this doesn't affect the usage.
	- The root namespace is Eloqua.Api.Bulk instead of BulkClient.
	- RestSharp 105.2.3 is used instead of 104.1.

The testing project in this repository does not have a single valid test right now. Use it only for the tests you
include in your pull requests.

## Contact Example
### Create Client
	AccountInfo info = await BulkClient.GetAccountInfoAsync("MyCompany", "jhon", "P@ssw0rd!");
	var client =
		new BulkClient("MyCompany", "jhon", "P@ssw0rd!", info.Urls.Apis.Rest.Bulk.Replace("{version}", "2.0"));

### GET (list)
	List<ContactFilter> filters = _client.ContactFilters.Search(searchTerm, page, count);

### Retrieving Contacts Export
	Export export = new Export
	{
		Name = "sample export",
		Fields = fields,
		Filter = filter,
		SecondsToAutoDelete = 3600,
		SecondsToRetainData = 3600,
	};

	Export exportResult = await client.ContactExport.CreateExportAsync(export);

	var sync = new Sync
	{
		Status = SyncStatus.Pending,
		SyncedInstanceUri = exportResult.Uri
	};

	Sync syncResult = await _client.ExportClient.CreateSyncAsync(sync);

	// Currently, we don't have a class for the exported list of contacts. If you create one,
	// please make a pull request :)
	ExportResult<object> contacts = _client.ExportClient.ExportDataAsync<ExportResult<object>>(exportResult.uri);

## Get Activity Data Example
### Create Client
	AccountInfo info = await BulkClient.GetAccountInfoAsync("MyCompany", "jhon", "P@ssw0rd!");
	var client =
		new BulkClient("MyCompany", "jhon", "P@ssw0rd!", info.Urls.Apis.Rest.Bulk.Replace("{version}", "2.0"));

### Issue the export
	var emailClickthroughExport = new Export
	{
		Name = "Example EmailClickthrough Activity Export",
		Filter = "'{{Activity.CreatedAt}}' >= '2015-10-01' AND '{{Activity.Type}}' = 'EmailClickthrough''",
		Fields = new Dictionary<string, string>
		{
			{ "ActivityId", "{{Activity.Id}}" },
			{ "ActivityType", "{{Activity.Type}}" },
			{ "ActivityDate", "{{Activity.CreatedAt}}" },
			{ "EmailAddress", "{{Activity.Field(EmailAddress)}}" },
			{ "ContactId", "{{Activity.Contact.Id}}" },
			{ "IpAddress", "{{Activity.Field(IpAddress)}}" },
			{ "VisitorId", "{{Activity.Visitor.Id}}" },
			{ "EmailRecipientId", "{{Activity.Field(EmailRecipientId)}}" },
			{ "AssetType", "{{Activity.Asset.Type}}" },
			{ "AssetName", "{{Activity.Asset.Name}}" },
			{ "AssetId", "{{Activity.Asset.Id}}" },
			{ "SubjectLine", "{{Activity.Field(SubjectLine)}}" },
			{ "EmailWebLink", "{{Activity.Field(EmailWebLink)}}" },
			{ "VisitorExternalId", "{{Activity.Visitor.ExternalId}}" },
			{ "CampaignId", "{{Activity.Campaign.Id}}" },
			{ "ExternalId", "{{Activity.ExternalId}}" },
			{ "EmailSendType", "{{Activity.Field(EmailSendType)}}" }
		}
	};
	
	Sync syncResult = await client.ExportClient.IssueExport(emailClickthroughExport);

### Get the data
	ExportResult<Activity> exportedData;

	do
	{
		// This should not be executed so frequently. Here, I use a while loop to make the example simple
		exportedData = await client.ExportClient.GetExportResultIfFinished<Activity>(syncResult.GetId().Value);
	} while (exportedData == null);


## Contributing
Please feel free to contribute to this repository. There are a lot of improvements oportunities, like:
- Documentation. Here on Github and in the code.
- Unit testing all the clients (and probably, fixing them) because most of them were just copied and refactored, but not
tested (because the Eloqua account I have does not allow it, sorry :/).
- Make strongly typed the fields for the request (look at how it is done right now in the activity example above).
- More support for Activities.

The only guideline to contribute is that you should follow the patterns of the project (so the API is consistent),
and that you document the classes you create (so it is easy for everyone else to understand what you did).

## License
	Copyright [2016] [Jonathan Soto]
	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at
	http://www.apache.org/licenses/LICENSE-2.0
	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.
