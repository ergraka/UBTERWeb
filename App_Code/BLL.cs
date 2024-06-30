using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

/// <summary>
/// Summary description for BLL
/// </summary>
/// 
namespace _Examination
{
    public class BLL
    {
        public string _Registration(BEL objbel)//REGISTRATION
        {
            DAL objdal = new DAL();
            try
            {
                return objdal._REGISTRATION(objbel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }
        public string _REGIDBLL(BEL objbel)//REGID
        {
            DAL objdal = new DAL();
            try
            {
                return objdal._REGIDDAL(objbel);
            }
            catch (Exception ex) { throw ex; }
            finally { objdal = null; }
        }
        public string _QUABLL(BEL objbel)//Qualification
        {
            DAL objdal = new DAL();
            try
            {
                return objdal._QuaDAL(objbel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }
        
        public string _ADDRESSBLL(BEL objbel)//ADDRESS
        {
            DAL objdal = new DAL();
            try
            {
                return objdal._ADDRESSDAL(objbel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }
        public string _INSBLL(BEL objbel)//INS
        {
            DAL objdal = new DAL();
            try
            {
                return objdal._INSDAL(objbel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal = null;
            }
        }
        public void Get_user_login(ref DataTable dt, string[] param)//CANDIDATEID LOGIN
        {
            try
            {
                DAL objDAL = new DAL();
                ArrayList names = new ArrayList();
                ArrayList types = new ArrayList();
                ArrayList values = new ArrayList();

                dt.Clear();
                dt = new DataTable();
                names.Add("@CandidateID"); types.Add("varchar"); values.Add(param[0].ToString());
                names.Add("@PASSWORD"); types.Add("varchar"); values.Add(param[1].ToString());
                objDAL.GetLogin(ref dt, "UDP_UserLogin", names, types, values);

            }
            catch (Exception ex) { throw ex; }
        }
        public void Get_roll_login(ref DataTable dt, string[] param)//ROLL LOGIN
        {
            try
            {
                DAL objDAL = new DAL();
                ArrayList names = new ArrayList();
                ArrayList types = new ArrayList();
                ArrayList values = new ArrayList();

                dt.Clear();
                dt = new DataTable();
                names.Add("@ROLL"); types.Add("varchar"); values.Add(param[0].ToString());
                names.Add("@PASSWORD"); types.Add("varchar"); values.Add(param[1].ToString());
                objDAL.GetLogin(ref dt, "UDP_RollLogin", names, types, values);

            }
            catch (Exception ex) { throw ex; }
        }
        public void HOD_login(ref DataTable dt, string[] param)//INSTITUTE LOGIN
        {
            try
            {
                DAL objDAL = new DAL();
                ArrayList names = new ArrayList();
                ArrayList types = new ArrayList();
                ArrayList values = new ArrayList();
                dt.Clear();
                dt = new DataTable();
                names.Add("@INSCODE"); types.Add("varchar"); values.Add(param[0].ToString());
                names.Add("@PASSWORD"); types.Add("varchar"); values.Add(param[1].ToString());

                objDAL.GetLogin(ref dt, "UDP_Loginins", names, types, values);

            }
            catch (Exception ex) { throw ex; }
        }

        public void InsLogin(ref DataTable dt, string[] param)//INSTITUTE LOGIN
        {
            try
            {
                DAL objDAL = new DAL();
                ArrayList names = new ArrayList();
                ArrayList types = new ArrayList();
                ArrayList values = new ArrayList();
                dt.Clear();
                dt = new DataTable();
                names.Add("@INSCODE"); types.Add("varchar"); values.Add(param[0].ToString());
                names.Add("@BRCODE"); types.Add("varchar"); values.Add(param[1].ToString());
                names.Add("@PASSWORD"); types.Add("varchar"); values.Add(param[2].ToString());
                objDAL.GetLogin(ref dt, "UDP_Loginins", names, types, values);

            }
            catch (Exception ex) { throw ex; }
        }

        public void AdminLogin(ref DataTable dt, string[] param)//INSTITUTE LOGIN
        {
            try
            {
                DAL objDAL = new DAL();
                ArrayList names = new ArrayList();
                ArrayList types = new ArrayList();
                ArrayList values = new ArrayList();
                dt.Clear();
                dt = new DataTable();
                names.Add("@User"); types.Add("varchar"); values.Add(param[0].ToString());
                names.Add("@Password"); types.Add("varchar"); values.Add(param[1].ToString());
                objDAL.GetLogin(ref dt, "UDP_AdminLogin", names, types, values);

            }
            catch (Exception ex) { throw ex; }
        }

        public void QUERYBLL(ref DataTable dt, string[] param)//accossires for data
        {
            try
            {
                DAL objDAL = new DAL();
                ArrayList names = new ArrayList();
                ArrayList types = new ArrayList();
                ArrayList values = new ArrayList();
                dt.Clear();
                dt = new DataTable();
                names.Add("@QUERYTEXT"); types.Add("varchar"); values.Add(param[0].ToString());
                objDAL.QUERYDAL(ref dt, "UDP_QUERY", names, types, values);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string WorkCRUD(string Condition, string WorkId, string LongStr)//accossires for data
        {
            try
            {
                DAL objDAL = new DAL();
              
                

                string result=objDAL.Works(Condition, WorkId, LongStr);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ONLYQUERYBLL(string querytxt)//accossires for action
        {
            try
            {
                DAL objDAL = new DAL();
                return objDAL.ONLYQUERYDAL(querytxt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}