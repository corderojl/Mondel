using IncidentesADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IncidentesBL
{
    public class MailBL
    {
        MailADO _MailADO = new MailADO();

        public bool sndMailHeader(string strTo, string strHtmlBody, string strSubject)
        {
            return _MailADO.sndMailHeader(strTo, strHtmlBody, strSubject);
        }
        public string doBodyIncidente(int Incidente_id, string _Titulo, string _Departamento, string _Tip_empleado)
        {
            return _MailADO.doBodyIncidente(Incidente_id, _Titulo, _Departamento, _Tip_empleado);
        }
        public string doBodyAlerta(int Alerta_id, string _Descripcion, string _Departamento_id)
        {
            return _MailADO.doBodyAlerta(Alerta_id, _Descripcion, _Departamento_id);
        }
        public string doBodyPlan(int Incidente_id, string _Titulo, int _TipoPlan, string _Fecha, string _Plan, string _Asignado)
        {
            return _MailADO.doBodyPlan(Incidente_id, _Titulo, _TipoPlan, _Fecha, _Plan, _Asignado);
        }

        public string doBodySOP(string _areaID, string _area, string _codigoSop, string _procedimientoSop, string _fechaCadu, string _caduca)
        {
            string TableHTML;
            TableHTML = "<style type=\"text/css\">td,th {	color: #00F;text-align: center;}</style>";
            TableHTML = "<h3><span style=\"font:'Frutiger 45 Light'; color:#00F\">Contrato Vencido</span></h3>";
            TableHTML = "Se envía el estatus de los SOPs por áreas, por lo que se solicita realizar el procedimiento según corresponda.";
            TableHTML += "<br />";
            TableHTML += "NOTA: Revisar SOP QA 0500 (PROCEDIMIENTO DE DESARROLLO Y RENOVACIÓN DE UN PROCEDIMIENTO ESTÁNDAR DE OPERACIÓN (SOP).";
            TableHTML += "<table width='600px' border='1' bordercolor='#FFE5A6' cellpadding='3' cellspacing='3'>";
            TableHTML += "<tr><th style=\"width:10%;\">Codigo</th><th style=\"width:20%;\">PROCEDIMIENTO SOP</th><th style=\"width:20%;\">Departamento</th><th style=\"width:10%;\">FV</th><th style=\"width:10%;\">DIAS V.</th></tr>";
            TableHTML += "<tr>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _codigoSop + "</span></td>";
            TableHTML += "<td>";
            TableHTML += "&nbsp;";
            TableHTML += "<span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _procedimientoSop + "</span>";
            TableHTML += "</td>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _area + "</span></td>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _fechaCadu + "</span></td>";
            TableHTML += "<td align=\"center\"><span style=\"font:'Frutiger 45 Light'; color:#9898CE\">" + _caduca + "</span></td>";
            TableHTML += "</tr>";
            TableHTML += "</table>";
            TableHTML += "<br />";
            TableHTML += "<a href=\"http://materiales/sop/admin/reportesop.aspx?TIPOSOP_ID=0&area_id=" + _areaID + "\">Ir a la Web de SOP's</a>";

            return TableHTML;
        }

        public bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            int index = seMailAComprobar.IndexOf('@');
            String sFormato;
            sFormato = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";
            if (index > 0)
            {
                string[] dominio = seMailAComprobar.Split('@');

                if (dominio[1].ToString() == "mdlz.com")
                {
                    if (Regex.IsMatch(seMailAComprobar, sFormato))
                    {
                        if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
