using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingRequestDAO
    {
        List<Training_Request> GetAllTrainingRequests(DBConnection dbConnection);
        int AddRequest(Training_Request trainingrequest, DBConnection dbConnection);
    }

    public class TrainingRequestDAOImpl : TrainingRequestDAO
    {
        public List<Training_Request> GetAllTrainingRequests(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TRAINING_REQUEST ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Training_Request>(dbConnection.dr);

        }

        public int AddRequest(Training_Request trainingrequest, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO TRAINING_REQUEST(PROGRAM_DATE,PROGRAM_ID,REQUESTED_DATE,IS_APPROVED,APPROVED_BY,APPROVED_DATE,IS_ACTIVE) VALUES('" + trainingrequest.ProgramDate + "','" + trainingrequest.ProgramId + "','" + trainingrequest.TrainingRequestName + "','" + trainingrequest.IsApproved + "','" + trainingrequest.ApprovedBy + "','" + trainingrequest.ApprovedDate + "',1) SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }
    }
}
