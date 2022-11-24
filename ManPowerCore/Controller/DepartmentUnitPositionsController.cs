using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface DepartmentUnitPositionsController
    {
        int SaveDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions);
        int UpdateDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions);
        List<DepartmentUnitPositions> GetAllDepartmentUnitPositions(bool withTaskAllocation, bool withProgramAssignee, bool withSystemUser, bool withPossitions, bool withDepartmentUnit);
        DepartmentUnitPositions GetDepartmentUnitPositions(int id, bool withTaskAllocation, bool withProgramAssignee, bool withSystemUser, bool withPossitions, bool withDepartmentUnit);
        List<DepartmentUnitPositions> GetAllDepartmentUnitPositions(int runSystemUserId);

    }

    public class DepartmentUnitPositionsControllerImpl : DepartmentUnitPositionsController
    {
        DBConnection dBConnection;
        DepartmentUnitPositionsDAO departmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
        public int SaveDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions)
        {
            try
            {
                dBConnection = new DBConnection();
                return departmentUnitPositionsDAO.SaveDepartmentUnitPositions(departmentUnitPositions, dBConnection);
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

        public int UpdateDepartmentUnitPositions(DepartmentUnitPositions departmentUnitPositions)
        {
            try
            {
                dBConnection = new DBConnection();
                var departmentUnitPositionsDetails = departmentUnitPositionsDAO.UpdateDepartmentUnitPositions(departmentUnitPositions, dBConnection);
                return departmentUnitPositionsDetails;
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

        public List<DepartmentUnitPositions> GetAllDepartmentUnitPositions(bool withTaskAllocation, bool withProgramAssignee, bool withSystemUser, bool withPossitions, bool withDepartmentUnit)
        {
            try
            {
                dBConnection = new DBConnection();
                List<DepartmentUnitPositions> list = departmentUnitPositionsDAO.GetAllDepartmentUnitPositions(dBConnection);


                if (withTaskAllocation)
                {
                    TaskAllocationDAO _TaskAllocationDAO = DAOFactory.CreateTaskAllocationDAO();
                    foreach (var item in list)
                    {
                        item._TaskAllocation = _TaskAllocationDAO.GetAllTaskAllocationByDepartmentUnitPositionId(item.DepartmetUnitPossitionsId, dBConnection);
                    }
                }


                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                    foreach (var item in list)
                    {
                        item._ProgramAssignee = _ProgramAssigneeDAO.GetAllProgramAssigneeByDepartmentUnitPositionId(item.DepartmetUnitPossitionsId, dBConnection);
                    }
                }

                if (withSystemUser)
                {
                    SystemUserDAO _SystemUserDAO = DAOFactory.CreateSystemUserDAO();
                    foreach (var item in list)
                    {
                        item._SystemUser = _SystemUserDAO.GetSystemUser(item.DepartmetUnitPossitionsId, dBConnection);
                    }
                }

                if (withPossitions)
                {
                    PossitionsDAO _PossitionsController = DAOFactory.CreatePossitionsDAO();
                    List<Possitions> listPossitions = _PossitionsController.GetAllPossitions(dBConnection);

                    foreach (var item in list)
                    {
                        item._Possitions = listPossitions.Where(a => a.PossitionId == item.DepartmetUnitPossitionsId).Single();
                    }
                }

                if (withDepartmentUnit)
                {
                    DepartmentUnitDAO _DepartmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnit = _DepartmentUnitDAO.GetDepartmentUnit(item.DepartmetUnitPossitionsId, dBConnection);
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
        public List<DepartmentUnitPositions> GetAllDepartmentUnitPositions(int runSystemUserId)
        {

            try
            {
                dBConnection = new DBConnection();
                List<DepartmentUnitPositions> list = departmentUnitPositionsDAO.GetAllUsersBySystemUserId(runSystemUserId, dBConnection);

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

        public DepartmentUnitPositions GetDepartmentUnitPositions(int id, bool withTaskAllocation, bool withProgramAssignee, bool withSystemUser, bool withPossitions, bool withDepartmentUnit)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                DepartmentUnitPositionsDAO DAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                 DepartmentUnitPositions _DepartmentUnitPositions = DAO.GetDepartmentUnitPositions(id, dbConnection);

                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeController = DAOFactory.CreateProgramAssigneeDAO();
                    _DepartmentUnitPositions._ProgramAssignee = _ProgramAssigneeController.GetAllProgramAssigneeByDepartmentUnitPositionId(_DepartmentUnitPositions.DepartmetUnitPossitionsId, dbConnection);

                }
                if (withSystemUser)
                {
                    SystemUserDAO _SystemUserController = DAOFactory.CreateSystemUserDAO();
                    _DepartmentUnitPositions._SystemUser = _SystemUserController.GetSystemUser(_DepartmentUnitPositions.DepartmetUnitPossitionsId, dbConnection);

                }

                if (withPossitions)
                {
                    PossitionsDAO _PossitionsController = DAOFactory.CreatePossitionsDAO();
                    _DepartmentUnitPositions._Possitions = _PossitionsController.GetPossitions(_DepartmentUnitPositions.DepartmetUnitPossitionsId, dbConnection);

                }

                if (withDepartmentUnit)
                {
                    DepartmentUnitDAO _DepartmentUnitController = DAOFactory.CreateDepartmentUnitDAO();
                    _DepartmentUnitPositions._DepartmentUnit = _DepartmentUnitController.GetDepartmentUnit(_DepartmentUnitPositions.DepartmetUnitPossitionsId, dbConnection);

                }

                return _DepartmentUnitPositions;
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
