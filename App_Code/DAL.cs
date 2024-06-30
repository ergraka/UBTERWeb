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
using System.Data.SqlClient;
using System.Collections;


/// <summary>
/// Summary description for DAL
/// </summary>
/// 
namespace _Examination
{
    public class DAL
    {
        #region _Connection
        string connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["S@N"].ConnectionString.ToString();
        SqlConnection conn;
        SqlCommand cmd;
        #endregion
        public string _REGISTRATION(BEL Objbel)//REGISTRATION
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_REG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@CANDIDATEID", SqlDbType.VarChar, 8).Value = Objbel.CANDIDATEID;
                cmd.Parameters.Add("@GENDER", SqlDbType.VarChar, 1).Value = Objbel.GENDER;
                cmd.Parameters.Add("@CAT", SqlDbType.VarChar, 3).Value = Objbel.CAT;
                cmd.Parameters.Add("@SUBCAT", SqlDbType.VarChar, 3).Value = Objbel.SUBCAT;
                cmd.Parameters.Add("@NATION", SqlDbType.VarChar, 50).Value = Objbel.NATION;
                cmd.Parameters.Add("@MONO", SqlDbType.VarChar, 10).Value = Objbel.MONO;
                cmd.Parameters.Add("@LLN", SqlDbType.VarChar, 13).Value = Objbel.LLN;
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 50).Value = Objbel.EMAIL;
                cmd.Parameters.Add("@AADHAR", SqlDbType.VarChar, 12).Value = Objbel.AADHAR;
                cmd.Parameters.Add("@MINORITY", SqlDbType.VarChar, 1).Value = Objbel.MINORITY;
                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 1);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                int Res = cmd.ExecuteNonQuery();
                string Result = (string)cmd.Parameters["@Result"].Value;
                conn.Close();
                return Result + "-" + Res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }


        public string Works(string Condition,string WorkId,string LongStr)//REGISTRATION
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_Works", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@P_Condition", SqlDbType.VarChar, 30).Value = Condition;
                cmd.Parameters.Add("@P_WorkId", SqlDbType.VarChar, 15).Value = WorkId;
                cmd.Parameters.Add("@P_LongStr", SqlDbType.VarChar).Value = LongStr;

                cmd.Parameters.Add("@P_ProcMessage", SqlDbType.VarChar, 50);
                cmd.Parameters["@P_ProcMessage"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@P_ProcReturn", SqlDbType.Int);
                cmd.Parameters["@P_ProcReturn"].Direction = ParameterDirection.Output;

           
                    
                int Res = cmd.ExecuteNonQuery();
                string Result = Convert.ToString(cmd.Parameters["@P_ProcReturn"].Value);
                conn.Close();
                return Result + "-" + "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public string _REGIDDAL(BEL Objbel)//REGID INSERT
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_REGID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@CANDIDATEID", SqlDbType.VarChar, 8);
                cmd.Parameters["@CANDIDATEID"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 12).Value = Objbel.OLDPASS;
                cmd.ExecuteNonQuery();
                string CANDIDATEID = (string)cmd.Parameters["@CANDIDATEID"].Value;
                conn.Close();
                return CANDIDATEID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public string _QuaDAL(BEL Objbel)//Qualification
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_QUA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@CANDIDATEID", SqlDbType.VarChar, 8).Value = Objbel.QuaCandidateId;
                cmd.Parameters.Add("@TENUNI", SqlDbType.VarChar, 100).Value = Objbel.TENUNI;
                cmd.Parameters.Add("@TENYEAR", SqlDbType.VarChar, 4).Value = Objbel.TENYEAR;
                cmd.Parameters.Add("@TENMO", SqlDbType.VarChar, 4).Value = Objbel.TENMO;
                cmd.Parameters.Add("@TENMM", SqlDbType.VarChar, 4).Value = Objbel.TENMM;
                cmd.Parameters.Add("@TENPER", SqlDbType.VarChar, 5).Value = Objbel.TENPER;
                cmd.Parameters.Add("@INTERUNI", SqlDbType.VarChar, 100).Value = Objbel.INTERUNI;
                cmd.Parameters.Add("@INTERYEAR", SqlDbType.VarChar, 4).Value = Objbel.INTERYEAR;
                cmd.Parameters.Add("@INTERMO", SqlDbType.VarChar, 4).Value = Objbel.INTERMO;
                cmd.Parameters.Add("@INTERMM", SqlDbType.VarChar, 4).Value = Objbel.INTERMM;
                cmd.Parameters.Add("@INTERPER", SqlDbType.VarChar, 5).Value = Objbel.INTERPER;
                cmd.Parameters.Add("@UG", SqlDbType.VarChar, 50).Value = Objbel.UG;
                cmd.Parameters.Add("@UGUNI", SqlDbType.VarChar, 100).Value = Objbel.UGUNI;
                cmd.Parameters.Add("@UGYEAR", SqlDbType.VarChar, 4).Value = Objbel.UGYEAR;
                cmd.Parameters.Add("@UGMO", SqlDbType.VarChar, 4).Value = Objbel.UGMO;
                cmd.Parameters.Add("@UGMM", SqlDbType.VarChar, 4).Value = Objbel.UGMM;
                cmd.Parameters.Add("@UGPER", SqlDbType.VarChar, 5).Value = Objbel.UGPER;
                cmd.Parameters.Add("@PG", SqlDbType.VarChar, 50).Value = Objbel.PG;
                cmd.Parameters.Add("@PGUNI", SqlDbType.VarChar, 100).Value = Objbel.PGUNI;
                cmd.Parameters.Add("@PGYEAR", SqlDbType.VarChar, 4).Value = Objbel.PGYEAR;
                cmd.Parameters.Add("@PGMO", SqlDbType.VarChar, 4).Value = Objbel.PGMO;
                cmd.Parameters.Add("@PGMM", SqlDbType.VarChar, 4).Value = Objbel.PGMM;
                cmd.Parameters.Add("@PGPER", SqlDbType.VarChar, 5).Value = Objbel.PGPER;
                cmd.Parameters.Add("@OTH", SqlDbType.VarChar, 50).Value = Objbel.OTH;
                cmd.Parameters.Add("@OUNI", SqlDbType.VarChar, 100).Value = Objbel.OUNI;
                cmd.Parameters.Add("@OYEAR", SqlDbType.VarChar, 4).Value = Objbel.OYEAR;
                cmd.Parameters.Add("@OMO", SqlDbType.VarChar, 4).Value = Objbel.OMO;
                cmd.Parameters.Add("@OMM", SqlDbType.VarChar, 4).Value = Objbel.OMM;
                cmd.Parameters.Add("@OPER", SqlDbType.VarChar, 5).Value = Objbel.OPER;
                cmd.Parameters.Add("@HPASS", SqlDbType.VarChar, 1).Value = Objbel.HPASS;
                cmd.Parameters.Add("@HAREA", SqlDbType.VarChar, 1).Value = Objbel.HAREA;
                cmd.Parameters.Add("@IPASS", SqlDbType.VarChar, 1).Value = Objbel.IPASS;
                cmd.Parameters.Add("@ITIPASS", SqlDbType.VarChar, 1).Value = Objbel.ITIPASS;
                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 1);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                int Res = cmd.ExecuteNonQuery();
                string Result = (string)cmd.Parameters["@Result"].Value;
                conn.Close();
                return Result + "-" + Res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        
        public string _ADDRESSDAL(BEL Objbel)//ADDRESS
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_ADDRESS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@CANDIDATEID", SqlDbType.VarChar, 8).Value = Objbel.AddressCandidateId;
                cmd.Parameters.Add("@CADDRESS", SqlDbType.VarChar, 100).Value = Objbel.CADDRESS;
                cmd.Parameters.Add("@CSTATE", SqlDbType.VarChar, 50).Value = Objbel.CSTATE;
                cmd.Parameters.Add("@CDISTRICT", SqlDbType.VarChar, 50).Value = Objbel.CDISTRICT;
                cmd.Parameters.Add("@CTEHSIL", SqlDbType.VarChar, 35).Value = Objbel.CTEHSIL;
                cmd.Parameters.Add("@CBLOCK", SqlDbType.VarChar, 35).Value = Objbel.CBLOCK;
                cmd.Parameters.Add("@CPIN", SqlDbType.VarChar, 6).Value = Objbel.CPIN;
                cmd.Parameters.Add("@ISSAME", SqlDbType.Int).Value = Objbel.ISADDRESSSAME;
                cmd.Parameters.Add("@PADDRESS", SqlDbType.VarChar, 100).Value = Objbel.PADDRESS;
                cmd.Parameters.Add("@PSTATE", SqlDbType.VarChar, 50).Value = Objbel.PSTATE;
                cmd.Parameters.Add("@PDISTRICT", SqlDbType.VarChar, 50).Value = Objbel.PDISTRICT;
                cmd.Parameters.Add("@PTEHSIL", SqlDbType.VarChar, 35).Value = Objbel.PTEHSIL;
                cmd.Parameters.Add("@PBLOCK", SqlDbType.VarChar, 35).Value = Objbel.PBLOCK;
                cmd.Parameters.Add("@PPIN", SqlDbType.VarChar, 6).Value = Objbel.PPIN;
                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 1);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                int Res = cmd.ExecuteNonQuery();
                string Result = (string)cmd.Parameters["@Result"].Value;
                conn.Close();
                return Result + "-" + Res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public string _INSDAL(BEL Objbel)//CHANGE PASSWORD
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_INS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@OLDPASS", SqlDbType.VarChar, 12).Value = Objbel.OLDPASS;
                cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 12).Value = Objbel.INSPASSWORD;
                cmd.Parameters.Add("@INSCODE", SqlDbType.VarChar, 3).Value = Objbel.PWDINSCODE;
                cmd.Parameters.Add("@PWD", SqlDbType.VarChar, 1).Value = Objbel.PWD;
                cmd.Parameters.Add("@MONO", SqlDbType.VarChar, 10).Value = Objbel.INSMONO;
                cmd.Parameters.Add("@LLNO", SqlDbType.VarChar,13).Value = Objbel.INSLLNO;
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 50).Value = Objbel.INSEMAIL;
                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 1);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                int Res = cmd.ExecuteNonQuery();
                string Result = (string)cmd.Parameters["@Result"].Value;
                conn.Close();
                return Result + "-" + Res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public void GetLogin(ref DataTable dt, String sp, ArrayList names, ArrayList types, ArrayList values)//LOGIN
        {
            try
            {
                conn = new SqlConnection(connectionstring);
                SqlDataAdapter adp;
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandText = sp;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                for (Int32 i = 0; i < names.Count; i++)
                {
                    SqlParameter paraInput = cmd.Parameters.AddWithValue(names[i].ToString(), types[i]);
                    paraInput.Direction = ParameterDirection.Input;
                    paraInput.Value = values[i];
                }
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                conn.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        
        public void QUERYDAL(ref DataTable dt, String sp, ArrayList names, ArrayList types, ArrayList values)//ACCESSORIES
        {
            try
            {

                conn = new SqlConnection(connectionstring);
                SqlDataAdapter adp;
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandText = sp;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                for (Int32 i = 0; i < names.Count; i++)
                {
                    SqlParameter paraInput = cmd.Parameters.AddWithValue(names[i].ToString(), types[i]);
                    paraInput.Direction = ParameterDirection.Input;
                    paraInput.Value = values[i];
                }
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        public string ONLYQUERYDAL(String Querytxt)//ACCESSORIES for GET DATA
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_ONLYQUERY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@QUERYTEXT", SqlDbType.VarChar, 1000).Value = Querytxt;
                cmd.Parameters.Add("@Result", SqlDbType.VarChar, 1);
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                int Res= cmd.ExecuteNonQuery();
                string Result = (string)cmd.Parameters["@Result"].Value;
                conn.Close();
                return Result + "-" + Res.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        
        public void _IP(string IP)//IP
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("UDP_InsertIp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add("@ipadd", SqlDbType.VarChar, 50).Value = IP;
                cmd.Parameters.Add("@ipstatus", SqlDbType.VarChar, 3).Value = "HIT";
                cmd.ExecuteNonQuery();
                conn.Close();
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }


    }
}