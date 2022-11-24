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
    public interface ProgramAssigneeController
    {


        int SaveProgramAssignee(ProgramAssignee programAssignee);

        int UpdateProgramAssignee(ProgramAssignee programAssignee);

        List<ProgramAssignee> GetAllProgramAssignee(bool withProgramTarget, bool withDepartmentUnitPositions, bool withDesignation);
        
        ProgramAssignee GetProgramAssignee(int id, bool withProgramTarget, bool withDepartmentUnitPositions, bool withDesignation);
    }

    public class ProgramAssigneeControllerImpl : ProgramAssigneeController
    {

        DBConnection dBConnection;
        ProgramAssigneeDAO programAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();


        public int SaveProgramAssignee(ProgramAssignee programAssignee)
        {

            try
            {
                dBConnection = new DBConnection();
                return programAssigneeDAO.SaveProgramAssignee(programAssignee, dBConnection);
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

        public int UpdateProgramAssignee(ProgramAssignee programAssignee)
        {


            try
            {
                dBConnection = new DBConnection();
                var programAssignees = programAssigneeDAO.UpdateProgramAssignee(programAssignee, dBConnection);
                return programAssignees;
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


        public List<ProgramAssignee> GetAllProgramAssignee(bool withProgramTarget, bool withDepartmentUnitPositions, bool withDesignation)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramAssignee> list = programAssigneeDAO.GetAllProgramAssignee(dBConnection);

                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    foreach (var item in list)
                    {
                        item._ProgramTarget = _ProgramTargetDAO.GetProgramTarget(item.ProgramAssigneeId, dBConnection);
                    }
                }

                if (withDepartmentUnitPositions)
                {

                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnitPositions = _DepartmentUnitPositionsDAO.GetDepartmentUnitPositions(item.ProgramAssigneeId, dBConnection);
                    }

                }


                if (withDesignation)
                {
                    DesignationDAO _DesignationController = DAOFactory.CreateDesignationDAO();
                    List<Designation> listDesignation = _DesignationController.GetAllDesignation(dBConnection);

                    foreach (var item in list)
                    {
                        item._Designation = listDesignation.Where(a => a.DesignationId == item.DesignationId).Single();
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

        public ProgramAssignee GetProgramAssignee(int id, bool withProgramTarget, bool withDepartmentUnitPositions, bool withDesignation)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramAssigneeDAO DAO = DAOFactory.CreateProgramAssigneeDAO();
                ProgramAssignee _ProgramAssignee = DAO.GetProgramAssignee(id, dbConnection);

                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetController = DAOFactory.CreateProgramTargetDAO();
                    _ProgramAssignee._ProgramTarget = _ProgramTargetController.GetProgramTarget(_ProgramAssignee.ProgramAssigneeId, dbConnection);

                }


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsController = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    _ProgramAssignee._DepartmentUnitPositions = _DepartmentUnitPositionsController.GetDepartmentUnitPositions(_ProgramAssignee.ProgramAssigneeId, dbConnection);

                }


                if (withDesignation)
                {
                    DesignationDAO _DesignationController = DAOFactory.CreateDesignationDAO();
                    _ProgramAssignee._Designation = _DesignationController.GetDesignation(_ProgramAssignee.ProgramAssigneeId, dbConnection);

                }


                return _ProgramAssignee;

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

