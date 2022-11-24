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
    public interface DesignationController
    {
        List<Designation> GetAllDesignation(bool withSystemUser, bool withProgramAssignee);
        Designation GetDesignation(int id, bool withSystemUser, bool withProgramAssignee);
    }
    public class DesignationControllerImpl : DesignationController
    {
        DBConnection dBConnection;
        DesignationDAO designationDAO = DAOFactory.CreateDesignationDAO();
        public List<Designation> GetAllDesignation(bool withSystemUser, bool withProgramAssignee)
        {
            try
            {
                dBConnection = new DBConnection();
                List<Designation> list = designationDAO.GetAllDesignation(dBConnection);

                if (withSystemUser)
                {
                    SystemUserDAO _SystemUserDAO = DAOFactory.CreateSystemUserDAO();
                    foreach (var item in list)
                    {
                        item._SystemUser = _SystemUserDAO.GetAllSystemUserByDesignationId(item.DesignationId, dBConnection);
                    }
                }

                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeDAO = DAOFactory.CreateProgramAssigneeDAO();
                    foreach (var item in list)
                    {
                        item._ProgramAssignee = _ProgramAssigneeDAO.GetAllProgramAssigneeByDesignationId(item.DesignationId, dBConnection);
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

        public Designation GetDesignation(int id, bool withSystemUser, bool withProgramAssignee)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                DesignationDAO DAO = DAOFactory.CreateDesignationDAO();
                Designation _Designation = DAO.GetDesignation(id, dbConnection);

                if (withSystemUser)
                {
                    SystemUserDAO _SystemUserController = DAOFactory.CreateSystemUserDAO();
                    _Designation._SystemUser = _SystemUserController.GetAllSystemUserByDesignationId(_Designation.DesignationId, dbConnection);

                }

                if (withProgramAssignee)
                {
                    ProgramAssigneeDAO _ProgramAssigneeController = DAOFactory.CreateProgramAssigneeDAO();
                    _Designation._ProgramAssignee = _ProgramAssigneeController.GetAllProgramAssigneeByDesignationId(_Designation.DesignationId, dbConnection);

                }

                return _Designation;

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
