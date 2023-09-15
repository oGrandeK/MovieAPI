using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Services;

public class DirectorService : IDirectorService
{
    private readonly IAddDirectorUseCase _addDirectorUseCase;
    private readonly IDeleteDirectorUseCase _deleteDirectorUseCase;
    private readonly IListAllDirectorsUseCase _listAllDirectors;
    private readonly IListDirectorByIdUseCase _listDirectorById;
    private readonly IListDirectorByNameUseCase _listDirectorByName;
    private readonly IUpdateDirectorUseCase _updateDirectorUseCase;

    public DirectorService(IAddDirectorUseCase addDirectorUseCase, IDeleteDirectorUseCase deleteDirectorUseCase, IListAllDirectorsUseCase listAllDirectors, IListDirectorByIdUseCase listDirectorById, IListDirectorByNameUseCase listDirectorByName, IUpdateDirectorUseCase updateDirectorUseCase)
    {
        _addDirectorUseCase = addDirectorUseCase;
        _deleteDirectorUseCase = deleteDirectorUseCase;
        _listAllDirectors = listAllDirectors;
        _listDirectorById = listDirectorById;
        _listDirectorByName = listDirectorByName;
        _updateDirectorUseCase = updateDirectorUseCase;
    }

    public async Task AddDirector(Director directorData) => await _addDirectorUseCase.Execute(directorData);

    public async Task DeleteDirector(int id) => await _deleteDirectorUseCase.Execute(id);

    public async Task<IEnumerable<Director>> ListAllDirectors() => await _listAllDirectors.Execute();

    public async Task<Director> ListDirectorById(int id) => await _listDirectorById.Execute(id);

    public async Task<IEnumerable<Director>> ListDirectorByName(string name) => await _listDirectorByName.Execute(name);

    public async Task UpdateDirector(int id, Director directorData) => await _updateDirectorUseCase.Execute(id, directorData);
}