using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public interface IDeptMasterRepository<DeptMaster>
    {
        IEnumerable<DeptMaster> GetAllDept();

        DeptMaster GetDeptByCode(int code);

        bool SaveDept(DeptMaster deptMaster);

        bool DeleteDept(int code);

        bool UpdateDept(DeptMaster deptMaster);
    }
}
