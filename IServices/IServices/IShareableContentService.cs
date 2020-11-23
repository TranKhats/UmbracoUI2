using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.IServices
{
    public interface IShareableContentService
    {
        object GetShareableContent<T>(int id) where T : class;
        object GetShareableContent<T>(string alias) where T : class;
    }
}
