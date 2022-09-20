using BoluBreakfast.Models;
using ErrorOr;
using BoluBreakfast.Services;
using BoluBreakfast.ServiceError;

namespace BoluBreakfast.Services;
public class BreakfastService : IBreakfastService 
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
        return Result.Created;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }
        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<UpsertedBreakfast> UpSertBreakfast(Breakfast breakfast)
    {
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.id);
        _breakfasts[breakfast.Id] = breakfast;
        return new UpsertedBreakfast(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id); 
        return Result.Deleted;  
    }
}