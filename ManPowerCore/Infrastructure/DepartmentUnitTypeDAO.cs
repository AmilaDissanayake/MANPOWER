using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DepartmentUnitTypeDAO
    {
        List<DepartmentUnitType> GetAllDepartmentUnitType(DBConnection dbConnection);
        DepartmentUnitType GetDepartmentUnitType(int id, DBConnection dbConnection);
    }

    public class DepartmentUnitTypeDAOImpl : DepartmentUnitTypeDAO
    {
        public List<DepartmentUnitType> GetAllDepartmentUnitType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_TYPE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnitType>(dbConnection.dr);

        }

        public DepartmentUnitType GetDepartmentUnitType(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_TYPE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DepartmentUnitType>(dbConnection.dr);

        }
    }
}
