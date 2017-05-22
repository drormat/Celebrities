using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CelebritiesAPI.Core.DataLayer;
using CelebritiesAPI.Core.EntityLayer;
using CelebritiesAPI.Extensions;
using CelebritiesAPI.Responses;
using CelebritiesAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CelebritiesAPI.Controllers
{
  [Route("api/[controller]")]
  public class CelebritiesController : Controller
  {

    private ICelebritiesRepository CelebritiesRepository;

    public CelebritiesController(ICelebritiesRepository repository)
    {
      CelebritiesRepository = repository;
    }

    protected override void Dispose(Boolean disposing)
    {
      CelebritiesRepository?.Dispose();

      base.Dispose(disposing);
    }

    [HttpGet]
    [Route("IsAlive")]
    public IActionResult IsAlive()
    {
      var response = new SingleModelResponse<String>() as ISingleModelResponse<String>;
      response.Message = String.Format("CelebritiesAPI is up and running");
      return response.ToHttpResponse();
    }

    [HttpGet]
    [Route("Celebrity")]
    public async Task<IActionResult> GetCelebrities(String name = null)
    {
      var response = new ListModelResponse<CelebrityViewModel>() as IListModelResponse<CelebrityViewModel>;
      try
      {

        response.Model = await CelebritiesRepository
                .GetCelebrities()
                .Select(item => item.ToViewModel())
                .ToListAsync();

        response.Message = String.Format("Total of records: {0}", response.Model.Count());
      }
      catch (Exception ex)
      {
        response.DidError = true;
        response.ErrorMessage = ex.Message;
      }

      return response.ToHttpResponse();
    }


    [HttpGet]
    [Route("Celebrity/{id}")]
    public async Task<IActionResult> GetCelebrity(int id)
    {
      var response = new SingleModelResponse<CelebrityViewModel>() as ISingleModelResponse<CelebrityViewModel>;

      try
      {
        var entity = await CelebritiesRepository.GetCelebrityAsync(new Celebrity { ID = id });

        response.Model = entity.ToViewModel();
      }
      catch (Exception ex)
      {
        response.DidError = true;
        response.ErrorMessage = ex.Message;
      }

      return response.ToHttpResponse();
    }

    [HttpPost]
    [Route("Celebrity")]
    public async Task<IActionResult> CreateCelebrity([FromBody]CelebrityViewModel value)
    {
      var response = new SingleModelResponse<CelebrityViewModel>() as ISingleModelResponse<CelebrityViewModel>;

      try
      {
        var entity = await CelebritiesRepository.AddCelebrityAsync(value.ToEntity());

        response.Model = entity.ToViewModel();
        response.Message = "The data was saved successfully";
      }
      catch (Exception ex)
      {
        response.DidError = true;
        response.ErrorMessage = ex.ToString();
      }

      return response.ToHttpResponse();
    }

    [HttpPut]
    [Route("Celebrity")]
    public async Task<IActionResult> UpdateCelebrity([FromBody]CelebrityViewModel value)
    {
      var response = new SingleModelResponse<CelebrityViewModel>() as ISingleModelResponse<CelebrityViewModel>;

      try
      {
        var entity = await CelebritiesRepository.UpdateCelebrityAsync(value.ToEntity());

        response.Model = entity.ToViewModel();
        response.Message = "The record was updated successfully";
      }
      catch (Exception ex)
      {
        response.DidError = true;
        response.ErrorMessage = ex.Message;
      }

      return response.ToHttpResponse();
    }


    [HttpDelete]
    [Route("Celebrity/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      var response = new SingleModelResponse<CelebrityViewModel>() as ISingleModelResponse<CelebrityViewModel>;

      try
      {
        var entity = await CelebritiesRepository.DeleteCelebrityAsync(new Celebrity { ID = id });

        response.Model = entity.ToViewModel();
        response.Message = "The record was deleted successfully";
      }
      catch (Exception ex)
      {
        response.DidError = true;
        response.ErrorMessage = ex.Message;
      }

      return response.ToHttpResponse();
    }
  }
  
}
