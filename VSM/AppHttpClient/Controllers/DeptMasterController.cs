using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppHttpClient.Controllers
{
    [Route("DeptMaster/")]
    public class DeptMasterController : Controller
    {
        // GET: DeptMaster
        [HttpGet]
        [Route("GetAllDept")]
        public async Task<ActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59700/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("GetDepts");
                if (response.IsSuccessStatusCode)
                {
                    var depts = await response.Content.ReadAsAsync<DeptMaster[]>();
                    return View(depts);
                }
                else
                {
                    return Content("No Data");
                }
            }
        }

        [HttpGet]
        [Route("GetDeptByCode/{id}")]
        public async Task<ActionResult> GetByCode(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59700/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync($"GetDeptByCode/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var dept = await response.Content.ReadAsAsync<DeptMaster>();
                    return View(dept);
                }
                else
                {
                    return Content("No Data");
                }
            }
        }

        [HttpPost]
        [Route("SaveDept")]
        public async Task<ActionResult> SaveDept(DeptMaster deptMaster)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59700/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage responsePost = await client.PostAsJsonAsync("SaveDept", deptMaster);
                if (responsePost.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllDept");
                }
                else
                {
                    return View("SaveDept");
                }
            }

        }

        [HttpPost]
        [Route("DeleteDept/{id}")]
        public async Task<ActionResult> DeleteDept(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59700/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage responsePost = await client.DeleteAsync($"DeleteDept/{id}");
                if (responsePost.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllDept");
                }
                else
                {
                    return View("DeleteDept");
                }
            }
        }

        [HttpPost]
        [Route("UpdateDept")]
        public async Task<ActionResult> UpdateDept(DeptMaster deptMaster)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59700/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //POST Method
                HttpResponseMessage responsePost = await client.PutAsJsonAsync($"UpdateDept",deptMaster);
                if (responsePost.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllDept");
                }
                else
                {
                    return View("UpdateDept");
                }
            }
        }
    }


}