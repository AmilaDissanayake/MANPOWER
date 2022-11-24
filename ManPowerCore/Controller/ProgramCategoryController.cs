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
    public interface ProgramCategoryController
    {

        int SaveProgramCategory(ProgramCategory programCategory);

        int UpdateProgramCategory(ProgramCategory programCategory);

        List<ProgramCategory> GetAllProgramCategory(bool withProgramPlan);

        ProgramCategory GetProgramCategory(int id, bool withProgramPlan);
    }

    public class ProgramCategoryControllerImpl : ProgramCategoryController
    {

        DBConnection dBConnection;
        ProgramCategoryDAO programCategoryDAO = DAOFactory.CreateProgramCategoryDAO();


        public int SaveProgramCategory(ProgramCategory programCategory)
        {

            try
            {
                dBConnection = new DBConnection();
                return programCategoryDAO.SaveProgramCategory(programCategory, dBConnection);
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

        public int UpdateProgramCategory(ProgramCategory programCategory)
        {


            try
            {
                dBConnection = new DBConnection();
                var programCategorys = programCategoryDAO.UpdateProgramCategory(programCategory, dBConnection);
                return programCategorys;
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


        public List<ProgramCategory> GetAllProgramCategory(bool withProgramPlan)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramCategory> list = programCategoryDAO.GetAllProgramCategory(dBConnection);

                if(withProgramPlan)
                {

                    ProgramPlanDAO _ProgramPlanDAO = DAOFactory.CreateProgramPlanDAO();
                    foreach (var item in list)
                    {
                        item._ProgramPlan = _ProgramPlanDAO.GetAllProgramPlanByProgramCategoryId(item.ProgramCategoryId, dBConnection);
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

        public ProgramCategory GetProgramCategory(int id, bool withProgramPlan)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramCategoryDAO DAO = DAOFactory.CreateProgramCategoryDAO();
                 ProgramCategory _ProgramCategory  = DAO.GetProgramCategory(id, dbConnection);

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanController = DAOFactory.CreateProgramPlanDAO();
                    _ProgramCategory._ProgramPlan = _ProgramPlanController.GetAllProgramPlanByProgramCategoryId(_ProgramCategory.ProgramCategoryId, dbConnection);

                }


                return _ProgramCategory;
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
