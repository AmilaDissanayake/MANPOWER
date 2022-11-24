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
    public interface DepartmentUnitController
    {
        int SaveDepartmentUnit(DepartmentUnit departmentunit);
        int UpdateDepartmentUnit(DepartmentUnit departmentunit);
        List<DepartmentUnit> GetAllDepartmentUnit(bool withDepartmentUnitPositions, bool withDepartmentUnitType);
        DepartmentUnit GetDepartmentUnit(int id, bool withDepartmentUnitPositions, bool withDepartmentUnitType);
        List<DepartmentUnit> GetAllDepartmentUnit(string runName, int runDepartmentUnitId, int ParentId);
    }

    public class DepartmentUnitControllerImpl : DepartmentUnitController
    {
        DBConnection dBConnection;
        DepartmentUnitDAO departmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();
        public int SaveDepartmentUnit(DepartmentUnit departmentunit)
        {
            try
            {
                dBConnection = new DBConnection();
                return departmentUnitDAO.SaveDepartmentUnit(departmentunit, dBConnection);
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

        public int UpdateDepartmentUnit(DepartmentUnit departmentunit)
        {
            try
            {
                dBConnection = new DBConnection();
                var departmentunitDetails = departmentUnitDAO.UpdateDepartmentUnit(departmentunit, dBConnection);
                return departmentunitDetails;
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
        public List<DepartmentUnit> GetAllDepartmentUnit(string runName, int runDepartmentUnitId, int ParentId)
        {
            try
            {
                dBConnection = new DBConnection();
                List<DepartmentUnit> list = departmentUnitDAO.CheckDepartmentUnit(runName, runDepartmentUnitId, ParentId, dBConnection);
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

                public List<DepartmentUnit> GetAllDepartmentUnit(bool withDepartmentUnitPositions, bool withDepartmentUnitType)
        {
            try
            {
                dBConnection = new DBConnection();
                List<DepartmentUnit> list = departmentUnitDAO.GetAllDepartmentUnit(dBConnection);


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnitPositions = _DepartmentUnitPositionsDAO.GetAllDepartmentUnitPositionsByDepartmentUnitId(item.DepartmentUnitId, dBConnection);
                    }
                }



                if (withDepartmentUnitType)
                {
                    DepartmentUnitTypeDAO _DepartmentUnitTypeController = DAOFactory.CreateDepartmentUnitTypeDAO();
                    List<DepartmentUnitType> listDepartmentUnitType = _DepartmentUnitTypeController.GetAllDepartmentUnitType(dBConnection);

                    foreach (var item in list)
                    {
                        item._DepartmentUnitType = listDepartmentUnitType.Where(a => a.DepartmentUnitTypeId == item.DepartmentUnitId).Single();
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

        public DepartmentUnit GetDepartmentUnit(int id, bool withDepartmentUnitPositions, bool withDepartmentUnitType)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                DepartmentUnitDAO DAO = DAOFactory.CreateDepartmentUnitDAO();
                DepartmentUnit _DepartmentUnit = DAO.GetDepartmentUnit(id, dbConnection);

                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsController = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    _DepartmentUnit._DepartmentUnitPositions = _DepartmentUnitPositionsController.GetAllDepartmentUnitPositionsByDepartmentUnitId(_DepartmentUnit.DepartmentUnitId, dbConnection);

                }
                if (withDepartmentUnitType)
                {
                    DepartmentUnitTypeDAO _DepartmentUnitTypeController = DAOFactory.CreateDepartmentUnitTypeDAO();
                    _DepartmentUnit._DepartmentUnitType = _DepartmentUnitTypeController.GetDepartmentUnitType(_DepartmentUnit.DepartmentUnitId, dbConnection);

                }

                return _DepartmentUnit;
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
