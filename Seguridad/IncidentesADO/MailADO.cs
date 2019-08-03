using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Web;
using System.Net.Mime;

namespace IncidentesADO
{
    public class MailADO
    {

        public bool sndMailHeader(string strTo, string strHTMLBody, string strSubject)
        {

            MailMessage objMail = new MailMessage();
            SmtpClient objsmtp = new SmtpClient();
            bool isSent;

            try
            {
                //string pathImg = HttpContext.Current.Server.MapPath("~/images/cabecera.gif");
                string server = ConfigurationSettings.AppSettings["mailServer"].ToString();
                string mailAccount = ConfigurationSettings.AppSettings["mailAccount"].ToString();
                objMail.From = new MailAddress(mailAccount);
                objsmtp.Host = server;
                objMail.Subject = strSubject;
                if (strTo.Contains("@mdlz.com"))
                    objMail.To.Add(strTo);
                else
                    objMail.To.Add(strTo + "@mdlz.com");
                //objMail.To.Add(strTo);
                //if (this.strCc != string.Empty)
                objMail.CC.Add("urco.jl@mdlz.com");
                //if (this.strBcc != string.Empty)
                //    msgMail.Bcc.Add(this.strBcc);
                LinkedResource img = new LinkedResource(@"D:\SisContratos\app\images\cabecera.jpg", MediaTypeNames.Image.Jpeg);
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(strHTMLBody, null, MediaTypeNames.Text.Html);
                av1.LinkedResources.Add(img);
                img.ContentId = "imagen";
                objMail.AlternateViews.Add(av1);
                objMail.IsBodyHtml = true;
                objMail.Body = strHTMLBody;
                objsmtp.Send(objMail);
                isSent = true;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                isSent = false;
            }
            finally
            {
                objMail.Dispose();
            }

            return (isSent);

        }
        public string doBodyIncidente(int _Id, string _Titulo, string _Departamento, string _Tip_empleado)
        {
            string TableHTML;
            TableHTML = "<style type=\"text/css\">body,td,th {	color: #00F;text-align: center;}</style>";
            TableHTML = "<h3><span style=\"font:'Frutiger 45 Light'; color:#00F\">Se registro incidente:</span></h3>";
            TableHTML = "<table width='600px' border='1' cellpadding='0' cellspacing='0' bordercolor='#FFE5A6'>";
            TableHTML += "<tr>";
            TableHTML += "<td style=\"height:50px\">";
            TableHTML += "<img src=\"cid:cabecera\" style=\"border:0px\" width=100% height=\"50\" /></td>";
            TableHTML += "</tr>";
            TableHTML += "<tr>";
            TableHTML += "<td>";
            TableHTML += "<table width='600px' border='0' cellpadding='3' cellspacing='3'>";
            TableHTML += "<tr><th style=\"width:60%;\">Incidente</th><th style=\"width:20%;\">Área</th><th style=\"width:20%;\">Empleado</th></tr>";
            TableHTML += "<tr>";
            TableHTML += "<td>";
            TableHTML += "&nbsp;";
            TableHTML += "<span style=\"font:'Frutiger 45 Light'; color:#9898CE\">El Incidente N° " + _Id.ToString() + " \"" + _Titulo + "\" ha sido registrado</span>";
            TableHTML += "</td>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _Departamento + "</span></td>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _Tip_empleado + "</span></td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "</td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "<br />";
            TableHTML += "<a href=\"http://materiales/Incidentes/admin/default.aspx?pkOrder=" + _Id + "\">Ir a la Web de Incidentes</a>";

            return TableHTML;
        }

        public string doBodyPlan(int _Incidente_id, string _Titulo, int _TipoPlan, string _Fecha, string _Plan, string _Asignado)
        {
            string TableHTML;
            TableHTML = "<style type=\"text/css\">body,td,th {	color: #00F;text-align: center;}</style>";
            TableHTML = "<h3><span style=\"font:'Frutiger 45 Light'; color:#00F\">Se registro incidente:</span></h3>";
            TableHTML = "<table width='600px' border='1' cellpadding='0' cellspacing='0' bordercolor='#FFE5A6'>";
            TableHTML += "<tr>";
            TableHTML += "<td style=\"height:50px\">";
            TableHTML += "<img src=\"cid:cabecera\" style=\"border:0px\" width=100% height=\"50\" /></td>";
            TableHTML += "</tr>";
            TableHTML += "<tr>";
            TableHTML += "<td>";
            TableHTML += "<table width='600px' border='0' cellpadding='3' cellspacing='3'>";
            TableHTML += "<tr>";
            TableHTML += "<td>";
            TableHTML += "&nbsp;";
            TableHTML += "<span style=\"font:'Frutiger 45 Light'; color:#9898CE\">Se le asigno el siguiente plan de acción \"" + _Plan + "\" <br>Incidente: " + _Incidente_id.ToString() + " \"" + _Titulo + "\"";
            TableHTML += "<br>Fecha del Incidente: " + _Fecha + "<br>Asignado por: "+_Asignado+"</span>";
            TableHTML += "</td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "</td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "<br/>";
            TableHTML += "<a href=\"http://materiales/Incidentes/admin/default.aspx\">Ir a la Web de Incidentes</a>";
            return TableHTML;
        }

        public string doBodyAlerta(int Alerta_id, string _Titulo, string _Departamento_id)
        {
            string TableHTML;
            TableHTML = "<style type=\"text/css\">body,td,th {	color: #00F;text-align: center;}</style>";
            TableHTML = "<h3><span style=\"font:'Frutiger 45 Light'; color:#00F\">Se registro Alerta:</span></h3>";
            TableHTML = "<table width='600px' border='1' cellpadding='0' cellspacing='0' bordercolor='#FFE5A6'>";
            TableHTML += "<tr>";
            TableHTML += "<td style=\"height:50px\">";
            TableHTML += "<img src=\"cid:cabecera\" style=\"border:0px\" width=100% height=\"50\" /></td>";
            TableHTML += "</tr>";
            TableHTML += "<tr>";
            TableHTML += "<td>";
            TableHTML += "<table width='600px' border='0' cellpadding='3' cellspacing='3'>";
            TableHTML += "<tr><th style=\"width:60%;\">Alerta</th><th style=\"width:20%;\">Área</th></tr>";
            TableHTML += "<tr>";
            TableHTML += "<td>";
            TableHTML += "&nbsp;";
            TableHTML += "<span style=\"font:'Frutiger 45 Light'; color:#9898CE\">La Alerta N° " + Alerta_id.ToString() + " \"" + _Titulo + "\" ha sido registrada</span>";
            TableHTML += "</td>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _Departamento_id + "</span></td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "</td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "<br />";
            TableHTML += "<a href=\"http://materiales/Incidentes/alerta/default.aspx?pkOrder=" + Alerta_id + "\">Ir a la Web de Incidentes</a>";

            return TableHTML;
        }
    }
}
