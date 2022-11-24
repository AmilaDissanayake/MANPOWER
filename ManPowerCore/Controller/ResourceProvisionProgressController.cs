using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface ResourceProvisionProgressController
    {

        int SaveResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress);
        int UpdateResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress);
        List<ResourceProvisionProgress> GetAllResourceProvisionProgress();
        ResourceProvisionProgress GetResourceProvisionProgress(int id);
        List<ResourceProvisionProgress> GetAllResourceProvisionProgress(string runInstitute, string runYear);

        List<ResourceProvisionProgress> GetAllResourceProvisionProgress(string runInstitute, string runYear, string runDS);

    }

    public class ResourceProvisionProgressControllerImpl : ResourceProvisionProgressController
    {

        DBConnection dBConnection;
        ResourceProvisionProgressDAO resourceProvisionProgressDAO = DAOFactory.CreateResourceProvisionProgressDAO();
        public int SaveResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress)
        {
            try
            {
                dBConnection = new DBConnection();
                return resourceProvisionProgressDAO.SaveResourceProvisionProgress(resourceProvisionProgress, dBConnection);
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

        public int UpdateResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress)
        {
            try
            {
                dBConnection = new DBConnection();
                var resourceProvisionProgresss = resourceProvisionProgressDAO.UpdateResourceProvisionProgress(resourceProvisionProgress, dBConnection);
                return resourceProvisionProgresss;
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

        public List<ResourceProvisionProgress> GetAllResourceProvisionProgress()
        {
            try
            {
                dBConnection = new DBConnection();
                List<ResourceProvisionProgress> list = resourceProvisionProgressDAO.GetAllResourceProvisionProgress(dBConnection);


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

        public List<ResourceProvisionProgress> GetAllResourceProvisionProgress(string runInstitute, string runYear)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ResourceProvisionProgress> list = resourceProvisionProgressDAO.GetAllResourceProvisionProgressFilterDetails(runInstitute, runYear, dBConnection);

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

        public List<ResourceProvisionProgress> GetAllResourceProvisionProgress(string runInstitute, string runYear, string runDS)
        {
            try
            {
                dBConnection = new DBConnection();
                List<ResourceProvisionProgress> list = resourceProvisionProgressDAO.ValidateResourceProvisionProgress(runInstitute, runYear, runDS, dBConnection);

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

        public ResourceProvisionProgress GetResourceProvisionProgress(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ResourceProvisionProgressDAO DAO = DAOFactory.CreateResourceProvisionProgressDAO();
                ResourceProvisionProgress _ResourceProvisionProgress = DAO.GetResourceProvisionProgress(id, dbConnection);



                return _ResourceProvisionProgress;
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

