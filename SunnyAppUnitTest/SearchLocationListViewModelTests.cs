using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SunnyApp.Models;
using SunnyApp.Services.Abstractions;
using SunnyApp.ViewModels;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SunnyApp.UnitTest
{
    [TestClass]
    public class SearchLocationListViewModelTests
    {
        [TestMethod]
        [TestCase("324505", "Kyiv", "City")]
        public void LoadItemsCommandTest(string key, string localizedName, string type)
        {
            //Arrange
            Location location = new Location
            {
                Key = key,
                LocalizedName = localizedName,
                Type = type,
                AdministrativeArea = new AdministrativeArea()
                {
                    LocalizedName = "",
                    LocalizedType = ""
                },
                Country = new Country()
                {
                    ID = "",
                    LocalizedName = ""
                }
            };

            var locationSearchServiceMoc = new Mock<ILocationSearchService>();
            locationSearchServiceMoc.Setup(service => service.GetLocationListByTextAsync(It.IsAny<string>())).ReturnsAsync(new List<Location>
            {
                location
            });

            var searchLocationListViewModel = new SearchLocationListViewModel(locationSearchServiceMoc.Object);

            //Act
            searchLocationListViewModel.LoadItemsCommand.Execute(null);
            var locationListResult = searchLocationListViewModel.LocationList;


            //Assert
            Assert.AreEqual(location, locationListResult.FirstOrDefault());


        }
    }
}
