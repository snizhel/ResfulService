using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmpClient
{
    class EmpBUS
    {
        String URI = "http://snizhel.somee.com/api/employees";
       public List<Emp> GetAll()
       {
            WebClient client = new WebClient();
            String res=client.DownloadString(URI);
            List<Emp>emps= JsonConvert.DeserializeObject<List<Emp>>(res);
            return emps;
       }
        public Emp GetEmps(int id)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI+"/"+id);
           Emp emp = JsonConvert.DeserializeObject<Emp>(res);
            return emp;
        }
        public bool Add(Emp emp)
        {
            String data = JsonConvert.SerializeObject(emp);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI,"POST",data);
            bool result=bool.Parse(res);
            return result;
           
        }
        public bool Delete(int id)
        {
            WebClient client = new WebClient();
            String res = client.UploadString(URI + "/" + id,"DELETE","");
            bool result = bool.Parse(res);
            return result;
        }
        public bool Update(Emp emp)
        {
            String data = JsonConvert.SerializeObject(emp);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "/" + emp.ID, "PUT", data);
            bool result = bool.Parse(res);
            return result;
        }
        public List<Emp> Search(String keyword)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "/search/" + keyword);
            List<Emp> emps = JsonConvert.DeserializeObject<List<Emp>>(res);
            return emps;
        }
    }
}
