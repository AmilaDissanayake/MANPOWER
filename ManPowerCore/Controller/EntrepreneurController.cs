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
    public interface EntrepreneurController
    {
        int SaveEntrepreneur(Entrepreneur entrepreneur);

        List<Entrepreneur> GetAllEntrepreneur();

        List<Entrepreneur> GetAllEntrepreneur(string runBrn);
    }

    public class EntrepreneurControllerImpl : EntrepreneurController
    {
        DBConnection dBConnection;
        EntrepreneurDAO entrepreneurDAO = DAOFactory.CreateEntrepreneurDAO();


        public int SaveEntrepreneur(Entrepreneur entrepreneur)
        {

            try
            {
                dBConnection = new DBConnection();
                return entrepreneurDAO.SaveEntrepreneur(entrepreneur, dBConnection);
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

        public List<Entrepreneur> GetAllEntrepreneur()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                EntrepreneurDAO DAO = DAOFactory.CreateEntrepreneurDAO();
                return DAO.GetAllEntrepreneur(dbConnection);
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

        public List<Entrepreneur> GetAllEntrepreneur(string runBrn)
        {

            try
            {
                dBConnection = new DBConnection();
                List<Entrepreneur> list = entrepreneurDAO.GetAllEntrepreneurFilter(runBrn, dBConnection);
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
