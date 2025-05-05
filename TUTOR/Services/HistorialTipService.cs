using TUTOR.Model;
using TUTOR.Repository;

public interface IHistorialTipService
{
    Task<IEnumerable<HistorialTip>> GetAllAsync();
    Task<HistorialTip?> GetByIdAsync(int id);
    Task AddAsync(HistorialTip historialTip);
    Task UpdateAsync(HistorialTip historialTip);
    Task DeleteAsync(HistorialTip historialTip);
}

public class HistorialTipService : IHistorialTipService
{
    private readonly IHistorialTipRepository _repository;

    public HistorialTipService(IHistorialTipRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HistorialTip>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<HistorialTip?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task AddAsync(HistorialTip historialTip)
        => await _repository.AddAsync(historialTip);

    public async Task UpdateAsync(HistorialTip historialTip)
        => await _repository.UpdateAsync(historialTip);

    public async Task DeleteAsync(HistorialTip historialTip)
        => await _repository.DeleteAsync(historialTip);
}
