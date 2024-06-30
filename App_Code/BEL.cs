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

/// <summary>
/// Summary description for BEL
/// </summary>
/// 
namespace _Examination
{
    public class BEL
    {
        #region _REGISTRATION
        private string _CANDIDATEID;
        public string CANDIDATEID { get { return _CANDIDATEID; } set { _CANDIDATEID = value; } }
        private string _GENDER = string.Empty;
        public string GENDER { get { return _GENDER; } set { _GENDER = value; } }
        private string _CAT = string.Empty;
        public string CAT { get { return _CAT; } set { _CAT = value; } }
        private string _SUBCAT = string.Empty;
        public string SUBCAT { get { return _SUBCAT; } set { _SUBCAT = value; } }
        private string _NATION = string.Empty;
        public string NATION { get { return _NATION; } set { _NATION = value; } }
        private string _MONO = string.Empty;
        public string MONO { get { return _MONO; } set { _MONO = value; } }
        private string _LLN = string.Empty;
        public string LLN { get { return _LLN; } set { _LLN = value; } }
        private string _EMAIL = string.Empty;
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; } }
        private string _AADHAR = string.Empty;
        public string AADHAR { get { return _AADHAR; } set { _AADHAR = value; } }
        private string _MINORITY = string.Empty;
        public string MINORITY { get { return _MINORITY; } set { _MINORITY = value; } }
        #endregion _REGISTRATION
        #region _QUALIFICATION
        private string _QuaCandidateId;
        public string QuaCandidateId { get { return _QuaCandidateId; } set { _QuaCandidateId = value; } }
        private string _TENUNI;
        public string TENUNI { get { return _TENUNI; } set { _TENUNI = value; } }
        private string _TENYEAR;
        public string TENYEAR { get { return _TENYEAR; } set { _TENYEAR = value; } }
        private string _TENMO;
        public string TENMO { get { return _TENMO; } set { _TENMO = value; } }
        private string _TENMM;
        public string TENMM { get { return _TENMM; } set { _TENMM = value; } }
        private string _TENPER;
        public string TENPER { get { return _TENPER; } set { _TENPER = value; } }
        private string _TENSUB;
        public string TENSUB { get { return _TENSUB; } set { _TENSUB = value; } }
        private string _INTERUNI;
        public string INTERUNI { get { return _INTERUNI; } set { _INTERUNI = value; } }
        private string _INTERYEAR;
        public string INTERYEAR { get { return _INTERYEAR; } set { _INTERYEAR = value; } }
        private string _INTERMO;
        public string INTERMO { get { return _INTERMO; } set { _INTERMO = value; } }
        private string _INTERMM;
        public string INTERMM { get { return _INTERMM; } set { _INTERMM = value; } }
        private string _INTERPER;
        public string INTERPER { get { return _INTERPER; } set { _INTERPER = value; } }
        private string _INTERSUB;
        public string INTERSUB { get { return _INTERSUB; } set { _INTERSUB = value; } }
        private string _UG;
        public string UG { get { return _UG; } set { _UG = value; } }
        private string _UGUNI;
        public string UGUNI { get { return _UGUNI; } set { _UGUNI = value; } }
        private string _UGYEAR;
        public string UGYEAR { get { return _UGYEAR; } set { _UGYEAR = value; } }
        private string _UGMO;
        public string UGMO { get { return _UGMO; } set { _UGMO = value; } }
        private string _UGMM;
        public string UGMM { get { return _UGMM; } set { _UGMM = value; } }
        private string _UGPER;
        public string UGPER { get { return _UGPER; } set { _UGPER = value; } }
        private string _UGSUB;
        public string UGSUB { get { return _UGSUB; } set { _UGSUB = value; } }
        private string _PG;
        public string PG { get { return _PG; } set { _PG = value; } }
        private string _PGUNI;
        public string PGUNI { get { return _PGUNI; } set { _PGUNI = value; } }
        private string _PGYEAR;
        public string PGYEAR { get { return _PGYEAR; } set { _PGYEAR = value; } }
        private string _PGMO;
        public string PGMO { get { return _PGMO; } set { _PGMO = value; } }
        private string _PGMM;
        public string PGMM { get { return _PGMM; } set { _PGMM = value; } }
        private string _PGPER;
        public string PGPER { get { return _PGPER; } set { _PGPER = value; } }
        private string _PGSUB;
        public string PGSUB { get { return _PGSUB; } set { _PGSUB = value; } }
        private string _OTH;
        public string OTH { get { return _OTH; } set { _OTH = value; } }
        private string _OUNI;
        public string OUNI { get { return _OUNI; } set { _OUNI = value; } }
        private string _OYEAR;
        public string OYEAR { get { return _OYEAR; } set { _OYEAR = value; } }
        private string _ODIV;
        public string ODIV { get { return _ODIV; } set { _ODIV = value; } }
        private string _OMO;
        public string OMO { get { return _OMO; } set { _OMO = value; } }
        private string _OMM;
        public string OMM { get { return _OMM; } set { _OMM = value; } }
        private string _OPER;
        public string OPER { get { return _OPER; } set { _OPER = value; } }
        private string _OSUB;
        public string OSUB { get { return _OSUB; } set { _OSUB = value; } }
        private string _HPASS;
        public string HPASS { get { return _HPASS; } set { _HPASS = value; } }
        private string _HAREA;
        public string HAREA { get { return _HAREA; } set { _HAREA = value; } }
        private string _IPASS;
        public string IPASS { get { return _IPASS; } set { _IPASS = value; } }
        private string _ITIPASS;
        public string ITIPASS { get { return _ITIPASS; } set { _ITIPASS = value; } }


        #endregion _QUALIFICATION
        #region _ADDRESS
        private string _AddressCandidateId;
        public string AddressCandidateId { get { return _AddressCandidateId; } set { _AddressCandidateId = value; } }
        private string _CADDRESS;
        public string CADDRESS { get { return _CADDRESS; } set { _CADDRESS = value; } }
        private string _CSTATE;
        public string CSTATE { get { return _CSTATE; } set { _CSTATE = value; } }
        private string _CDISTRICT;
        public string CDISTRICT { get { return _CDISTRICT; } set { _CDISTRICT = value; } }
        private string _CTEHSIL;
        public string CTEHSIL { get { return _CTEHSIL; } set { _CTEHSIL = value; } }
        private string _CBLOCK;
        public string CBLOCK { get { return _CBLOCK; } set { _CBLOCK = value; } }
        private string _CPIN;
        public string CPIN { get { return _CPIN; } set { _CPIN = value; } }
        private string _ISADDRESSSAME;
        public string ISADDRESSSAME { get { return _ISADDRESSSAME; } set { _ISADDRESSSAME = value; } }
        private string _PADDRESS;
        public string PADDRESS { get { return _PADDRESS; } set { _PADDRESS = value; } }
        private string _PSTATE;
        public string PSTATE { get { return _PSTATE; } set { _PSTATE = value; } }
        private string _PDISTRICT;
        public string PDISTRICT { get { return _PDISTRICT; } set { _PDISTRICT = value; } }
        private string _PTEHSIL;
        public string PTEHSIL { get { return _PTEHSIL; } set { _PTEHSIL = value; } }
        private string _PBLOCK;
        public string PBLOCK { get { return _PBLOCK; } set { _PBLOCK = value; } }
        private string _PPIN;
        public string PPIN { get { return _PPIN; } set { _PPIN = value; } }
        #endregion _ADDRESS
        #region _INS
        private string _OLDPASS;
        public string OLDPASS { get { return _OLDPASS; } set { _OLDPASS = value; } }
        private string _INSPASSWORD;
        public string INSPASSWORD { get { return _INSPASSWORD; } set { _INSPASSWORD = value; } }
        private string _PWDINSCODE;
        public string PWDINSCODE { get { return _PWDINSCODE; } set { _PWDINSCODE = value; } }
        private string _PWD;
        public string PWD { get { return _PWD; } set { _PWD = value; } }
        private string _INSMONO;
        public string INSMONO { get { return _INSMONO; } set { _INSMONO = value; } }
        private string _INSLLNO;
        public string INSLLNO { get { return _INSLLNO; } set { _INSLLNO = value; } }
        private string _INSEMAIL;
        public string INSEMAIL { get { return _INSEMAIL; } set { _INSEMAIL = value; } }
        #endregion _INS
    }
}
