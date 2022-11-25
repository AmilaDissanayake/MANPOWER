using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EducationDetailsDAO
    {
        int SaveEducationDetails(EducationDetails educationDetails, DBConnection dbConnection);
    }

    public class EducationDetailsDAOImpl : EducationDetailsDAO
    {
        public int SaveEducationDetails(EducationDetails educationDetails, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO EMPLOYEE(EMPLOYEE_ID,EDUCATION_TYPE_ID,INSTITUTE,ATTEMPT,YEAR" +
                                            ",INDEX,SUBJECT,STREAM,GRADE,STATUS) " +

                                            "VALUES(@EmployeeId,@EducationTypeId,@ExamIndex,@NoOfAttempts,@ExamYear,@ExamIndex " +
                                            ", @ExamSubject,@ExamStream,@ExamGrade,@ExamStatus) ";



            dbConnection.cmd.Parameters.AddWithValue("@EmployeeId", educationDetails.EmployeeId);
            dbConnection.cmd.Parameters.AddWithValue("@EducationTypeId", educationDetails.EducationTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@ExamIndex", educationDetails.ExamIndex);
            dbConnection.cmd.Parameters.AddWithValue("@NoOfAttempts", educationDetails.NoOfAttempts);
            dbConnection.cmd.Parameters.AddWithValue("@ExamYear", educationDetails.ExamYear);
            dbConnection.cmd.Parameters.AddWithValue("@ExamIndex", educationDetails.ExamIndex);
            dbConnection.cmd.Parameters.AddWithValue("@ExamSubject", educationDetails.ExamSubject);
            dbConnection.cmd.Parameters.AddWithValue("@ExamStream", educationDetails.ExamStream);
            dbConnection.cmd.Parameters.AddWithValue("@ExamGrade", educationDetails.ExamGrade);
            dbConnection.cmd.Parameters.AddWithValue("@ExamStatus", educationDetails.ExamStatus);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }
    }
}
