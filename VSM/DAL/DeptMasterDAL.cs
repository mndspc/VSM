using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeptMasterDAL : IDeptMasterRepository<DeptMaster>
    {
        public bool DeleteDept(int code)
        {
            try {
                using (EMPDBEntities dbContext=new EMPDBEntities())
                {
                    var emp = dbContext.DeptMasters.Where(x=>x.DeptCode==code).FirstOrDefault();
                    dbContext.DeptMasters.Remove(emp);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<DeptMaster> GetAllDept()
        {
            try
            {
                using (EMPDBEntities dbContext = new EMPDBEntities())
                {
                    var employees = dbContext.DeptMasters.ToList();
                    return employees;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DeptMaster GetDeptByCode(int code)
        {
            try
            {
                using (EMPDBEntities dbContext = new EMPDBEntities())
                {
                    var emp = dbContext.DeptMasters.Where(x=>x.DeptCode==code).FirstOrDefault();
                    return emp;
                }
              }catch(Exception ex)
            {
                return null;
            }
        }

        public bool SaveDept(DeptMaster deptMaster)
        {
            try
            {
                using (EMPDBEntities dbContext=new EMPDBEntities())
                {
                    dbContext.DeptMasters.Add(deptMaster);
                    dbContext.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool UpdateDept(DeptMaster deptMaster)
        {
            try
            {
                using (EMPDBEntities dbContext = new EMPDBEntities())
                {
                    var oldEmp = dbContext.DeptMasters.Where(x => x.DeptCode == deptMaster.DeptCode).FirstOrDefault();
                    oldEmp.DeptCode = deptMaster.DeptCode;
                    oldEmp.DeptName = deptMaster.DeptName;
                    dbContext.SaveChanges();
                    return true;
                }
             }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
