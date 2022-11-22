using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ASGSSTN006.BAL
{
    public class DesignationBAL
    {
        DAL.DesignationDAL objdeptdl = new DAL.DesignationDAL();
        private int _desigid;
        private string _desig;
        private int _deptid;

        public int desigid
        {
            get
            {
                return _desigid;
            }
            set
            {
                _desigid = value;
            }
        }

        public string desig
        {
            get
            {
                return _desig;
            }
            set
            {
                _desig = value;
            }
        }

        public int deptid
        {
            get
            {
                return _deptid;
            }
            set
            {
                _deptid = value;
            }
        }

        public DataTable DesignationValues()
        {

            return objdeptdl.Designation_list();

        }
        public int insertDesignation()
        {
            return objdeptdl.insert_Designation(this);
        }

        public DataTable viewDesignation()
        {
            return objdeptdl.view_Designation();
        }

        public int updateDesignation()
        {
            return objdeptdl.Update_Designation(this);
        }
        public int deleteDesignation()
        {
            return objdeptdl.Delete_Designation(this);
        }
    }
}