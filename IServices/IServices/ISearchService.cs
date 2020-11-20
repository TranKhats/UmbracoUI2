using Dtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.IServices
{
    public interface ISearchService
    {
        SearchResultsModel Search(string query);
    }
}
