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
    public interface BeneficiaryController
    {
        int SaveBeneficiary(Beneficiary beneficiary);

        List<Beneficiary> GetAllBeneficiary();
        //List<Beneficiary> GetAllBeneficiary(string runDistric, string runName, bool withInduvidualBeneficiary);
    }

    public class BeneficiaryControllerImpl : BeneficiaryController
    {
        DBConnection dBConnection;
        BeneficiaryDAO beneficiaryDAO = DAOFactory.CreateBeneficiaryDAO();


        public int SaveBeneficiary(Beneficiary beneficiary)
        {

            try
            {
                dBConnection = new DBConnection();
                return beneficiaryDAO.SaveBeneficiary(beneficiary, dBConnection);
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

        public List<Beneficiary> GetAllBeneficiary()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                BeneficiaryDAO DAO = DAOFactory.CreateBeneficiaryDAO();
                return DAO.GetAllBeneficiary(dbConnection);
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

        //public List<Beneficiary> GetAllBeneficiary(string runDistric, string runName, bool withInduvidualBeneficiary)
        //{
        //    DBConnection dbConnection = new DBConnection();
        //    try
        //    {
        //        dBConnection = new DBConnection();
        //        List<ProgramTarget> list = beneficiaryDAO.GetAllBeneficiaryFilter(runYear, runMonth, dBConnection);

        //        if (withInduvidualBeneficiary)
        //        {
        //            InduvidualBeneficiaryDAO _ProgramController = DAOFactory.CreateInduvidualBeneficiaryDAO();
        //            List<InduvidualBeneficiary> listInduvidualBeneficiary = _ProgramController.GetAllInduvidualBeneficiary(dBConnection);

        //            foreach (var item in list.Where(u => u.Name == runName && u.TargetMonth == runMonth))
        //            {
        //                item._Program = listInduvidualBeneficiary.Where(a => a.ProgramId == item.ProgramId).Single();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dbConnection.RollBack();
        //        throw;
        //    }
        //    finally
        //    {
        //        if (dbConnection.con.State == System.Data.ConnectionState.Open)
        //            dbConnection.Commit();
        //    }

        }
}
