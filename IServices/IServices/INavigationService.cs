using Dtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IServices.IServices
{
    public interface INavigationService
    {
        NavigationsResultModel GetNavigations(string language = null);
    }
}