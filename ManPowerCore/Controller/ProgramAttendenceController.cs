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
    public interface ProgramAttendenceController
    {

        int SaveProgramAttendence(ProgramAttendence programAttendence);

        int UpdateProgramAttendence(ProgramAttendence programAttendence);

        List<ProgramAttendence> GetAllProgramAttendence(bool withProgramPlan);

        ProgramAttendence GetProgramAttendence(int id, bool withProgramPlan);
    }


    public class ProgramAttendenceControllerImpl : ProgramAttendenceController
    {


        DBConnection dBConnection;
        ProgramAttendenceDAO programAttendenceDAO = DAOFactory.CreateProgramAttendenceDAO();



        public int SaveProgramAttendence(ProgramAttendence programAttendence)
        {

            try
            {
                dBConnection = new DBConnection();
                return programAttendenceDAO.SaveProgramAttendence(programAttendence, dBConnection);
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

        public int UpdateProgramAttendence(ProgramAttendence programAttendence)
        {
            

            try
            {
                dBConnection = new DBConnection();
                var programAttendences = programAttendenceDAO.UpdateProgramAttendence(programAttendence, dBConnection);
                return programAttendences;
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


        public List<ProgramAttendence> GetAllProgramAttendence(bool withProgramPlan)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramAttendence> list = programAttendenceDAO.GetAllProgramAttendence(dBConnection);


                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanDAO = DAOFactory.CreateProgramPlanDAO();
                    foreach (var item in list)
                    {
                        item._ProgramPlan = _ProgramPlanDAO.GetProgramPlan(item.ProgramAttendenceId, dBConnection);
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

        public ProgramAttendence GetProgramAttendence(int id, bool withProgramPlan)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramAttendenceDAO DAO = DAOFactory.CreateProgramAttendenceDAO();
                ProgramAttendence _ProgramAttendence = DAO.GetProgramAttendence(id, dbConnection);


                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanController = DAOFactory.CreateProgramPlanDAO();
                    _ProgramAttendence._ProgramPlan = _ProgramPlanController.GetProgramPlan(_ProgramAttendence.ProgramAttendenceId, dbConnection);

                }




                return _ProgramAttendence;
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
