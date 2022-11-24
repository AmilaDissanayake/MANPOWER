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
    public interface TrainingRequestController
    {
        List<Training_Request> GetAllTrainingRequests();
        int AddRequest(Training_Request trainingrequest);
    }

    public class TrainingRequestControllerImpl : TrainingRequestController
    {
        DBConnection dBConnection;
        TrainingRequestDAO trainingRequestDAO = DAOFactory.CreateTrainingRequestDAO();

        public List<Training_Request> GetAllTrainingRequests()
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestDAO.GetAllTrainingRequests(dBConnection);

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


        public int AddRequest(Training_Request trainingrequest)
        {
            try
            {
                dBConnection = new DBConnection();
                return trainingRequestDAO.AddRequest(trainingrequest, dBConnection);
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
