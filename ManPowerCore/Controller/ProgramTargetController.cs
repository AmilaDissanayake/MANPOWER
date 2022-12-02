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
    public interface ProgramTargetController
    {

        int SaveProgramTarget(ProgramTarget programTarget);

        int UpdateProgramTarget(ProgramTarget programAssignee);

        int UpdateProgramTargetApproval(int id, int status);
        int UpdateProgramTargetApprovalRecomended(int id, int recomendedby, int status);

        List<ProgramTarget> GetAllProgramTarget(bool withProgram, bool withProgramType, bool withProgramAssignee, bool withProgramPlan);

        List<ProgramTarget> GetAllProgramTarget(int runYear, int runMonth, bool withProgram, bool withProgramType, bool withProgramAssignee, bool withProgramPlan);

        ProgramTarget GetProgramTarget(int id, bool withProgram, bool withProgramType, bool withProgramAssignee, bool withProgramPlan);

        List<ProgramTarget> GetAllProgramTarget(int runType);
    }

    public class ProgramTargetControllerImpl : ProgramTargetController
    {

        DBConnection dBConnection;
        ProgramTargetDAO programTargetDAO = DAOFactory.CreateProgramTargetDAO();

        public int SaveProgramTarget(ProgramTarget programTarget)
        {

            try
            {
                dBConnection = new DBConnection();
                int id = programTargetDAO.SaveProgramTarget(programTarget, dBConnection);

                if (programTarget._ProgramAssignee.Count > 0)
                {
                    ProgramAssigneeDAO programAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                    foreach (var item in programTarget._ProgramAssignee)
                    {
                        item.ProgramTargetId = id;
                        programAssigneeDAO.SaveProgramAssignee(item, dBConnection);
                    }
                }

                return id;

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

        public int UpdateProgramTarget(ProgramTarget programTarget)
        {


            try
            {
                dBConnection = new DBConnection();
                var programTargets = programTargetDAO.UpdateProgramTarget(programTarget, dBConnection);
                return programTargets;
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

        public int UpdateProgramTargetApproval(int id, int status)
        {

            try
            {
                dBConnection = new DBConnection();
                var taregts = programTargetDAO.UpdateProgramTargetApproval(id, status, dBConnection);
                return taregts;
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

        public int UpdateProgramTargetApprovalRecomended(int id, int recomendedby, int status)
        {
            try
            {
                dBConnection = new DBConnection();
                var taregts = programTargetDAO.UpdateProgramTargetApprovalRecomended(id, recomendedby, status, dBConnection);
                return taregts;
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


        public List<ProgramTarget> GetAllProgramTarget(bool withProgram, bool withProgramType, bool withProgramAssignee, bool withProgramPlan)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramTarget> list = programTargetDAO.GetAllProgramTarget(dBConnection);

                if (withProgram)
                {
                    ProgramDAO _ProgramController = DAOFactory.CreateProgramDAO();
                    List<Program> listProgram = _ProgramController.GetAllProgram(dBConnection);

                    foreach (var item in list)
                    {
                        item._Program = listProgram.Where(a => a.ProgramId == item.ProgramId).Single();
                    }
                }

                if (withProgramType)
                {
                    ProgramTypeDAO _ProgramTypeController = DAOFactory.CreateProgramTypeDAO();
                    List<ProgramType> listProgramType = _ProgramTypeController.GetAllProgramType(dBConnection);

                    foreach (var item in list)
                    {
                        item._ProgramType = listProgramType.Where(a => a.ProgramTypeId == item.ProgramTypeId).Single();
                    }
                }

                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                    foreach (var item in list)
                    {
                        item._ProgramAssignee = _ProgramAssigneeDAO.GetAllProgramAssigneeByProgramTargetId(item.ProgramTargetId, dBConnection);
                    }
                }

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanDAO = DAOFactory.CreateProgramPlanDAO();
                    foreach (var item in list)
                    {
                        item._ProgramPlan = _ProgramPlanDAO.GetAllProgramPlanByProgramTargetId(item.ProgramTypeId, dBConnection);
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


        public List<ProgramTarget> GetAllProgramTarget(int runYear, int runMonth, bool withProgram, bool withProgramType, bool withProgramAssignee, bool withProgramPlan)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramTarget> list = programTargetDAO.GetAllProgramTargetFilter(runYear, runMonth, dBConnection);

                if (withProgram)
                {
                    ProgramDAO _ProgramController = DAOFactory.CreateProgramDAO();
                    List<Program> listProgram = _ProgramController.GetAllProgram(dBConnection);

                    foreach (var item in list.Where(u => u.TargetYear == runYear && u.TargetMonth == runMonth))
                    {
                        item._Program = listProgram.Where(a => a.ProgramId == item.ProgramId).Single();
                    }
                }

                if (withProgramType)
                {
                    ProgramTypeDAO _ProgramTypeController = DAOFactory.CreateProgramTypeDAO();
                    List<ProgramType> listProgramType = _ProgramTypeController.GetAllProgramType(dBConnection);

                    foreach (var item in list.Where(u => u.TargetYear == runYear && u.TargetMonth == runMonth))
                    {
                        item._ProgramType = listProgramType.Where(a => a.ProgramTypeId == item.ProgramTypeId).Single();
                    }
                }

                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                    foreach (var item in list.Where(u => u.TargetYear == runYear && u.TargetMonth == runMonth))
                    {
                        item._ProgramAssignee = _ProgramAssigneeDAO.GetAllProgramAssigneeByProgramTargetId(item.ProgramTargetId, dBConnection);
                    }
                }

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanDAO = DAOFactory.CreateProgramPlanDAO();
                    foreach (var item in list.Where(u => u.TargetYear == runYear && u.TargetMonth == runMonth))
                    {
                        item._ProgramPlan = _ProgramPlanDAO.GetAllProgramPlanByProgramTargetId(item.ProgramTargetId, dBConnection);
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


        public ProgramTarget GetProgramTarget(int id, bool withProgram, bool withProgramType, bool withProgramAssignee, bool withProgramPlan)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramTargetDAO DAO = DAOFactory.CreateProgramTargetDAO();
                ProgramTarget _ProgramTarget = DAO.GetProgramTarget(id, dbConnection);



                if (withProgram)
                {
                    ProgramDAO _ProgramController = DAOFactory.CreateProgramDAO();
                    _ProgramTarget._Program = _ProgramController.GetProgram(_ProgramTarget.ProgramId, dbConnection);

                }

                if (withProgramType)
                {
                    ProgramTypeDAO _ProgramTypeController = DAOFactory.CreateProgramTypeDAO();
                    _ProgramTarget._ProgramType = _ProgramTypeController.GetProgramType(_ProgramTarget.ProgramTypeId, dbConnection);

                }

                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeController = DAOFactory.CreateProgramAssigneeDAO();
                    _ProgramTarget._ProgramAssignee = _ProgramAssigneeController.GetAllProgramAssigneeByProgramTargetId(_ProgramTarget.ProgramTargetId, dbConnection);

                }

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanController = DAOFactory.CreateProgramPlanDAO();
                    _ProgramTarget._ProgramPlan = _ProgramPlanController.GetAllProgramPlanByProgramTargetId(_ProgramTarget.ProgramTypeId, dbConnection);

                }


                return _ProgramTarget;
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

        public List<ProgramTarget> GetAllProgramTarget(int runType)
        {

            try
            {
                dBConnection = new DBConnection();
                List<ProgramTarget> list = programTargetDAO.GetAllProgramTargetFilter(runType, dBConnection);
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

    }
}
