//using ManPowerCore.Infrastructure;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Common
{
    public class DAOFactory
    {

        
        public static TrainingRequestDAO CreateTrainingRequestDAO()
        {
            TrainingRequestDAO trainingdao = new TrainingRequestDAOImpl();
            return (TrainingRequestDAO)trainingdao;
        }

        public static ProgramAssigneeDAO CreateProgramAssigneeDAO()
        {
            ProgramAssigneeDAO programAssigneeDAO = new ProgramAssigneeDAOImpl();
            return (ProgramAssigneeDAO)programAssigneeDAO;
        }


        public static ProgramAttendenceDAO CreateProgramAttendenceDAO()
        {
            ProgramAttendenceDAO programAttendenceDAO = new ProgramAttendenceDAOImpl();
            return (ProgramAttendenceDAO)programAttendenceDAO;
        }

      

        public static ProgramBudgetDAO CreateProgramBudgetDAO()
        {
            ProgramBudgetDAO programBudgetDAO = new ProgramBudgetDAOImpl();
            return (ProgramBudgetDAO)programBudgetDAO;
        }

        public static ProgramCategoryDAO CreateProgramCategoryDAO()
        {
            ProgramCategoryDAO programCategoryDAO = new ProgramCategoryDAOImpl();
            return (ProgramCategoryDAO)programCategoryDAO;
        }

        public static ProgramDAO CreateProgramDAO()
        {
            ProgramDAO programDAO = new ProgramDAOImpl();
            return (ProgramDAO)programDAO;
        }

        public static ProgramPlanDAO CreateProgramPlanDAO()
        {
            ProgramPlanDAO programPlanDAO = new ProgramPlanDAOImpl();
            return (ProgramPlanDAO)programPlanDAO;
        }

        public static ProgramTargetDAO CreateProgramTargetDAO()
        {
            ProgramTargetDAO programTargetDAO = new ProgramTargetDAOImpl();
            return (ProgramTargetDAO)programTargetDAO;
        }

        public static ProgramTypeDAO CreateProgramTypeDAO()
        {
            ProgramTypeDAO programTypeDAO = new ProgramTypeDAOImpl();
            return (ProgramTypeDAO)programTypeDAO;
        }

        public static ProjectStatusDAO CreateProjectStatusDAO()
        {
            ProjectStatusDAO projectStatusDAO = new ProjectStatusDAOImpl();
            return (ProjectStatusDAO)projectStatusDAO;
        }


        public static UserTypeDAO CreateUserTypeDAO()
        {
           UserTypeDAO aa = new UserTypeDAOImpl();
            return (UserTypeDAO)aa;
        }

        public static PossitionsDAO CreatePossitionsDAO()
        {
            PossitionsDAO aa = new PossitionsDAOImpl();
            return (PossitionsDAO)aa;
        }

        public static SystemUserDAO CreateSystemUserDAO()
        {
            SystemUserDAO aa = new SystemUserDAOImpl();
            return (SystemUserDAO)aa;
        }

        public static DesignationDAO CreateDesignationDAO()
        {
            DesignationDAO aa = new DesignationDAOImpl();
            return (DesignationDAO)aa;
        }

        public static DepartmentUnitTypeDAO CreateDepartmentUnitTypeDAO()
        {
            DepartmentUnitTypeDAO aa = new DepartmentUnitTypeDAOImpl();
            return (DepartmentUnitTypeDAO)aa;
        }

        public static DepartmentUnitPositionsDAO CreateDepartmentUnitPositionsDAO()
        {
            DepartmentUnitPositionsDAO aa = new DepartmentUnitPositionsDAOImpl();
            return (DepartmentUnitPositionsDAO)aa;
        }

        public static DepartmentUnitDAO CreateDepartmentUnitDAO()
        {
            DepartmentUnitDAO aa = new DepartmentUnitDAOImpl();
            return (DepartmentUnitDAO)aa;
        }

        public static TaskAllocationDAO CreateTaskAllocationDAO()
        {
            TaskAllocationDAO aa = new TaskAllocationDAOImpl();
            return (TaskAllocationDAO)aa;
        }

        public static TaskAllocationDetailDAO CreateTaskAllocationDetailDAO()
        {
            TaskAllocationDetailDAO aa = new TaskAllocationDetailDAOImpl();
            return (TaskAllocationDetailDAO)aa;
        }

        public static TaskTypeDAO CreateTaskTypeDAO()
        {
            TaskTypeDAO aa = new TaskTypeDAOImpl();
            return (TaskTypeDAO)aa;
        }

        public static ProjectTaskDAO CreateProjectTaskDAO()
        {
            ProjectTaskDAO aa = new ProjectTaskDAOImpl();
            return (ProjectTaskDAO)aa;
        }


        public static CompanyVecansyRegistationDetailsDAO CreateCompanyVecansyRegistationDetailsDAO()
        {
            CompanyVecansyRegistationDetailsDAO aa = new CompanyVecansyRegistationDetailsDAOImpl();
            return (CompanyVecansyRegistationDetailsDAO)aa;
        }

        public static ResourcePersonDAO CreateResourcePersonDAO()
        {
            ResourcePersonDAO resourcePersonDAO = new ResourcePersonDAOImpl();
            return (ResourcePersonDAO)resourcePersonDAO;
        }

        public static ResourceProvisionProgressDAO CreateResourceProvisionProgressDAO()
        {
            ResourceProvisionProgressDAO resourceProvisionProgressDAO = new ResourceProvisionProgressDAOImpl();
            return (ResourceProvisionProgressDAO)resourceProvisionProgressDAO;
        }

        public static ProjectPlanResourceDAO CreateProjectPlanResourceDAO()
        {
            ProjectPlanResourceDAO aa = new ProjectPlanResourceDAOImpl();
            return (ProjectPlanResourceDAO)aa;
        }

        public static EntrepreneurDAO CreateEntrepreneurDAO()
        {
            EntrepreneurDAO aa = new EntrepreneurDAOImpl();
            return (EntrepreneurDAO)aa;
        }

        public static InduvidualBeneficiaryDAO CreateInduvidualBeneficiaryDAO()
        {
            InduvidualBeneficiaryDAO aa = new InduvidualBeneficiaryDAOImpl();
            return (InduvidualBeneficiaryDAO)aa;
        }

        public static MarketTypeDAO CreateMarketTypeDAO()
        {
            MarketTypeDAO aa = new MarketTypeDAOImpl();
            return (MarketTypeDAO)aa;
        }

        public static BusinessTypeDAO CreateBusinessTypeDAO()
        {
            BusinessTypeDAO aa = new BusinessTypeDAOImpl();
            return (BusinessTypeDAO)aa;
        }

        public static BeneficiaryTypeDAO CreateBeneficiaryTypeDAO()
        {
            BeneficiaryTypeDAO aa = new BeneficiaryTypeDAOImpl();
            return (BeneficiaryTypeDAO)aa;
        }

        public static BeneficiaryDAO CreateBeneficiaryDAO()
        {
            BeneficiaryDAO aa = new BeneficiaryDAOImpl();
            return (BeneficiaryDAO)aa;
        }

        public static AutSystemRoleFunctionDAO CreateAutSystemRoleFunctionDAO()
        {
            AutSystemRoleFunctionDAO aa = new AutSystemRoleFunctionDAOImpl();
            return (AutSystemRoleFunctionDAO)aa;
        }

        public static AutFunctionDAO CreateAutFunctionDAO()
        {
            AutFunctionDAO aa = new AutFunctionDAOImpl();
            return (AutFunctionDAO)aa;
        }

        public static EthnicityDAO CreateEthnicityDAO()
        {
            EthnicityDAO aa = new EthnicityDAOImpl();
            return (EthnicityDAO)aa;
        }

        public static ReligionDAO CreateReligionDAO()
        {
            ReligionDAO aa = new ReligionDAOImpl();
            return (ReligionDAO)aa;
        }

        public static EmployeeDAO CreateEmployeeDAO()
        {
            EmployeeDAO employeeDAO = new EmployeeDAOImpl();
            return (EmployeeDAO)employeeDAO;
        }

        public static EmployeeContactDAO CreateEmployeeContactDAO()
        {
            EmployeeContactDAO employeeContactDAO = new EmployeeContactDAOImpl();
            return (EmployeeContactDAO)employeeContactDAO;
        }

        public static ContactModeDAO CreateContactModeDAO()
        {
            ContactModeDAO contactModeDAO = new ContactModeDAOImpl();
            return (ContactModeDAO)contactModeDAO;
        }

        public static EmergencyContactDAO CreateEmergencyContactDAO()
        {
            EmergencyContactDAO emergencyContactDAO = new EmergencyContactDAOImpl();
            return (EmergencyContactDAO)emergencyContactDAO;
        }

        public static EmploymentDetailsDAO CreateEmploymentDetailsDAO()
        {
            EmploymentDetailsDAO employmentDetailsDAO = new EmploymentDetailsDAOImpl();
            return (EmploymentDetailsDAO)employmentDetailsDAO;
        }

        public static PromotionsDAO CreatePromotionsDAO()
        {
            PromotionsDAO PromotionsDAO = new PromotionsDAOImpl();
            return (PromotionsDAO)PromotionsDAO;
        }

        public static DependentDAO CreateDependentDAO()
        {
            DependentDAO dependentDAO = new DependentDAOImpl();
            return (DependentDAO)dependentDAO;
        }

        public static ContactTypeDAO CreateContactTypeDAO()
        {
            ContactTypeDAO contactTypeDAO = new ContactTypeDAOImpl();
            return (ContactTypeDAO)contactTypeDAO;
        }

        public static EducationTypeDAO CreateEducationTypeDAO()
        {
            EducationTypeDAO educationTypeDAO = new EducationTypeDAOImpl();
            return (EducationTypeDAO)educationTypeDAO;
        }

        public static DependantTypeDAO CreateDependantTypeDAO()
        {
            DependantTypeDAO dependantTypeDAO = new DependantTypeDAOImpl();
            return (DependantTypeDAO)dependantTypeDAO;
        }

        public static EducationDetailsDAO CreateEducationDetailsDAO()
        {
            EducationDetailsDAO educationDetailsDAO = new EducationDetailsDAOImpl();
            return (EducationDetailsDAO)educationDetailsDAO;
        }

    }
}
