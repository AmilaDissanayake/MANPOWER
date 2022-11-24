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
    public interface UserTypeController
    {
        List<UserType> GetAllUserType(bool withSystemUser);
        UserType GetUserType(int id, bool withSystemUser);
    }

    public class UserTypeControllerImpl : UserTypeController
    {
        DBConnection dBConnection;
        UserTypeDAO userTypeDAO = DAOFactory.CreateUserTypeDAO();

        public List<UserType> GetAllUserType(bool withSystemUser)
        {
            try
            {
                dBConnection = new DBConnection();
                List<UserType> list = userTypeDAO.GetAllUserType(dBConnection);


                if (withSystemUser)
                {
                    SystemUserDAO _SystemUserDAO = DAOFactory.CreateSystemUserDAO();
                    foreach (var item in list)
                    {
                        item._SystemUser = _SystemUserDAO.GetAllSystemUserByUserTypeId(item.UserTypeId, dBConnection);
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

        public UserType GetUserType(int id, bool withSystemUser)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                UserTypeDAO DAO = DAOFactory.CreateUserTypeDAO();
                UserType _UserType = DAO.GetUserType(id, dbConnection);


                if (withSystemUser)
                {
                    SystemUserDAO _SystemUserController = DAOFactory.CreateSystemUserDAO();
                    _UserType._SystemUser = _SystemUserController.GetAllSystemUserByUserTypeId(_UserType.UserTypeId, dbConnection);

                }

                return _UserType;
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
