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
    public interface PromotionController
    {
        int SavePromotions(Promotions promotions);

        int UpdatePromotions(Promotions promotions);

        List<Promotions> GetAllPromotions();

        Promotions GetPromotions(int id);
    }

    public class PromotionControllerImpl : PromotionController
    {
        DBConnection dBConnection;
        PromotionsDAO promotionsDAO = DAOFactory.CreatePromotionsDAO();


        public int SavePromotions(Promotions promotions)
        {

            try
            {
                dBConnection = new DBConnection();
                promotionsDAO.SavePromotions(promotions, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdatePromotions(Promotions promotions)
{


            try
            {
                dBConnection = new DBConnection();
                promotionsDAO.UpdatePromotions(promotions, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }


        public List<Promotions> GetAllPromotions()
        {
            DBConnection dBConnection = new DBConnection();

            try
            {
                PromotionsDAO DAO = DAOFactory.CreatePromotionsDAO();
                List<Promotions> list = DAO.GetAllPromotions(dBConnection);
                return list;
            }

            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }

            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }

        public Promotions GetPromotions(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                PromotionsDAO DAO = DAOFactory.CreatePromotionsDAO();
                Promotions list = DAO.GetPromotionsById(id,dBConnection);
                return list;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                return null;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}

