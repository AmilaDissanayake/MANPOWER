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
    public interface ProgramPlanController
    {

        int SaveProgramPlan(ProgramPlan programPlan);

        int UpdateProgramPlan(ProgramPlan programPlan);

        List<ProgramPlan> GetAllProgramPlan(bool withProgramAttendence, bool withProgramBudget, bool withProgramTarget, bool withProgramCategory, bool withProjectStatus, bool withProjectTask);

        ProgramPlan GetProgramPlan(int id, bool withProgramAttendence, bool withProgramBudget, bool withProgramTarget, bool withProgramCategory, bool withProjectStatus, bool withProjectTask);
        List<ProgramPlan> GetAllProgramPlanByDateTypeDistrict(string date, int programType, int districtId, bool withProgramTarget);
    }

    public class ProgramPlanControllerImpl : ProgramPlanController
    {


        DBConnection dBConnection;
        ProgramPlanDAO programPlanDAO = DAOFactory.CreateProgramPlanDAO();

        public int SaveProgramPlan(ProgramPlan programPlan)
        {

            try
            {
                dBConnection = new DBConnection();
                return programPlanDAO.SaveProgramPlan(programPlan, dBConnection);
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

        public int UpdateProgramPlan(ProgramPlan programPlan)
        {


            try
            {
                dBConnection = new DBConnection();
                var programPlans = programPlanDAO.UpdateProgramPlan(programPlan, dBConnection);
                return programPlans;
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


        public List<ProgramPlan> GetAllProgramPlan(bool withProgramAttendence, bool withProgramBudget, bool withProgramTarget, bool withProgramCategory, bool withProjectStatus, bool withProjectTask)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramPlan> list = programPlanDAO.GetAllProgramPlan(dBConnection);

                //withProgramTarget = true;

                if (withProgramCategory)
                {
                    ProgramCategoryDAO _ProgramCategoryController = DAOFactory.CreateProgramCategoryDAO();
                    //List<ProgramCategory> listProgramCategory = _ProgramCategoryController.GetAllProgramCategory(dBConnection);

                    foreach (var item in list)
                    {
                        item._ProgramCategory = _ProgramCategoryController.GetProgramCategory(item.ProgramCategoryId, dBConnection);
                    }
                }

                if (withProjectStatus)
                {
                    ProjectStatusDAO _ProjectStatusController = DAOFactory.CreateProjectStatusDAO();
                    List<ProjectStatus> listProjectStatus = _ProjectStatusController.GetAllProjectStatus(dBConnection);

                    foreach (var item in list)
                    {
                        item._ProjectStatus = listProjectStatus.Where(a => a.ProjectStatusId == item.ProgramPlanId).Single();
                    }
                }

                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    foreach (var item in list)
                    {
                        item._ProgramTarget = _ProgramTargetDAO.GetProgramTarget(item.ProgramTargetId, dBConnection);

                        ProgramAssigneeDAO programAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                        item._ProgramTarget._ProgramAssignee = programAssigneeDAO.GetAllProgramAssigneeByProgramTargetId(item.ProgramTargetId, dBConnection);
                    }
                }

                if (withProgramAttendence)
                {
                    ProgramAttendenceDAO _ProgramAttendenceDAO = DAOFactory.CreateProgramAttendenceDAO();
                    foreach (var item in list)
                    {
                        item._ProgramAttendence = _ProgramAttendenceDAO.GetAllProgramAttendenceByProgramPlanId(item.ProgramPlanId, dBConnection);
                    }
                }

                if (withProgramBudget)
                {
                    ProgramBudgetDAO _ProgramBudgetDAO = DAOFactory.CreateProgramBudgetDAO();
                    foreach (var item in list)
                    {
                        item._ProgramBudget = _ProgramBudgetDAO.GetAllProgramBudgetByProgramPlanId(item.ProgramPlanId, dBConnection);
                    }
                }

                if (withProjectTask)
                {
                    ProjectTaskDAO _ProjectTaskDAO = DAOFactory.CreateProjectTaskDAO();
                    foreach (var item in list)
                    {
                        item._ProjectTask = _ProjectTaskDAO.GetAllProjectTaskByProgramPlanId(item.ProgramPlanId, dBConnection);
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

        public ProgramPlan GetProgramPlan(int id, bool withProgramAttendence, bool withProgramBudget, bool withProgramTarget, bool withProgramCategory, bool withProjectStatus, bool withProjectTask)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramPlanDAO DAO = DAOFactory.CreateProgramPlanDAO();
                ProgramPlan _ProgramPlan = DAO.GetProgramPlan(id, dbConnection);


                if (withProgramCategory)
                {
                    ProgramCategoryDAO _ProgramCategoryController = DAOFactory.CreateProgramCategoryDAO();
                    _ProgramPlan._ProgramCategory = _ProgramCategoryController.GetProgramCategory(_ProgramPlan.ProgramCategoryId, dbConnection);

                }

                if (withProjectStatus)
                {
                    ProjectStatusDAO _ProjectStatusController = DAOFactory.CreateProjectStatusDAO();
                    _ProgramPlan._ProjectStatus = _ProjectStatusController.GetProjectStatus(_ProgramPlan.ProjectStatusId, dbConnection);

                }

                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    _ProgramPlan._ProgramTarget = _ProgramTargetDAO.GetProgramTarget(_ProgramPlan.ProjectStatusId, dbConnection);

                }

                if (withProgramAttendence)
                {
                    ProgramAttendenceDAO _ProgramAttendenceDAO = DAOFactory.CreateProgramAttendenceDAO();
                    _ProgramPlan._ProgramAttendence = _ProgramAttendenceDAO.GetAllProgramAttendenceByProgramPlanId(_ProgramPlan.ProgramPlanId, dbConnection);

                }

                if (withProgramBudget)
                {
                    ProgramBudgetDAO _ProgramBudgetController = DAOFactory.CreateProgramBudgetDAO();
                    _ProgramPlan._ProgramBudget = _ProgramBudgetController.GetAllProgramBudgetByProgramPlanId(_ProgramPlan.ProgramPlanId, dbConnection);

                }

                if (withProjectTask)
                {
                    ProjectTaskDAO _ProjectTaskController = DAOFactory.CreateProjectTaskDAO();
                    _ProgramPlan._ProjectTask = _ProjectTaskController.GetAllProjectTaskByProgramPlanId(_ProgramPlan.ProgramPlanId, dbConnection);

                }


                return _ProgramPlan;
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

        public List<ProgramPlan> GetAllProgramPlanByDateTypeDistrict(string date, int programType, int districtId, bool withProgramTarget)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramPlanDAO DAO = DAOFactory.CreateProgramPlanDAO();
                List<ProgramPlan> _ProgramPlan = DAO.GetAllProgramPlanByDateTypeDistrict(date, programType, districtId, dbConnection);


                if (withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    foreach (var item in _ProgramPlan)
                    {
                        item._ProgramTarget = _ProgramTargetDAO.GetProgramTarget(item.ProgramTargetId, dbConnection);

                        ProgramAssigneeDAO programAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                        item._ProgramTarget._ProgramAssignee = programAssigneeDAO.GetAllProgramAssigneeByProgramTargetId(item.ProgramTargetId, dbConnection);
                    }
                }

                return _ProgramPlan;
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
