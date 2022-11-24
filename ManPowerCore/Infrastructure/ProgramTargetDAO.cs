using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramTargetDAO
    {
        List<ProgramTarget> GetAllProgramTarget(DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetByProgramId( int programId, DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetByProgramTypeId(int programtypeId, DBConnection dbConnection);

        ProgramTarget GetProgramTarget(int id, DBConnection dbConnection);

        int SaveProgramTarget(ProgramTarget programTarget, DBConnection dbConnection);

        int UpdateProgramTarget(ProgramTarget programTarget, DBConnection dbConnection);

        int UpdateProgramTargetApproval(int id, int status, DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetFilter(int runYear, int runMonth, DBConnection dbConnection);

        List<ProgramTarget> GetAllProgramTargetFilter(int runType, DBConnection dbConnection);


    }

    public class ProgramTargetDAOImpl : ProgramTargetDAO
    {

        public int getMaxProgramTargetId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_TARGET";
            int orderId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (orderId == 0)
            {
                orderId = 1;
            }
            else
            {
                orderId += 1;
            }


            return orderId;
        }

        public int SaveProgramTarget(ProgramTarget programTarget, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramTargetId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_TARGET(PROGRAM_TYPE_ID,PROGRAM_ID,TITLE,DESCRIPTION," +
                                            "START_DATE,END_DATE,OUTCOME,VOTE_NUMBER,NO_OF_PROJECTS,ESTIMATED_AMOUNT,TARGET_YEAR," +
                                            "TARGET_MONTH,OUTPUT,INSTRACTIONS,IS_RECOMMENDED,RECOMMENDED_BY,RECOMMENDED_DATE) " +

                                 "VALUES(@ProgramTypeId,@ProgramId,@Title,@Description,@StartDate,@EndDate,@Outcome,@VoteNumber,@NoOfProjects,@EstimatedAmount,@TargetYear,@TargetMonth,@Output,@Instractions,@IsRecommended,@RecommendedBy,@RecommendedDate) SELECT SCOPE_IDENTITY() ";


                                    //dbConnection.cmd.Parameters.AddWithValue("@id", id);
                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeId", programTarget.ProgramTypeId);
                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramId", programTarget.ProgramId);
                                    dbConnection.cmd.Parameters.AddWithValue("@Title", programTarget.Title);
                                    dbConnection.cmd.Parameters.AddWithValue("@Description", programTarget.Description);
                                    dbConnection.cmd.Parameters.AddWithValue("@StartDate", programTarget.StartDate);
                                    dbConnection.cmd.Parameters.AddWithValue("@EndDate", programTarget.EndDate);
                                    dbConnection.cmd.Parameters.AddWithValue("@Outcome", programTarget.Outcome);
                                    dbConnection.cmd.Parameters.AddWithValue("@VoteNumber", programTarget.VoteNumber);
                                    dbConnection.cmd.Parameters.AddWithValue("@NoOfProjects", programTarget.NoOfProjects);
                                    dbConnection.cmd.Parameters.AddWithValue("@EstimatedAmount", programTarget.EstimatedAmount);
                                    dbConnection.cmd.Parameters.AddWithValue("@TargetYear", programTarget.TargetYear);
                                    dbConnection.cmd.Parameters.AddWithValue("@TargetMonth", programTarget.TargetMonth);
                                    dbConnection.cmd.Parameters.AddWithValue("@Output", programTarget.Output);
                                    dbConnection.cmd.Parameters.AddWithValue("@Instractions", programTarget.Instractions);
                                    dbConnection.cmd.Parameters.AddWithValue("@IsRecommended", programTarget.IsRecommended);
                                    dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", programTarget.RecommendedBy);
                                    dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", programTarget.RecommendedDate);

            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int UpdateProgramTarget(ProgramTarget programTarget, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TARGET SET PROGRAM_TYPE_ID =@ProgramTypeId , PROGRAM_ID = @ProgramId," +
                " TITLE = @Title, DESCRIPTION = @Description , START_DATE = @StartDate,END_DATE = @EndDate , OUTCOME = @Outcome , VOTE_NUMBER = @VoteNumber," +
                " NO_OF_PROJECTS = @NoOfProjects, ESTIMATED_AMOUNT = @EstimatedAmount, TARGET_YEAR = @TargetYear," +
                " TARGET_MONTH = @TargetMonth ,OUTPUT = @Output, INSTRACTIONS = @Instractions," +
                " IS_RECOMMENDED = @IsRecommended , RECOMMENDED_BY = @RecommendedBy, RECOMMENDED_DATE = @RecommendedDate  WHERE ID = @ProgramTargetId";



                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programTarget.ProgramTargetId);
                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeId", programTarget.ProgramTypeId);
                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramId", programTarget.ProgramId);
                                    dbConnection.cmd.Parameters.AddWithValue("@Title", programTarget.Title);
                                    dbConnection.cmd.Parameters.AddWithValue("@Description", programTarget.Description);
                                    dbConnection.cmd.Parameters.AddWithValue("@StartDate", programTarget.StartDate);
                                    dbConnection.cmd.Parameters.AddWithValue("@EndDate", programTarget.EndDate);
                                    dbConnection.cmd.Parameters.AddWithValue("@Outcome", programTarget.Outcome);
                                    dbConnection.cmd.Parameters.AddWithValue("@VoteNumber", programTarget.VoteNumber);
                                    dbConnection.cmd.Parameters.AddWithValue("@NoOfProjects", programTarget.NoOfProjects);
                                    dbConnection.cmd.Parameters.AddWithValue("@EstimatedAmount", programTarget.EstimatedAmount);
                                    dbConnection.cmd.Parameters.AddWithValue("@TargetYear", programTarget.TargetYear);
                                    dbConnection.cmd.Parameters.AddWithValue("@TargetMonth", programTarget.TargetMonth);
                                    dbConnection.cmd.Parameters.AddWithValue("@Output", programTarget.Output);
                                    dbConnection.cmd.Parameters.AddWithValue("@Instractions", programTarget.Instractions);
                                    dbConnection.cmd.Parameters.AddWithValue("@IsRecommended", programTarget.IsRecommended);
                                    dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", programTarget.RecommendedBy);
                                    dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", programTarget.RecommendedDate);




            return dbConnection.cmd.ExecuteNonQuery();
        }


        public int UpdateProgramTargetApproval(int id, int status, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TARGET SET IS_RECOMMENDED = " + status + " WHERE ID = " + id + " ";

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<ProgramTarget> GetAllProgramTargetFilter(int runYear, int runMonth, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET  WHERE TARGET_YEAR = "+runYear+ " AND TARGET_MONTH = "+runMonth+" ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }

        public List<ProgramTarget> GetAllProgramTarget(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }

        public ProgramTarget GetProgramTarget(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramTarget>(dbConnection.dr);

        }

        public List<ProgramTarget> GetAllProgramTargetByProgramId( int programId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE PROGRAM_ID = " + programId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);
        }


        public List<ProgramTarget> GetAllProgramTargetByProgramTypeId(int ProgramtypeId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE PROGRAM_TYPE_ID = " + ProgramtypeId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);
        }

        public List<ProgramTarget> GetAllProgramTargetFilter(int runType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TARGET WHERE PROGRAM_TYPE_ID  = " + runType + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramTarget>(dbConnection.dr);

        }

    }
}
