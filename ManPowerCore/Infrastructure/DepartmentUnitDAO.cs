using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DepartmentUnitDAO
    {
        int SaveDepartmentUnit(DepartmentUnit departmentunit, DBConnection dbConnection);
        int UpdateDepartmentUnit(DepartmentUnit departmentunit, DBConnection dbConnection);
        List<DepartmentUnit> GetAllDepartmentUnit(DBConnection dbConnection);
        DepartmentUnit GetDepartmentUnit(int id, DBConnection dbConnection);
        List<DepartmentUnit> GetAllDepartmentUnitByDepartmentUnitTypeId(int DepartmentUnitTypeId, DBConnection dbConnection);
        List<DepartmentUnit> CheckDepartmentUnit(string runName, int runDepartmentUnitId, int ParentId, DBConnection dbConnection);

    }

    public class DepartmentUnitDAOImpl : DepartmentUnitDAO 
    {
        public int getMaxDepartmentUnitId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close(); 

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM DEPARTMENT_UNIT";
            int DepartmentUnitId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (DepartmentUnitId == 0)
            {
                DepartmentUnitId = 1;
            }
            else
            {
                DepartmentUnitId += 1;
            }


            return DepartmentUnitId;
        }

        public int SaveDepartmentUnit(DepartmentUnit departmentunit, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxDepartmentUnitId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO DEPARTMENT_UNIT(DEPARTMENT_UNIT_TYPE_ID, NAME, EMAIL, FAX, ADDRESS_LINE1, " +
                                            "ADDRESS_LINE2, ADDRESS_LINE3, PARENT_ID) values " +
                                            "(@DepartmentUnitTypeId,@Name,@Email,@FAX,@AddressLine1,@AddressLine2,@AddressLine3,@ParentId) ";

           
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentUnitTypeId", departmentunit.DepartmentUnitTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@Name", departmentunit.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Email", departmentunit.Email);
            dbConnection.cmd.Parameters.AddWithValue("@FAX", departmentunit.Fax);
            dbConnection.cmd.Parameters.AddWithValue("@AddressLine1", departmentunit.AddressLine1);
            dbConnection.cmd.Parameters.AddWithValue("@AddressLine2", departmentunit.AddressLine2);
            dbConnection.cmd.Parameters.AddWithValue("@AddressLine3", departmentunit.AddressLine3);
            dbConnection.cmd.Parameters.AddWithValue("@ParentId", departmentunit.ParentId);



            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateDepartmentUnit(DepartmentUnit departmentunit, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE DEPARTMENT_UNIT SET DEPARTMENT_UNIT_TYPE_ID = '" + departmentunit.DepartmentUnitTypeId + "', NAME = '" + departmentunit.Name + "', EMAIL = '" + departmentunit.Email + "', FAX = '" + departmentunit.Fax + "', ADDRESS_LINE1 = '" + departmentunit.AddressLine1 + "', ADDRESS_LINE2 = '" + departmentunit.AddressLine2 + "', ADDRESS_LINE3 = '" + departmentunit.AddressLine3 + "', PARENT_ID = '" + departmentunit.ParentId + "' WHERE ID = " + departmentunit.DepartmentUnitId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<DepartmentUnit> GetAllDepartmentUnit(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnit>(dbConnection.dr);

        }

        public DepartmentUnit GetDepartmentUnit(int id, DBConnection dbConnection)
        { 
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DepartmentUnit>(dbConnection.dr);

        }

        public List<DepartmentUnit> CheckDepartmentUnit(string runName,int runDepartmentUnitId,int ParentId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT WHERE NAME = '"+ runName + "' AND DEPARTMENT_UNIT_TYPE_ID = "+ runDepartmentUnitId + " AND PARENT_ID = "+ ParentId + "  ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnit>(dbConnection.dr);

        }

        public List<DepartmentUnit> GetAllDepartmentUnitByDepartmentUnitTypeId(int DepartmentUnitTypeId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT WHERE DEPARTMENT_UNIT_TYPE_ID = " + DepartmentUnitTypeId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnit>(dbConnection.dr);
        }

    }
}
