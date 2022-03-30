using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
namespace AppServiceLayer.Controllers
{
    [Route("api/DeptMaster/")]
    public class DeptMasterController : ApiController
    {
        DeptMasterDAL deptMasterDAL = new DeptMasterDAL();

        [HttpGet]
        [Route("GetDepts")]
        public HttpResponseMessage GetAllDept()
        {
            var employees = deptMasterDAL.GetAllDept();
            return Request.CreateResponse(HttpStatusCode.OK, employees);
        }

        [HttpGet]
        [Route("GetDeptByCode/{id}")]
        public HttpResponseMessage GetDeptByDeptCode(int id)
        {
            var emp = deptMasterDAL.GetDeptByCode(id);
            return Request.CreateResponse(HttpStatusCode.OK, emp);
        }

        [HttpPost]
        [Route("SaveDept")]
        public HttpResponseMessage PostDept([FromBody]DeptMaster deptMaster)
        {
            deptMasterDAL.SaveDept(deptMaster);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("DeleteDept/{id}")]
        public HttpResponseMessage DeleteDept(int id)
        {
            deptMasterDAL.DeleteDept(id);
            return Request.CreateResponse(HttpStatusCode.Gone);
        }

        [HttpPut]
        [Route("UpdateDept")]
        public HttpResponseMessage PutDept([FromBody]DeptMaster deptMaster)
        {
            deptMasterDAL.UpdateDept(deptMaster);
            return Request.CreateResponse(HttpStatusCode.Accepted);

        }
    }
}
