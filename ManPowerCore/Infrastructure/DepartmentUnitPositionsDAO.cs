using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DepartmentUnitPositionsDAO
    {
        int SaveDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions, DBConnection dbConnection);
        int UpdateDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions, DBConnection dbConnection);
        List<DepartmentUnitPositions> GetAllDepartmentUnitPositions(DBConnection dbConnection);
        DepartmentUnitPositions GetDepartmentUnitPositions(int id, DBConnection dbConnection);
        List<DepartmentUnitPositions> GetAllDepartmentUnitPositionsByDepartmentUnitId(int departmentUnitId, DBConnection dbConnection);
        List<DepartmentUnitPositions> GetAllDepartmentUnitPositionsBySystemUserId(int systemUserId, DBConnection dbConnection);
        List<DepartmentUnitPositions> GetAllDepartmentUnitPositionByPossitionId(int possitionId, DBConnection dbConnection);

        List<DepartmentUnitPositions> GetAllUsersBySystemUserId(int runSystemUserId, DBConnection dbConnection);



    }

    public class DepartmentUnitPositionsDAOImpl : DepartmentUnitPositionsDAO
    {
        public int getMaxDepartmentUnitPositionsId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM DEPARTMENT_UNIT_POSSITIONS";
            int DepartmentUnitPositionsId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (DepartmentUnitPositionsId == 0)
            {
                DepartmentUnitPositionsId = 1;
            }
            else
            {
                DepartmentUnitPositionsId += 1;
            }


            return DepartmentUnitPositionsId;
        }

        public int SaveDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxDepartmentUnitPositionsId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO DEPARTMENT_UNIT_POSSITIONS(SYSTEM_USER_ID, POSSITIONS_ID, DEPARTMENT_UNIT_ID, PARENT_ID) values " +
                "(@SystemUserId,@PossitionsId,@DepartmentUnitId,@ParentId) ";


            dbConnection.cmd.Parameters.AddWithValue("@SystemUserId", departmentUnitPositions.SystemUserId);
            dbConnection.cmd.Parameters.AddWithValue("@PossitionsId", departmentUnitPositions.PossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentUnitId", departmentUnitPositions.DepartmentUnitId);
            dbConnection.cmd.Parameters.AddWithValue("@ParentId", departmentUnitPositions.ParentId);

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE DEPARTMENT_UNIT_POSSITIONS SET SYSTEM_USER_ID = '" + departmentUnitPositions.SystemUserId + "', POSSITIONS_ID = '" + departmentUnitPositions.PossitionsId + "', DEPARTMENT_UNIT_ID = '" + departmentUnitPositions.DepartmentUnitId + "', PARENT_ID = '" + departmentUnitPositions.ParentId + "' WHERE ID = " + departmentUnitPositions.DepartmetUnitPossitionsId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<DepartmentUnitPositions> GetAllDepartmentUnitPositions(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_POSSITIONS ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnitPositions>(dbConnection.dr);

        }

        public DepartmentUnitPositions GetDepartmentUnitPositions(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_POSSITIONS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<DepartmentUnitPositions>(dbConnection.dr);

        }


        public List<DepartmentUnitPositions> GetAllDepartmentUnitPositionsByDepartmentUnitId(int departmentUnitId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_POSSITIONS WHERE DEPARTMENT_UNIT_ID = " + departmentUnitId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnitPositions>(dbConnection.dr);
        }


        public List<DepartmentUnitPositions> GetAllDepartmentUnitPositionsBySystemUserId(int systemUserId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_POSSITIONS WHERE SYSTEM_USER_ID = " + systemUserId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnitPositions>(dbConnection.dr);
        }

        public List<DepartmentUnitPositions> GetAllDepartmentUnitPositionByPossitionId(int possitionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_POSSITIONS WHERE POSSITIONS_ID = " + possitionId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnitPositions>(dbConnection.dr);
        }

        public List<DepartmentUnitPositions> GetAllUsersBySystemUserId(int runSystemUserId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPARTMENT_UNIT_POSSITIONS WHERE SYSTEM_USER_ID = " + runSystemUserId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DepartmentUnitPositions>(dbConnection.dr);
        }
    }
}
