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
    public interface ProgramBudgetController
    {

        int SaveProgramBudget(ProgramBudget programBudget);

        int UpdateProgramBudget(ProgramBudget programBudget);

        List<ProgramBudget> GetAllProgramBudget(bool withProgramPlan);

        ProgramBudget GetProgramBudget(int id, bool withProgramPlan);
    }

    public class ProgramBudgetControllerImpl : ProgramBudgetController
    {

        DBConnection dBConnection;
        ProgramBudgetDAO programBudgetDAO = DAOFactory.CreateProgramBudgetDAO();


        public int SaveProgramBudget(ProgramBudget programBudget)
        {

            try
            {
                dBConnection = new DBConnection();
                return programBudgetDAO.SaveProgramBudget(programBudget, dBConnection);
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

        public int UpdateProgramBudget(ProgramBudget programBudget)
        {


            try
            {
                dBConnection = new DBConnection();
                var programBudgets = programBudgetDAO.UpdateProgramBudget(programBudget, dBConnection);
                return programBudgets;
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


        public List<ProgramBudget> GetAllProgramBudget(bool withProgramPlan)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramBudget> list = programBudgetDAO.GetAllProgramBudget(dBConnection);

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanDAO = DAOFactory.CreateProgramPlanDAO();
                    foreach (var item in list)
                    {
                        item._ProgramPlan = _ProgramPlanDAO.GetProgramPlan(item.ProgramBudgetId , dBConnection);
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

        public ProgramBudget GetProgramBudget(int id, bool withProgramPlan)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramBudgetDAO DAO = DAOFactory.CreateProgramBudgetDAO();
                ProgramBudget _ProgramBudget = DAO.GetProgramBudget(id, dbConnection);

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanController = DAOFactory.CreateProgramPlanDAO();
                    _ProgramBudget._ProgramPlan = _ProgramPlanController.GetProgramPlan(_ProgramBudget.ProgramBudgetId, dbConnection);

                }

                return _ProgramBudget;
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
