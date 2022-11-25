using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface CompanyVecansyRegistationDetailsController
    {

        int SaveCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails);
        int UpdateCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails);
        List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationDetails();
        List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationDetails(string runPosition, string runYear);
        CompanyVecansyRegistationDetails GetCompanyVecansyRegistationDetails(int id);
    }


    public class CompanyVecansyRegistationDetailsControllerImpl : CompanyVecansyRegistationDetailsController
    {

        DBConnection dBConnection;
        CompanyVecansyRegistationDetailsDAO companyVecansyRegistationDetailsDAO = DAOFactory.CreateCompanyVecansyRegistationDetailsDAO();
        public int SaveCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails)
        {
            try
            {
                dBConnection = new DBConnection();
                return companyVecansyRegistationDetailsDAO.SaveCompanyVecansyRegistationDetails(companyVecansyRegistationDetails, dBConnection);
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

        public int UpdateCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails)
        {
            try
            {
                dBConnection = new DBConnection();
                var companyVecansyRegistationDetailss = companyVecansyRegistationDetailsDAO.UpdateCompanyVecansyRegistationDetails(companyVecansyRegistationDetails, dBConnection);
                return companyVecansyRegistationDetailss;
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

        public List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationDetails()
        {
            try
            {
                dBConnection = new DBConnection();
                List<CompanyVecansyRegistationDetails> list = companyVecansyRegistationDetailsDAO.GetAllCompanyVecansyRegistationDetails(dBConnection);


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

        public List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationDetails(string runPosition, string runYear)
        {
            try
            {
                dBConnection = new DBConnection();
                List<CompanyVecansyRegistationDetails> list = companyVecansyRegistationDetailsDAO.GetAllCompanyVecansyRegistationFilterDetails(runPosition, runYear, dBConnection);

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

        public CompanyVecansyRegistationDetails GetCompanyVecansyRegistationDetails(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                CompanyVecansyRegistationDetailsDAO DAO = DAOFactory.CreateCompanyVecansyRegistationDetailsDAO();
                CompanyVecansyRegistationDetails _CompanyVecansyRegistationDetails = DAO.GetCompanyVecansyRegistationDetails(id, dbConnection);



                return _CompanyVecansyRegistationDetails;
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

