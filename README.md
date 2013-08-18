Eloqua SDK for .NET
=================
A software development kit for .NET that helps developers build applications that integrate with Eloqua.

## Bulk Client
### Create Client
	var info = BulkClient.GetAccountInfo(site, user, password);
	var client = new BulkClient(site, user, password, Helpers.BulkEndpoint(info));

### GET (list)
	List<ContactFilter> filters = _client.ContactFilters.Search("*", 1, 1);

## License
	Copyright [2012] [Fred Sakr]
	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at
	http://www.apache.org/licenses/LICENSE-2.0
	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.