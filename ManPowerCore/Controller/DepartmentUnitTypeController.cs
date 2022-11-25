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
    public interface DepartmentUnitTypeController
    {
        List<DepartmentUnitType> GetAllDepartmentUnitType(bool withDepartmentUnit);
        DepartmentUnitType GetDepartmentUnitType(int id, bool withDepartmentUnit);
    }

    public class DepartmentUnitTypeControllerImpl : DepartmentUnitTypeController
    {
        DBConnection dBConnection;
        DepartmentUnitTypeDAO departmentUnitTypeDAO = DAOFactory.CreateDepartmentUnitTypeDAO();

        public List<DepartmentUnitType> GetAllDepartmentUnitType(bool withDepartmentUnit)
        {
            try
            {
                dBConnection = new DBConnection();
                List<DepartmentUnitType> list = departmentUnitTypeDAO.GetAllDepartmentUnitType(dBConnection);

                if (withDepartmentUnit)
                {
                    DepartmentUnitDAO _DepartmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnit = _DepartmentUnitDAO.GetAllDepartmentUnitByDepartmentUnitTypeId(item.DepartmentUnitTypeId, dBConnection);
                    }
                }


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

        public DepartmentUnitType GetDepartmentUnitType(int id, bool withDepartmentUnit)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                DepartmentUnitTypeDAO DAO = DAOFactory.CreateDepartmentUnitTypeDAO();
                DepartmentUnitType _departmentUnitType = DAO.GetDepartmentUnitType(id, dbConnection);

                if (withDepartmentUnit)
                {
                    DepartmentUnitDAO _DepartmentUnitDAO = DAOFactory.CreateDepartmentUnitDAO();
                    _departmentUnitType._DepartmentUnit = _DepartmentUnitDAO.GetAllDepartmentUnitByDepartmentUnitTypeId(_departmentUnitType.DepartmentUnitTypeId, dbConnection);
                }


                return _departmentUnitType;
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
