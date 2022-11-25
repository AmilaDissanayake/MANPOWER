using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface PossitionsController
    {
        int SavePosition(Possitions possitions);
        List<Possitions> GetAllPossitions(bool withDepartmentUnitPositions);
        Possitions GetPossitions(int id, bool withDepartmentUnitPositions);
        List<Possitions> GetAllPossitions(int runPosition);
        List<Possitions> GetAllPossitions(string runPositionName);
    }

    public class PossitionsControllerImpl : PossitionsController
    {
        DBConnection dBConnection;
        PossitionsDAO possitionsDAO = DAOFactory.CreatePossitionsDAO();



        public int SavePosition(Possitions possitions)
        {
            try
            {
                dBConnection = new DBConnection();
                return possitionsDAO.SavePosition(possitions, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<Possitions> GetAllPossitions(string runPositionName)
        {
            try
            {
                dBConnection = new DBConnection();
                List<Possitions> list = possitionsDAO.CheckPossitionsByName(runPositionName, dBConnection);
                return list;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }


        public List<Possitions> GetAllPossitions(bool withDepartmentUnitPositions)
        {
            try
            {
                dBConnection = new DBConnection();
                List<Possitions> list = possitionsDAO.GetAllPossitions(dBConnection);

                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnitPositions = _DepartmentUnitPositionsDAO.GetAllDepartmentUnitPositionByPossitionId(item.PossitionId, dBConnection);
                    }
                }

                return list;

            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public List<Possitions> GetAllPossitions(int runPosition)
        {
            try
            {
                dBConnection = new DBConnection();
                List<Possitions> list = possitionsDAO.GetAllPossitionsById(runPosition,dBConnection);
                return list;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

                public Possitions GetPossitions(int id, bool withDepartmentUnitPositions)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                PossitionsDAO DAO = DAOFactory.CreatePossitionsDAO();
                Possitions _Possitions = DAO.GetPossitions(id, dbConnection);



                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsController = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    _Possitions._DepartmentUnitPositions = _DepartmentUnitPositionsController.GetAllDepartmentUnitPositionByPossitionId(_Possitions.PossitionId, dbConnection);

                }

                return _Possitions;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}
