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
    public interface ProgramTypeController
    {

        int SaveProgramType(ProgramType programType);

        int UpdateProgramType(ProgramType programType);

        List<ProgramType> GetAllProgramType(bool withProgramTarget);

        ProgramType GetProgramType(int id, bool withProgramTarget);
    }

    public class ProgramTypeControllerImpl : ProgramTypeController
    {

        DBConnection dBConnection;
        ProgramTypeDAO programTypetDAO = DAOFactory.CreateProgramTypeDAO();


        public int SaveProgramType(ProgramType programType)
        {

            try
            {
                dBConnection = new DBConnection();
                return programTypetDAO.SaveProgramType(programType, dBConnection);
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

        public int UpdateProgramType(ProgramType programType)
        {


            try
            {
                dBConnection = new DBConnection();
                var programTypes = programTypetDAO.UpdateProgramType(programType, dBConnection);
                return programTypes;
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


        public List<ProgramType> GetAllProgramType(bool withProgramTarget)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProgramType> list = programTypetDAO.GetAllProgramType(dBConnection);

                if(withProgramTarget)
                {
                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    foreach (var item in list)
                    {
                        item._ProgramTarget = _ProgramTargetDAO.GetAllProgramTargetByProgramId(item.ProgramTypeId, dBConnection);
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

        public ProgramType GetProgramType(int id, bool withProgramTarget)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProgramTypeDAO DAO = DAOFactory.CreateProgramTypeDAO();
                ProgramType programType = DAO.GetProgramType(id, dbConnection);


                if (withProgramTarget)
                {

                    ProgramTargetDAO _ProgramTargetDAO = DAOFactory.CreateProgramTargetDAO();
                    programType._ProgramTarget = _ProgramTargetDAO.GetAllProgramTargetByProgramTypeId(programType.ProgramTypeId, dbConnection);
                }
                return programType;
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
