using CelebritiesAPI.Models;
using CelebritiesAPI.ViewModels;
using CelebritiesAPI.Core.EntityLayer;


namespace CelebritiesAPI.Extensions
{
  public static class CelebrityViewModelMapper
  {
    public static CelebrityViewModel ToViewModel(this Celebrity entity)
    {
      return entity == null ? null : new CelebrityViewModel
      {
        ID = entity.ID,
        CelebrityName = entity.Name,
        CelebrityAge = entity.Age,
        CelebrityCountry = entity.Country
      };
    }

    public static Celebrity ToEntity(this CelebrityViewModel viewModel)
    {
      return viewModel == null ? null : new Celebrity
      {
        ID = viewModel.ID,
        Name = viewModel.CelebrityName,
        Age = viewModel.CelebrityAge,
        Country = viewModel.CelebrityCountry
      };
    }
  }
}
