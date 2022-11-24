using ManPowerCore.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManPowerCore.Common
{
    public class ControllerFactory
    {
        public static ProgramAssigneeController CreateProgramAssigneeController()
        {
            ProgramAssigneeController programAssigneeController = new ProgramAssigneeControllerImpl();
            return (ProgramAssigneeController)programAssigneeController;
        }
    
        public static ProgramAttendenceController CreateProgramAttendenceController()
        {
            ProgramAttendenceController programAttendenceController = new ProgramAttendenceControllerImpl();
            return (ProgramAttendenceController)programAttendenceController;
        }

        public static ProgramBudgetController CreateProgramBudgetController()
        {
            ProgramBudgetController programBudgetController = new ProgramBudgetControllerImpl();
            return (ProgramBudgetController)programBudgetController;
        }

        public static ProgramCategoryController CreateProgramCategoryController()
        {
            ProgramCategoryController programCategoryController = new ProgramCategoryControllerImpl();
            return (ProgramCategoryController)programCategoryController;
        }

        public static ProgramController CreateProgramController()
        {
            ProgramController programController = new ProgramControllerImpl();
            return (ProgramController)programController;
        }

        public static ProgramPlanController CreateProgramPlanController()
        {
            ProgramPlanController programPlanController = new ProgramPlanControllerImpl();
            return (ProgramPlanController)programPlanController;
        }

        public static ProgramTargetController CreateProgramTargetController()
        {
            ProgramTargetController programTargetController = new ProgramTargetControllerImpl();
            return (ProgramTargetController)programTargetController;
        }

        public static ProgramTypeController CreateProgramTypeController()
        {
            ProgramTypeController programTypeController = new ProgramTypeControllerImpl();
            return (ProgramTypeController)programTypeController;
        }

        public static ProjectStatusController CreateProjectStatusController()
        {
            ProjectStatusController projectStatusController = new ProjectStatusControllerImpl();
            return (ProjectStatusController)projectStatusController;
        }

        public static DepartmentUnitTypeController CreateDepartmentUnitTypeController()
        {
            DepartmentUnitTypeController aa = new DepartmentUnitTypeControllerImpl();
            return (DepartmentUnitTypeController)aa;
        }

        public static DepartmentUnitController CreateDepartmentUnitController()
        {
            DepartmentUnitController aa = new DepartmentUnitControllerImpl();
            return (DepartmentUnitController)aa;
        }

        public static PossitionsController CreatePossitionsController()
        {
            PossitionsController possitionsController = new PossitionsControllerImpl();
            return (PossitionsController)possitionsController;
        }

        public static DepartmentUnitPositionsController CreateDepartmentUnitPositionsController()
        {
            DepartmentUnitPositionsController aa = new DepartmentUnitPositionsControllerImpl();
            return (DepartmentUnitPositionsController)aa;
        }

        public static SystemUserController CreateSystemUserController()
        {
            SystemUserController aa = new SystemUserControllerImpl();
            return (SystemUserController)aa;
        }

        public static UserTypeController CreateUserTypeController()
        {
            UserTypeController aa = new UserTypeControllerImpl();
            return (UserTypeController)aa;
        }

        public static DesignationController CreateDesignationController()
        {
            DesignationController aa = new DesignationControllerImpl();
            return (DesignationController)aa;
        }

        public static TaskAllocationController CreateTaskAllocationController()
        {
            TaskAllocationController aa = new TaskAllocationControllerImpl();
            return (TaskAllocationController)aa;
        }

        public static TaskAllocationDetailController CreateTaskAllocationDetailController()
        {
            TaskAllocationDetailController aa = new TaskAllocationDetailControllerImpl();
            return (TaskAllocationDetailController)aa;
        }

        public static TaskTypeController CreateTaskTypeController()
        {
            TaskTypeController aa = new TaskTypeControllerImpl();
            return (TaskTypeController)aa;
        }

        public static ProjectTaskController CreateProjectTaskController()
        {
            ProjectTaskController aa = new ProjectTaskControllerImpl();
            return (ProjectTaskController)aa;
        }

        public static CompanyVecansyRegistationDetailsController CreateCompanyVecansyRegistationDetailsController()
        {
            CompanyVecansyRegistationDetailsController aa = new CompanyVecansyRegistationDetailsControllerImpl();
            return (CompanyVecansyRegistationDetailsController)aa;
        }


        public static ResourcePersonController CreateResourcePersonController()
        {
            ResourcePersonController resourcePersonController = new ResourcePersonControllerImpl();
            return (ResourcePersonController)resourcePersonController;
        }

        public static ResourceProvisionProgressController CreateResourceProvisionProgressController()
        {
            ResourceProvisionProgressController resourceProvisionProgressController = new ResourceProvisionProgressControllerImpl();
            return (ResourceProvisionProgressController)resourceProvisionProgressController;
        }

        public static ProjectPlanResourceController CreateProjectPlanResourceController()
        {
            ProjectPlanResourceController aa = new ProjectPlanResourceControllerImpl();
            return (ProjectPlanResourceController)aa;
        }

        public static EntrepreneurController CreateEntrepreneurController()
        {
            EntrepreneurController aa = new EntrepreneurControllerImpl();
            return (EntrepreneurController)aa;
        }

        public static InduvidualBeneficiaryController CreateInduvidualBeneficiaryController()
        {
            InduvidualBeneficiaryController aa = new InduvidualBeneficiaryControllerImpl();
            return (InduvidualBeneficiaryController)aa;
        }

        public static MarketTypeController CreateMarketTypeController()
        {
            MarketTypeController aa = new MarketTypeControllerImpl();
            return (MarketTypeController)aa;
        }

        public static BusinessTypeController CreateBusinessTypeController()
        {
            BusinessTypeController aa = new BusinessTypeControllerImpl();
            return (BusinessTypeController)aa;
        }

        public static BeneficiaryTypeController CreateBeneficiaryTypeController()
        {
            BeneficiaryTypeController aa = new BeneficiaryTypeControllerImpl();
            return (BeneficiaryTypeController)aa;
        }

        public static BeneficiaryController CreateBeneficiaryController()
        {
            BeneficiaryController aa = new BeneficiaryControllerImpl();
            return (BeneficiaryController)aa;
        }

        public static AutSystemRoleFunctionController CreateAutSystemRoleFunctionController()
        {
            AutSystemRoleFunctionController aa = new AutSystemRoleFunctionControllerImpl();
            return (AutSystemRoleFunctionController)aa;
        }

        public static AutFunctionController CreateAutFunctionController()
        {
            AutFunctionController aa = new AutFunctionControllerImpl();
            return (AutFunctionController)aa;
        }

        public static EthnicityController CreateEthnicityController()
        {
            EthnicityController aa = new EthnicityControllerImpl();
            return (EthnicityController)aa;
        }

        public static ReligionController CreateReligionController()
        {
            ReligionController aa = new ReligionControllerImpl();
            return (ReligionController)aa;
        }
        public static EmployeeController CreateEmployeeController()
        {
            EmployeeController employeeController = new EmployeeControllerImpl();
            return (EmployeeController)employeeController;
        }

        public static EmployeeContactController CreateEmployeeContactController()
        {
            EmployeeContactController employeeContactController = new EmployeeContactControllerImpl();
            return (EmployeeContactController)employeeContactController;
        }

        public static ContactModeController CreateContactModeController()
        {
            ContactModeController contactModeController = new ContactModeControllerImpl();
            return (ContactModeController)contactModeController;
        }

        public static EmergencyContactController CreateEmergencyContactController()
        {
            EmergencyContactController emergencyContactController = new EmergencyContactControllerImpl();
            return (EmergencyContactController)emergencyContactController;
        }

        public static EmploymentDetailsController CreateEmploymentDetailsController()
        {
            EmploymentDetailsController employmentDetailsController = new EmploymentDetailsControllerImpl();
            return (EmploymentDetailsController)employmentDetailsController;
        }

        public static PromotionController CreatePromotionController()
        {
            PromotionController promotionController = new PromotionControllerImpl();
            return (PromotionController)promotionController;
        }

        public static DependantController CreateDependantController()
        {
            DependantController dependantController = new DependantControllerImpl();
            return (DependantController)dependantController;

        }

        public static ContactTypeController CreateContactTypeController()
        {
            ContactTypeController contactTypeController = new ContactTypeControllerImpl();
            return (ContactTypeController)contactTypeController;

        }

        public static EducationTypeController CreateEducationTypeController()
        {
            EducationTypeController educationTypeController = new EducationTypeControllerImpl();
            return (EducationTypeController)educationTypeController;

        }

        public static DependantTypeController CreateDependantTypeController()
        {
            DependantTypeController dependantTypeController = new DependantTypeControllerImpl();
            return (DependantTypeController)dependantTypeController;

        }

        public static EducationDetailsController CreateEducationDetailsController()
        {
            EducationDetailsController educationDetailsController = new EducationDetailsControllerImpl();
            return (EducationDetailsController)educationDetailsController;

        }

    }
}
    