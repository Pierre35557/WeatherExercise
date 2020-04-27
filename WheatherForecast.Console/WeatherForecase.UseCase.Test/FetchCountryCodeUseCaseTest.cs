using NSubstitute;
using NUnit.Framework;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Presenters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecase.UseCase.Test
{
    [TestFixture]
    public class FetchCountryCodeUseCaseTest
    {
        [TestFixture]
        public class Execute
        {
            [Test]
            public async Task When_City_Is_Blank_Expect_Error()
            {
                //Arrange
                var presenter = new PropertyPresenter<Cities, ErrorOutput>();

                var _city = Substitute.For<ICountry>();

                var inputTo = new Cities
                {
                    City = "",
                    State = "",
                    Country = "SA"
                };

                var useCase = new FetchCountryCodeUseCase(_city);

                //Act
                await useCase.Execute(inputTo, presenter);

                //Assert
                //var expectedCity = new Cities();

                //presenter.ErrorContent.Should()

                //How do i test this?
            }

            [Test]
            public async Task When_Country_Is_Blank_Expect_Error()
            {
                //Arrange
                var presenter = new PropertyPresenter<Cities, ErrorOutput>();

                var _city = Substitute.For<ICountry>();

                var inputTo = new Cities
                {
                    City = "",
                    State = "",
                    Country = "SA"
                };

                var useCase = new FetchCountryCodeUseCase(_city);

                //Act
                await useCase.Execute(inputTo, presenter);

                //Assert
                //var expectedCity = new Cities();

                //presenter.ErrorContent.Should()

                //How do i test this?
            }

        }
    }
}