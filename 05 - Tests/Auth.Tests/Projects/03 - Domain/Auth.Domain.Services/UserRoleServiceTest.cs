using Auth.App.Dto.UserRole;
using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Users;
using Auth.Domain.Services.Services;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Tests.Configurations.AutoMapper;
using Auth.Tests.Fixtures;
using AutoMapper;
using Bogus;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Auth.Tests.Projects._03___Domain.Auth.Domain.Services;

public class UserRoleServiceTest
{
    private readonly IUserRoleService _service;

    private readonly IMapper _mapper;
    private readonly INotificationHandle _notification;
    private readonly ILogger<UserRoleService> _logger;

    //Mocks
    private readonly Mock<IUserRoleRepository> _repoMock;

    public UserRoleServiceTest()
    {
        _mapper = AutoMapperConfiguration.GetConfiguration();
        _repoMock = new Mock<IUserRoleRepository>();
        _service = new UserRoleService(notification: _notification, mapper: _mapper, repo: _repoMock.Object, logger: _logger);
    }

    #region Create
    [Fact(DisplayName = "Create Valid UserRole")]
    [Trait("Category", "Services")]
    public async Task Create_WhenUserRoleIsValid_ReturnsUserRoleDto()
    {
        // Arrange
        var create = UserRoleFixture.CreateValidDTO();
        var created = _mapper.Map<UserRole>(create);

        _repoMock.Setup(x => x.GetById(created)).ReturnsAsync(() => null);

        _repoMock.Setup(x => x.Create(It.IsAny<UserRole>())).ReturnsAsync(() => created);

        // Act
        var result = await _service.Create(create);

        // Assert
        result.Should()
              .BeEquivalentTo(_mapper.Map<CreateUserRoleDto>(created));
    }
    #endregion Create

    #region Remove

    [Fact(DisplayName = "Remove Role")]
    [Trait("Category", "Services")]
    public async Task Remove_WhenUserRoleExists_RemoveUserRole()
    {
        // Arrange
        var id = new Randomizer().Int(0, 1000);

        _repoMock.Setup(x => x.Remove(It.IsAny<int>())).Verifiable();

        // Act
        await _service.Remove(id);

        // Assert
        _repoMock.Verify(x => x.Remove(id), Times.Once);
    }

    [Fact(DisplayName = "Remove UserRole All")]
    [Trait("Category", "Services")]
    public async Task Remove_WhenUserRoleExists_RemoveUserRoleAll()
    {
        // Arrange
        var create = UserRoleFixture.GetUserRoleValid();

        _repoMock.Setup(x => x.GetById(create.UserId)).ReturnsAsync(() => null);

        _repoMock.Setup(x => x.Remove(It.IsAny<int>())).Verifiable();

        // Act
        await _service.RemoveAll(UserRoleFixture.GetUserRoleValidDto());
    }

    #endregion

}

