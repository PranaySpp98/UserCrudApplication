using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBAL
{
    public class Class1
    {
        public int Insert(UserSchema.Class1 objSchema)
        {
            try
             {
                UserDAL.Class1 objDAL = new UserDAL.Class1();
                return objDAL.InsertData(objSchema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(UserSchema.Class1 objSchema, int Id)
        {
            try
            {
                UserDAL.Class1 objDAL = new UserDAL.Class1();
                return objDAL.UpdateData(objSchema, Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(int Id)
        {
            try
            {
                UserDAL.Class1 objDAL = new UserDAL.Class1();
                return objDAL.DeleteData(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BindGrid()
        {
            try
            {
                UserDAL.Class1 objDAL = new UserDAL.Class1();
                return objDAL.BindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetById(int Id)
        {
            try
            {
                UserDAL.Class1 objDAL = new UserDAL.Class1();
                return objDAL.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
