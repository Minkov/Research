using System.Linq;
using BookStore.Services.Models;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BookStore.Services.Services
{
    [ServiceContract]
    public interface IAuthorsService
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        Author Add(Author author);

        [WebInvoke(Method = "GET", UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        IQueryable<Author> GetAll();


        [WebInvoke(Method = "GET", UriTemplate = "/{id}", ResponseFormat = WebMessageFormat.Json)]
        Author GetById(string id);
    }
}