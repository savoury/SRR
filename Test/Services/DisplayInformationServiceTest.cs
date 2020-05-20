using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Test
{
    public class DisplayInformationServiceTest
    {
        [Fact]
        public async Task GetInformation_WhenUserIdIsFound_ShouldBeHappyPath()
        {
            //Arrange
            var userInformationServiceMock =  new Mock<IUserInformationService>();
            var postInformationServiceMock = new Mock<IPostInformationService>();

            userInformationServiceMock.Setup(e => e.GetUser(It.IsAny<int>())).ReturnsAsync(new User
            {
                Id = 1,
                Name = "Toto"
            });
            
            postInformationServiceMock.Setup(e => e.GetPosts(It.IsAny<int>())).ReturnsAsync(
            new List<Post>
            {
                new Post { Title = "blabla"} , new Post { Title = "blabla2"}
            });

          
            // Act 
            var displayInformationServiceSut = new DisplayInformationService(userInformationServiceMock.Object, postInformationServiceMock.Object);
            var res = await displayInformationServiceSut.GetInformation(1);
            Assert.Equal(res.Count, 2);
        }
    }
}
