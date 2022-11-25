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
    public interface BeneficiaryTypeController
    {
        int SaveBeneficiaryType(BeneficiaryType beneficiaryType);

        List<BeneficiaryType> GetAllBeneficiaryType();
    }

    public class BeneficiaryTypeControllerImpl : BeneficiaryTypeController 
    {
        DBConnection dBConnection;
        BeneficiaryTypeDAO beneficiaryTypeDAO = DAOFactory.CreateBeneficiaryTypeDAO();

        public int SaveBeneficiaryType(BeneficiaryType beneficiaryType)
        {

            try
            {
                dBConnection = new DBConnection();
                return beneficiaryTypeDAO.SaveBeneficiaryType(beneficiaryType, dBConnection);
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

        public List<BeneficiaryType> GetAllBeneficiaryType()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                BeneficiaryTypeDAO DAO = DAOFactory.CreateBeneficiaryTypeDAO();
                return DAO.GetAllBeneficiaryType(dbConnection);
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
