using Auth.App.Dto.Role;
using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Users;
using Auth.Domain.Services.Services;
using Auth.Infrastruture.CrossCutting.Exceptions;
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

public class RoleServiceTest
{
    private readonly IRoleService _service;

    //Mocks
    private readonly IMapper _mapper;
    private readonly INotificationHandle _notification;
    private readonly ILogger<RoleService> _logger;
    private readonly Mock<IRoleRepository> _repoMock;

    public RoleServiceTest()
    {
        _mapper = AutoMapperConfiguration.GetConfiguration();
        _repoMock = new Mock<IRoleRepository>();
        _service = new RoleService(notification: _notification, mapper: _mapper, repo: _repoMock.Object, logger: _logger);
    }

    #region Create
    [Fact(DisplayName = "Create Valid Role")]
    [Trait("Category", "Services")]
    public async Task Create_WhenRoleIsValid_ReturnsRolesDto()
    {
        // Arrange
        var create = RoleFixture.CreateValidDTO();
        var created = _mapper.Map<Role>(create);

        _repoMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(() => null);

        _repoMock.Setup(x => x.Create(It.IsAny<Role>())).ReturnsAsync(() => created);

        // Act
        var result = await _service.Create(create);

        // Assert
        result.Should()
              .BeEquivalentTo(_mapper.Map<RolesDto>(created));
    }

    [Fact(DisplayName = "Create When Role Exists")]
    [Trait("Category", "Services")]
    public void Create_WhenRoleExists_ThrowsNewDomainException()
    {
        // Arrange
        var create = RoleFixture.CreateValidDTO();
        var exists = RoleFixture.CreateValid();

        _repoMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(() => exists);

        // Act
        Func<Task<RolesDto>> act = async () =>
        {
            return await _service.Create(create);
        };

        // Act
        act.Should()
           .ThrowAsync<Exceptions>()
           .WithMessage($"Já existe registro cadastrado com o nome: {create.Name} informado.");
    }

    [Fact(DisplayName = "Create When Role is Invalid")]
    [Trait("Category", "Services")]
    public void Create_WhenRoleIsInvalid_ThrowsNewDomainException()
    {
        // Arrange
        var create = RoleFixture.CreateInvalidDTO();

        _repoMock.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(() => null);

        // Act
        Func<Task<RolesDto>> act = async () =>
        {
            return await _service.Create(create);
        };

        // Act
        act.Should()
           .ThrowAsync<Exceptions>();
    }
    #endregion Create

    #region Update

    [Fact(DisplayName = "Update Valid Role")]
    [Trait("Category", "Services")]
    public async Task Update_WhenRoleIsValid_ReturnsRolesDto()
    {
        // Arrange
        var old = RoleFixture.CreateValid();
        var update = RoleFixture.CreateValidDTO();
        var updated = _mapper.Map<Role>(update);

        _repoMock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(() => old);

        _repoMock.Setup(x => x.Update(It.IsAny<Role>())).ReturnsAsync(() => updated);

        // Act
        var result = await _service.Update(update);

        // Assert
        result.Should()
              .BeEquivalentTo(_mapper.Map<RolesDto>(updated));
    }

    [Fact(DisplayName = "Update When Role Not Exists")]
    [Trait("Category", "Services")]
    public void Update_WhenRoleNotExists_ThrowsNewDomainException()
    {
        // Arrange
        var update = RoleFixture.CreateValidDTO();

        _repoMock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(() => null);

        // Act
        Func<Task<RolesDto>> act = async () =>
        {
            return await _service.Update(update);
        };

        // Act
        act.Should()
            .ThrowAsync<Exceptions>()
            .WithMessage($"Não existe nenhum registo com o id: {update.Id} informado!");
    }

    [Fact(DisplayName = "Update When Role is Invalid")]
    [Trait("Category", "Services")]
    public void Update_WhenRoleIsInvalid_ThrowsNewDomainException()
    {
        // Arrange
        var old = RoleFixture.CreateValid();
        var update = RoleFixture.CreateInvalidDTO();

        _repoMock.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(() => old);

        // Act
        Func<Task<RolesDto>> act = async () =>
        {
            return await _service.Update(update);
        };

        // Act
        act.Should()
            .ThrowAsync<Exceptions>();
    }

    #endregion

    #region Remove

    [Fact(DisplayName = "Remove Role")]
    [Trait("Category", "Services")]
    public async Task Remove_WhenRoleExists_RemoveProduct()
    {
        // Arrange
        var id = new Randomizer().Int(0, 1000);

        _repoMock.Setup(x => x.Remove(It.IsAny<int>())).Verifiable();

        // Act
        await _service.Remove(id);

        // Assert
        _repoMock.Verify(x => x.Remove(id), Times.Once);
    }

    #endregion

    #region Get

    [Fact(DisplayName = "Get By Id")]
    [Trait("Category", "Services")]
    public async Task GetById_WhenRoleExists_ReturnsRolesDto()
    {
        // Arrange
        var id = new Randomizer().Int(0, 1000);
        var found = RoleFixture.CreateValid();

        _repoMock.Setup(x => x.Get(id)).ReturnsAsync(() => found);

        // Act
        var result = await _service.Get(id);

        // Assert
        result.Should()
              .BeEquivalentTo(_mapper.Map<RolesDto>(found));
    }

    [Fact(DisplayName = "Get By Id When Role Not Exists")]
    [Trait("Category", "Services")]
    public async Task GetById_WhenRoleNotExists_ReturnsNull()
    {
        // Arrange
        var id = new Randomizer().Int(0, 1000);

        _repoMock.Setup(x => x.Get(id)).ReturnsAsync(() => null);

        // Act
        var result = await _service.Get(id);

        // Assert
        result.Should()
            .Be(null);
    }

    [Fact(DisplayName = "Get All Role")]
    [Trait("Category", "Services")]
    public async Task GetAllUsers_WhenRoleExists_ReturnsAListOfRolesDto()
    {
        // Arrange
        var found = RoleFixture.CreateListValid();

        _repoMock.Setup(x => x.Get()).ReturnsAsync(() => found);

        // Act
        var result = await _service.Get();

        // Assert
        result.Should()
              .BeEquivalentTo(_mapper.Map<List<RolesDto>>(found));
    }

    [Fact(DisplayName = "Get All Roles When None Role Found")]
    [Trait("Category", "Services")]
    public async Task GetAllRole_WhenNoneUserFound_ReturnsEmptyList()
    {
        // Arrange

        _repoMock.Setup(x => x.Get()).ReturnsAsync(() => null);

        // Act
        var result = await _service.Get();

        // Assert
        result.Should()
              .BeEmpty();
    }

    #endregion

    #region Search

    //[Fact(DisplayName = "Search By Name")]
    //[Trait("Category", "Services")]
    //public async Task SearchByName_WhenAnyProductFound_ReturnsAListOfProductDTO()
    //{
    //    // Arrange
    //    var search = new Name().JobArea();
    //    var found = ProductFixture.CreateListSearchValid();

    //    _repoMock.Setup(x => x.GetSearch(search, 1, 10)).ReturnsAsync(() => found);

    //    // Act
    //    var result = await _service.GetSearch(search, 1, 10);

    //    // Assert
    //    result.Should().BeEquivalentTo(_mapper.Map<PageDto>(found));
    //}

    //[Fact(DisplayName = "Search Paginator error")]
    //[Trait("Category", "Services")]
    //public async Task SearchByName_WhenAnyProductErrorPaginatorDTO()
    //{
    //    // Arrange
    //    var search = new Name().JobArea();
    //    var found = ProductFixture.CreateListSearchValid();

    //    _repoMock.Setup(x => x.GetSearch(search, 1, 10)).ReturnsAsync(() => found);

    //    // Act
    //    var result = await _service.GetSearch(search, 1, 10);

    //    // Act
    //    Func<Task<PageDto>> act = async () =>
    //    {
    //        return await _service.GetSearch(search, 1, 300);
    //    };

    //    // Act
    //    act.Should()
    //       .ThrowAsync<Exceptions>()
    //       .WithMessage($"Paginação inválida!");
    //}

    #endregion
}

