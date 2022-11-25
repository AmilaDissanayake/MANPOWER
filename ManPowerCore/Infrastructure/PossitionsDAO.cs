using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface PossitionsDAO
    {

        int SavePosition(Possitions possitions, DBConnection dbConnection);
         List<Possitions> GetAllPossitions(DBConnection dbConnection);
        Possitions GetPossitions(int id, DBConnection dbConnection);
        List<Possitions> GetAllPossitionsById(int runPosition, DBConnection dbConnection);
        List<Possitions> CheckPossitionsByName(string runPositionName, DBConnection dbConnection);

    }

    public class PossitionsDAOImpl : PossitionsDAO

    {

        public int getMaxPositionId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM POSSITIONS";
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

        public int SavePosition(Possitions possitions, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxPositionId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO POSSITIONS(NAME) values (@PositionName) ";


            dbConnection.cmd.Parameters.AddWithValue("@PositionName", possitions.PositionName);

            return dbConnection.cmd.ExecuteNonQuery();
        }




        public List<Possitions> GetAllPossitions(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM POSSITIONS ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Possitions>(dbConnection.dr);

        }

        public List<Possitions> GetAllPossitionsById(int runPosition,DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM POSSITIONS WHERE ID = "+ runPosition + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Possitions>(dbConnection.dr);

        }

        public Possitions GetPossitions(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM POSSITIONS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Possitions>(dbConnection.dr);

        }

        public List<Possitions> CheckPossitionsByName(string runPositionName, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM POSSITIONS WHERE NAME = '" + runPositionName + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Possitions>(dbConnection.dr);

        }
    }
}
