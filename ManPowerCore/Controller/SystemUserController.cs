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
    public interface SystemUserController
    {
        int SaveSystemUser(SystemUser systemUser);
        int UpdateSystemUser(SystemUser systemUser);
        List<SystemUser> GetAllSystemUser(bool withDepartmentUnitPositions, bool withUserType, bool withDesignation);
        SystemUser GetSystemUser(int id, bool withDepartmentUnitPositions, bool withUserType, bool withDesignation);
        List<SystemUser> GetAllSystemUser(string runUserName);
        List<SystemUser> GetAllSystemUser(string runUserName, string runPassword);
        List<SystemUser> GetAllSystemUser(string runUserName, string runEmail, int runContactNumber, int runEmpNumber);
    }

    public class SystemUserControllerImpl : SystemUserController
    {
        DBConnection dBConnection;
        SystemUserDAO systemUserDAO = DAOFactory.CreateSystemUserDAO();
        public int SaveSystemUser(SystemUser systemUser)
        {
            try
            {
                dBConnection = new DBConnection();
                return systemUserDAO.SaveSystemUser(systemUser, dBConnection);
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

        public int UpdateSystemUser(SystemUser systemUser)
        {
            try
            {
                dBConnection = new DBConnection();
                var systemUserDetails = systemUserDAO.UpdateSystemUser(systemUser, dBConnection);
                return systemUserDetails;
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

        public List<SystemUser> GetAllSystemUser(string runUserName, string runEmail, int runContactNumber, int runEmpNumber)
        {
            try
            {
                dBConnection = new DBConnection();
                List<SystemUser> list = systemUserDAO.SystemUserValider(runUserName, runEmail, runContactNumber, runEmpNumber, dBConnection);

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

        public List<SystemUser> GetAllSystemUser(string runUserName, string runPassword)
        {

            try
            {
                dBConnection = new DBConnection();
                List<SystemUser> list = systemUserDAO.CheckSystemUserLoginPassword(runUserName, runPassword, dBConnection);

               


                //     If Password is iccorect    

                if (list.Count == 0)
                {

                    /// Check Invalied Loging Count 

                    try
                    {

                        dBConnection = new DBConnection();
                        List<SystemUser> invaliedCount = systemUserDAO.CheckInvaliedLogingCount(runUserName, dBConnection);


                        int atte;

                        foreach (var item in invaliedCount)
                        {

                            atte = item.InvalideLoginCount;
                            SystemUser systemUser = new SystemUser();
                            systemUser.InvalideLoginCount = atte + 1;
                            systemUser.UserName = runUserName;



                            try
                            {
                                //// set invalied login count to add 1 

                                dBConnection = new DBConnection();
                                systemUserDAO.UpdateCountInvaliedAttempts(systemUser, dBConnection);

                                ////
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

                            return list;
                        }

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
                    ///



                }
                //

                /////   Reset Invalied login Attempt 
                try
                {

                    SystemUser systemUser = new SystemUser();
                    systemUser.UserName = runUserName;
                    systemUser.InvalideLoginCount = 0;


                    dBConnection = new DBConnection();
                    systemUserDAO.ResetInvaliedAttempts(systemUser, dBConnection);
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
                ///////      Update last login date
                try
                {

                    SystemUser systemUser = new SystemUser();
                    systemUser.UserName = runUserName;
                    



                    dBConnection = new DBConnection();
                    systemUserDAO.UpdateLastLoginDate(systemUser, dBConnection);
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
                ///////

                /////
                ///
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
        ////////////////////////////////////////////     end the methord    //////////////////////////////////////////////////////////


        public List<SystemUser> GetAllSystemUser(string runUserName)
        {

            try
            {
                dBConnection = new DBConnection();
                List<SystemUser> list = systemUserDAO.SystemUserLogin(runUserName, dBConnection);



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

        public List<SystemUser> GetAllSystemUser(bool withDepartmentUnitPositions, bool withUserType, bool withDesignation)
        {
            try
            {
                dBConnection = new DBConnection();
                List<SystemUser> list = systemUserDAO.GetAllSystemUser(dBConnection);

                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnitPositions = _DepartmentUnitPositionsDAO.GetAllDepartmentUnitPositionsBySystemUserId(item.SystemUserId, dBConnection);
                    }
                }

                if (withUserType)
                {
                    UserTypeDAO _UserTypeController = DAOFactory.CreateUserTypeDAO();
                    List<UserType> listUserType = _UserTypeController.GetAllUserType(dBConnection);

                    foreach (var item in list)
                    {
                        item._UserType = listUserType.Where(a => a.UserTypeId == item.SystemUserId).Single();
                    }
                }

                if (withDesignation)
                {
                    DesignationDAO _DesignationController = DAOFactory.CreateDesignationDAO();
                    List<Designation> listDesignation = _DesignationController.GetAllDesignation(dBConnection);

                    foreach (var item in list)
                    {
                        item._Designation = listDesignation.Where(a => a.DesignationId == item.SystemUserId).Single();
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

        public SystemUser GetSystemUser(int id, bool withDepartmentUnitPositions, bool withUserType, bool withDesignation)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                SystemUserDAO DAO = DAOFactory.CreateSystemUserDAO();
                SystemUser _SystemUser = DAO.GetSystemUser(id, dbConnection);


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsController = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    _SystemUser._DepartmentUnitPositions = _DepartmentUnitPositionsController.GetAllDepartmentUnitPositionsBySystemUserId(_SystemUser.SystemUserId, dbConnection);

                }

                if (withUserType)
                {
                    UserTypeDAO _UserTypeController = DAOFactory.CreateUserTypeDAO();
                    _SystemUser._UserType = _UserTypeController.GetUserType(_SystemUser.SystemUserId, dbConnection);

                }

                if (withDesignation)
                {
                    DesignationDAO _DesignationController = DAOFactory.CreateDesignationDAO();
                    _SystemUser._Designation = _DesignationController.GetDesignation(_SystemUser.SystemUserId, dbConnection);

                }

                return _SystemUser;
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
