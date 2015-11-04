using BookStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    [ServiceContract]
    public interface IBooksService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Book> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{id}")]
        Book GetById(string id);

        [WebInvoke(Method = "POST", UriTemplate = "")]
        [OperationContract]
        Book Add(Book book);
    }
}
