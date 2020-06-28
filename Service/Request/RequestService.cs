using System.Linq;
using System.Collections.Generic;
using ducky_api_server.Repo.Request;
using ducky_api_server.Repo.Servers;
using ducky_api_server.Repo.Collections;
using ducky_api_server.DTO.Request;
using ducky_api_server.Extensions;
using ducky_api_server.Repo.RequestBody;
using ducky_api_server.Repo.RequestParameters;
using ducky_api_server.Repo.RequestHeaders;

namespace ducky_api_server.Service.Request
{
    public class RequestService : IRequestService
    {
        private RequestRepo repo = new RequestRepo();
        private ServersRepo serversRepo = new ServersRepo();
        private CollectionsRepo collectionsRepo = new CollectionsRepo();
        private RequestBodyRepo requestBodyRepo = new RequestBodyRepo();
        private RequestParamsRepo requestParamsRepo = new RequestParamsRepo();
        private RequestHeadersRepo requestHeadersRepo = new RequestHeadersRepo();

        public List<RequestTreeDTO> GetDocuments()
        {
            List<RequestTreeDTO> result = new List<RequestTreeDTO>();
            var documents = repo.GetAllDocuments();
            var servers = serversRepo.GetAll().OrderBy(x => x.Order).ToList();
            var collections = collectionsRepo.GetAll();
            var headers = requestHeadersRepo.GetAll();
            var body = requestBodyRepo.GetAll();
            var parameters = requestParamsRepo.GetAll();

            // 递归组装一下数据
            foreach (var item in servers)
            {
                result.Add(new RequestTreeDTO
                {
                    ID = item.ID,
                    PID = "",
                    Title = item.Name,
                    Open = false,
                    Request = null,
                    IsCollection = false,
                    IsServer = true,
                    ServerID = item.ID
                });
                // 
                var serverCollections = collections.Where(x => x.ServerID == item.ID).ToList();
                foreach (var collection in serverCollections)
                {
                    result.Add(new RequestTreeDTO
                    {
                        ID = collection.ID,
                        PID = collection.ServerID,
                        Title = collection.Name,
                        Open = false,
                        IsCollection = true,
                        IsServer = false,
                        Request = null,
                        ServerID = collection.ServerID,
                        CollectionID = collection.ID
                    });
                    // 
                    var requests = documents.Where(x => x.CollectionID == collection.ID).ToList();
                    foreach (var req in requests)
                    {
                        req.Path = new List<string>{item.Name,collection.Name,req.Name};
                        req.Headers = headers.Filter(x=>x.RequestID == req.ID);
                        req.Body = body.Filter(x=>x.RequestID == req.ID);
                        req.Parameters = parameters.Filter(x=>x.RequestID == req.ID);
                        result.Add(new RequestTreeDTO
                        {
                            ID = req.ID,
                            PID = req.CollectionID,
                            Title = req.Name,
                            Open = false,
                            IsCollection = false,
                            IsServer = false,
                            Request = req,
                            ServerID = item.ID,
                            CollectionID = req.CollectionID
                        });
                    }
                }
            }
            return result;
        }
        public bool Update(string id, RequestDTO dto)
        {
            var success = repo.UpdateRequestDocument(id, dto);
            if (success)
            {
                //
                requestHeadersRepo.Remove(id);
                // 保存请求头
                requestHeadersRepo.Add(id,dto.Headers);
                //
                requestParamsRepo.Remove(id);
                // 保存请求parameters
                requestParamsRepo.Add(id,dto.Parameters);
                //
                requestBodyRepo.Remove(id);
                // 保存请求body
                requestBodyRepo.Add(id,dto.Body);
            }
            return success;
        }
        public bool Remove(string id)
        {
            return repo.RemoveDocument(id);
        }
        public bool Rename(string id, string name)
        {
            if (id.IsEmpty() || name.IsEmpty())
            {
                return false;
            }
            return repo.Rename(id,name);
        }

        public (bool success,string msg) Send(string id)
        {
            if (id.IsEmpty())
            {
                return (false, SystemMessage.MissingKeyParameters);
            }
            var request = repo.Get(id);
            if (!request.IsNull())
            {
                request.Headers = requestHeadersRepo.Get(request.ID);
                request.Body =  requestBodyRepo.Get(request.ID);
                request.Parameters =  requestParamsRepo.Get(request.ID);

                bool isJson = request.ContentType == "json";
                // 初始化http请求
                var http = new Http(request.Address)
                {
                   ContentType = isJson ? HttpContentType.Json : HttpContentType.Form,
                   Method = request.Method.ToUpper(),
                };
                // 设置请求头
                foreach (var item in request.Headers)
                {
                    http.Headers.Add(item.Key,item.Value);
                }
                // 根据配置设置请求参数
                switch (request.ContentType.ToLower())
                {
                    case "params":
                        {
                            var dic = new Dictionary<string,string>();
                            request.Parameters.ForEach(x=>{
                                dic.Add(x.Key,x.Value);
                            });
                            http.Parameters = dic;
                        }
                        break;
                    case "json":
                        {
                            http.Body = request.Json;
                        }
                        break;
                    case "form":
                        {
                            var dic = new Dictionary<string,string>();
                            request.Body.ForEach(x=>{
                                dic.Add(x.Key,x.Value);
                            });
                            http.Parameters = dic;
                        }
                        break;
                    default:
                        break;
                }
                // 
                string response = string.Empty;
                try
                {
                    response= http.BeginRequest();
                    return (true,response);
                }
                catch (System.Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (false,SystemMessage.SystemDoesNotHaveRequestConfig);
        }
    }
}