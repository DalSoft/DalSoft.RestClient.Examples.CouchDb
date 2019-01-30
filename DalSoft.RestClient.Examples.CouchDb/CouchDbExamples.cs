using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DalSoft.RestClient.Examples.CouchDb.Models;
using Xunit;

namespace DalSoft.RestClient.Examples.CouchDb
{
    public class CouchDbExamples
    {
        // JSON example from https://github.com/DalSoft/DalSoft.RestClient/issues/77
        private const string CouchDbExampleJson = "{\r\n\"total_rows\": 8930,\r\n\"offset\": 8359,\r\n\"rows\": [\r\n{\r\n\"id\": \"c1e46d2b-887c-4e43-b518-8709f5838ed0\",\r\n\"key\": \"Wagoner, Darryl\",\r\n\"value\": null,\r\n\"doc\": {\r\n\"_id\": \"c1e46d2b-887c-4e43-b518-8709f5838ed0\",\r\n\"_rev\": \"28-ea45bc4d89a2e248b93c104734d86517\",\r\n\"name\": \"Wagoner, Darryl\",\r\n\"userName\": \"darryl\",\r\n\"passwordHash\": \"********\",\r\n\"postalCode\": \"72722\",\r\n\"docType\": \"Person\",\r\n\"phones\": [],\r\n\"notes\": [],\r\n\"horses\": [],\r\n\"masterHorseKeys\": [],\r\n\"memberships\": [\r\n{\r\n\"isVerified\": true,\r\n\"jas\": false,\r\n\"isJudge\": false,\r\n\"expiration\": \"2018-08-15T05:00:00.000Z\",\r\n\"shortName\": \"AHA\",\r\n\"membershipNum\": \"11114\"\r\n}\r\n],\r\n\"cashOnly\": false,\r\n\"isJudge\": false,\r\n\"address1\": \"Way\",\r\n\"city\": \"Decatur\",\r\n\"state\": \"AR\",\r\n\"hphone\": \"603-801-1114\",\r\n\"cphone\": \"603-801-1114\",\r\n\"dob\": \"2018-08-06T05:00:00.000Z\",\r\n\"email\": \"darryl@wagoner.me\",\r\n\"lastModifiedBy\": \"admin\",\r\n\"lastModifiedDate\": \"2018-08-25T21:07:06.443Z\",\r\n\"amateur\": true,\r\n\"address\": \"Way\",\r\n\"sex\": \"male\"\r\n}\r\n},\r\n{\r\n\"id\": \"1cbb81ca37ee53cb2f2578b3c0016fe9\",\r\n\"key\": \"Wagoner, Darryl p\",\r\n\"value\": null,\r\n\"doc\": {\r\n\"_id\": \"1cbb81ca37ee53cb2f2578b3c0016fe9\",\r\n\"_rev\": \"3-e53e24ef51367c3817a000403965b2e1\",\r\n\"docType\": \"Person\",\r\n\"memberships\": [\r\n{\r\n\"isVerified\": false,\r\n\"jas\": false,\r\n\"isJudge\": true,\r\n\"expiration\": null,\r\n\"shortName\": \"AHA\",\r\n\"membershipNum\": \"3333\"\r\n}\r\n],\r\n\"name\": \"Wagoner, Darryl p\",\r\n\"isJudge\": false,\r\n\"lastModifiedBy\": \"admin\",\r\n\"lastModifiedDate\": \"2018-08-25T20:05:26.189Z\",\r\n\"address\": \"\",\r\n\"phones\": [],\r\n\"sex\": null\r\n}\r\n},\r\n{\r\n\"id\": \"3d85b79aa3a2019afc0f43d7f900c228\",\r\n\"key\": \"Wagoner, Matt\",\r\n\"value\": null,\r\n\"doc\": {\r\n\"_id\": \"3d85b79aa3a2019afc0f43d7f900c228\",\r\n\"_rev\": \"1-108db21c70d4a7f34cd12d21aabb405d\",\r\n\"docType\": \"Person\",\r\n\"phones\": [],\r\n\"memberships\": [],\r\n\"sex\": \"male\",\r\n\"name\": \"Wagoner, Matt\",\r\n\"address\": \"123 Any Street\",\r\n\"city\": \"AnyTown\",\r\n\"state\": \"AR\",\r\n\"postalCode\": \"72722\",\r\n\"dob\": null,\r\n\"email\": null,\r\n\"cashOnly\": null,\r\n\"isJudge\": null,\r\n\"amateur\": null,\r\n\"lastModifiedBy\": \"admin\",\r\n\"lastModifiedDate\": \"2017-12-02T18:58:21.438Z\"\r\n}\r\n},\r\n{\r\n\"id\": \"3573f7b5-baad-4291-a527-318ac750c490\",\r\n\"key\": \"Wagoner, Susan\",\r\n\"value\": null,\r\n\"doc\": {\r\n\"_id\": \"3573f7b5-baad-4291-a527-318ac750c490\",\r\n\"_rev\": \"6-c4b0c9094bf903ac381d57a0ece52c5a\",\r\n\"name\": \"Wagoner, Susan\",\r\n\"address1\": \"PO Box 61\",\r\n\"city\": \"Brookline\",\r\n\"postalCode\": \"03033\",\r\n\"state\": \"NH\",\r\n\"dob\": \"2007-05-28T00:00:00\",\r\n\"docType\": \"Person\",\r\n\"phones\": [],\r\n\"notes\": [],\r\n\"horses\": [\r\n{\r\n\"_id\": \"0e746ac7-aef6-4c3e-95e4-1a60f1d93f42\",\r\n\"_rev\": \"1-32ed044d9b19626dc27c4ecf2a8daff2\",\r\n\"docType\": \"MasterHorse\",\r\n\"notes\": [],\r\n\"memberships\": [\r\n{\r\n\"docType\": \"AssociationMemberships\",\r\n\"association\": {\r\n\"_id\": \"5c9f3125-c3b8-446a-a581-8270da0b8668\",\r\n\"docType\": \"Association\",\r\n\"shortName\": \"AHR\",\r\n\"assocName\": \"Arabian Horse Registry of America Inc\",\r\n\"address1\": \"12000 Zuni St\",\r\n\"postalCode\": \"80234\",\r\n\"registryFlag\": true,\r\n\"nonMemberHumanFee\": 0,\r\n\"nonMemberHorseFee\": 0,\r\n\"waverFee\": 0,\r\n\"phones\": [\r\n{\r\n\"docType\": \"Phone\",\r\n\"phoneNum\": \"303-450-4748\",\r\n\"phoneLabel\": \"Office\"\r\n}\r\n]\r\n},\r\n\"membershipNum\": \"181701\",\r\n\"skillStatus\": \"Professional\",\r\n\"isVerified\": false,\r\n\"hasAppled\": false,\r\n\"hasWaver\": false,\r\n\"isJudge\": false,\r\n\"isPurebred\": true\r\n}\r\n],\r\n\"name\": \"Ga\'Abi\",\r\n\"height\": 15.1,\r\n\"color\": \"Bay\",\r\n\"sex\": \"Stallion\",\r\n\"dob\": \"1978-02-18T00:00:00\"\r\n}\r\n],\r\n\"masterHorseKeys\": [\r\n\"0e746ac7-aef6-4c3e-95e4-1a60f1d93f42\"\r\n],\r\n\"memberships\": [\r\n{\r\n\"docType\": \"AssociationMemberships\",\r\n\"membershipNum\": \"283959\",\r\n\"expiration\": \"1998-12-31T00:00:00\",\r\n\"skillStatus\": \"Professional\",\r\n\"isVerified\": true,\r\n\"hasAppled\": false,\r\n\"hasWaver\": false,\r\n\"isJudge\": false,\r\n\"isPurebred\": false,\r\n\"shortName\": \"AHA\",\r\n\"assocFk\": \"eb6d6b13-de76-4759-84ae-7121f9fd62ea\"\r\n},\r\n{\r\n\"docType\": \"AssociationMemberships\",\r\n\"membershipNum\": \"228668\",\r\n\"expiration\": \"2000-11-30T00:00:00\",\r\n\"skillStatus\": \"Professional\",\r\n\"isVerified\": true,\r\n\"hasAppled\": false,\r\n\"hasWaver\": false,\r\n\"isJudge\": false,\r\n\"isPurebred\": false,\r\n\"shortName\": \"USEF\",\r\n\"assocFk\": \"5fc40898-b8e9-4646-8a39-59e72842cf44\"\r\n},\r\n{\r\n\"jas\": false,\r\n\"isJudge\": false,\r\n\"isVerified\": false,\r\n\"membershipNum\": \"3333\",\r\n\"shortName\": \"AAHR\",\r\n\"expiration\": \"03/25/2017\"\r\n}\r\n],\r\n\"cashOnly\": false,\r\n\"isJudge\": false,\r\n\"lastModifiedBy\": \"admin\",\r\n\"lastModifiedDate\": \"2017-04-06T22:49:27.579Z\",\r\n\"address\": \"PO Box 61\"\r\n}\r\n}\r\n]\r\n}";
        
        [Fact]
        public async Task CouchDBResult_UsingExampleJson_ShouldCastCorrectlyToStrongType()
        {
            var config = new Config() // Set up unit test to always return our example JSON string
                .UseUnitTestHandler(message => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(CouchDbExampleJson)
                });

            dynamic client = new RestClient("https://my-api.com", config);

            var response = await client.NotUsedInUnitTest.Get();

            Results results = response;

            Assert.Equal(8930, results?.TotalRows);

            var lastRecord = results?.Rows.Last();
            var horse = lastRecord?.Doc?.Horses?.Single();
            
            Assert.Equal("0e746ac7-aef6-4c3e-95e4-1a60f1d93f42", horse?.Id);
            Assert.Equal("Ga'Abi", horse?.Name);

            var membership = horse?.Memberships?.Single();
            
            Assert.Equal("AssociationMemberships", membership?.DocType);
            Assert.Equal("181701", membership?.MembershipNum);
            Assert.Equal("Arabian Horse Registry of America Inc", membership?.Association?.AssocName);

            var phone = membership?.Association?.Phones?.Single();
            
            Assert.Equal("303-450-4748", phone?.PhoneNum);   
        }

        [Fact]
        public async Task CouchDBResult_UsingExampleJson_ShouldWorkDynamically()
        {
            var config = new Config() // Set up unit test to always return our example JSON string
                .UseUnitTestHandler(message => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(CouchDbExampleJson)
                });

            dynamic client = new RestClient("https://my-api.com", config);

            var response = await client.NotUsedInUnitTest.Get();
            
            Assert.Equal(8930, response?.total_rows);
            

            /* Don't forget if the member can be null do this horse?.name and if the collection can be empty do this new List<dynamic>(results?.rows ?? new List<dynamic>()).
               This is because many API's will omit the JSON when it is null, which upsets C# */

            var rows = new List<dynamic>(response?.rows ?? new List<dynamic>());
            
            // Test you can loop :)
            foreach (var row in rows)
            {
                if (row?.id != rows.Last()?.id)
                    continue; // Let's just assert the last record as it has the most data

                var horses = new List<dynamic>(row?.doc?.horses ?? new List<dynamic>());

                foreach (var horse in horses)
                {
                    Assert.Equal("0e746ac7-aef6-4c3e-95e4-1a60f1d93f42", horse?._id);
                    Assert.Equal("Ga'Abi", horse?.name);
                    
                    var memberships = new List<dynamic>(horse?.memberships ?? new List<dynamic>());

                    foreach (var membership in memberships)
                    {
                        Assert.Equal("AssociationMemberships", membership?.docType);
                        Assert.Equal("181701", membership?.membershipNum);
                        Assert.Equal("Arabian Horse Registry of America Inc", membership?.association?.assocName);
                                          
                        var phones = new List<dynamic>(membership?.association?.phones ?? new List<dynamic>());
                        foreach (var phone in phones)
                        {
                            Assert.Equal("303-450-4748", phone?.phoneNum);
                        }
                    }
                }
            }
        }

        [Fact]
        public async Task CouchDBResult_UsingExampleJson_LinqShouldWorkDynamically()
        {
            var config = new Config() // Set up unit test to always return our example JSON string
                .UseUnitTestHandler(message => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(CouchDbExampleJson)
                });

            dynamic client = new RestClient("https://my-api.com", config);

            var response = await client.NotUsedInUnitTest.Get();

            //Find horse buy name using Linq
            var rows = new List<dynamic>(response?.rows ?? new List<dynamic>());
            var horses = rows.SelectMany(x => new List<dynamic>(x?.doc?.horses ?? new List<dynamic>()));
            
            var horseByName = horses.FirstOrDefault(x => x?.name == "Ga'Abi");

            Assert.Equal("0e746ac7-aef6-4c3e-95e4-1a60f1d93f42", horseByName?._id);
            Assert.Equal("Ga'Abi", horseByName?.name);

            var membership = new List<dynamic>(horseByName?.memberships ?? new List<dynamic>()).SingleOrDefault();
            
            Assert.Equal("AssociationMemberships", membership?.docType);
            Assert.Equal("181701", membership?.membershipNum);
            Assert.Equal("Arabian Horse Registry of America Inc", membership?.association?.assocName);

            var phone = new List<dynamic>(membership?.association?.phones ?? new List<dynamic>()).SingleOrDefault();
            
            Assert.Equal("303-450-4748", phone?.phoneNum);   
        }
    }
}