using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace IncidentesADO
{
    public class ConexionADO
    {
        public string GetCnx()
        {

            string strCnx = ConfigurationManager.ConnectionStrings["PYG"].ConnectionString;
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }
        public string GetCnxI()
        {

            string strCnx = ConfigurationManager.ConnectionStrings["PYG1"].ConnectionString;
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }
    }
}
