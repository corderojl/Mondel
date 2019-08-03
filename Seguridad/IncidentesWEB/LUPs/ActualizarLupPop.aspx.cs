using IncidentesBE;
using IncidentesBL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Text.RegularExpressions;

namespace IncidentesWEB.LUPs
{
    public partial class ActualizarLupPop : System.Web.UI.Page
    {
        LUP_LupBL _LUP_LupBL = new LUP_LupBL();
        TB_PilarBL _TB_PilarBL = new TB_PilarBL();
        Fnc_FuncionariosBL _Fnc_FuncionariosBL = new Fnc_FuncionariosBL();
        TB_DepartamentoBL _TB_DepartamentoBL = new TB_DepartamentoBL();
        TB_ResponsablePilarBL _TB_ResponsablePilarBL = new TB_ResponsablePilarBL();
        LUP_CategoriaBL _LUP_CategoriaBL = new LUP_CategoriaBL();
        TB_GuardiaBL _TB_GuardiaBL = new TB_GuardiaBL();
        private List<TB_GuardiaBE> lbeFiltroGuardia;
        private List<LUP_CategoriaBE> lbeFiltroCategoria;
        List<TB_DepartamentoBE> lTTB_DepartamentoBE;
        List<TB_GuardiaBE> lTTB_GuardiaBE;
        List<LUP_CategoriaBE> lTLUP_CategoriaBE;
        List<Fnc_FuncionariosBE> lTFnc_FuncionariosBE;
        LUP_LupBE _LUP_LupBE = new LUP_LupBE();
        TB_ResponsableBL _TB_ResponsableBL = null;
        string fecha_actual;
        DateTime Hoy;
        protected void Page_Load(object sender, EventArgs e)
        {
            Hoy = DateTime.Today;
            if (!this.IsPostBack)
            {
                int Lup_id = Convert.ToInt32(Request.QueryString["Lup_id"]);
                lblId.Text = Lup_id.ToString();
                _LUP_LupBE = _LUP_LupBL.TraerLUP_LupById(Lup_id);
                Hoy = DateTime.Today;
                fecha_actual = Hoy.AddYears(1).ToString("dd/MM/yyyy");
                txtFecha.Text = fecha_actual;
                LlenarComboDepartamento();
                lTTB_GuardiaBE = _TB_GuardiaBL.ListarTB_GuardiaO_Act();
                Session["Guardias"] = lTTB_GuardiaBE;
                LlenarComboGuardia();
                LlenarComboPilar();
                LlenarComboOriginador();

                ddlDepartamento.SelectedValue = _LUP_LupBE.Departamento_id.ToString();
                ddlGuardia.SelectedValue = _LUP_LupBE.Guardia_id.ToString();
                ddlDuenio.SelectedValue = _LUP_LupBE.Encargado.ToString();
                ddlPilar.SelectedValue = _LUP_LupBE.Pilar_id.ToString();
                ddlCategoria.SelectedValue = _LUP_LupBE.Categoria_id.ToString();
                txtTitulo.Text = _LUP_LupBE.Lup_Titulo;
                txtDescripcion.Text = _LUP_LupBE.Lup_desc;
                txtFecha.Text = _LUP_LupBE.fecha_ven.ToShortDateString();
                mostrarArchivo(_LUP_LupBE.adjunto_lup);
                TraerResponsable(short.Parse(ddlDepartamento.SelectedValue));
                LlenarComboAprobador(short.Parse(ddlPilar.SelectedValue));
                rblEstado.SelectedValue = _LUP_LupBE.Estado.ToString();
                lTLUP_CategoriaBE = _LUP_CategoriaBL.ListarLUP_CategoriaO_Act();
                Session["Categoria"] = lTLUP_CategoriaBE;
                LlenarComboCategoria();
                generarTablaAprobadores(Lup_id);
            }
        }

        private void generarTablaAprobadores(int Lup_id)
        {
            LUP_AprobadorBL _LUP_AprobadorBL = new LUP_AprobadorBL();
            DataTable Resultados = _LUP_AprobadorBL.ListarLUP_AprobadorByLup(Lup_id);
            rptAprobador.DataSource = Resultados;
            rptAprobador.DataBind();
        }



        private void mostrarArchivo(string archivo)
        {
            if (archivo != null)
            {
                lblArchivo.Text = archivo;
                string ext = Path.GetExtension(archivo);
                string img = "";
                if (ext != "")
                    switch (ext)
                    {
                        case ".pdf": img = "pdf.jpg"; break;
                        case ".doc": img = "word.jpg"; break;
                        case ".docx": img = "word.jpg"; break;
                        case ".docm": img = "word.jpg"; break;
                        case ".xls": img = "excel.jpg"; break;
                        case ".xlsx": img = "excel.jpg"; break;
                        case ".ppt": img = "power.jpg"; break;
                        case ".pptx": img = "power.jpg"; break;
                        case ".jpg": img = "imagen.jpg"; break;
                        case ".png": img = "imagen.jpg"; break;
                        case ".bmp": img = "imagen.jpg"; break;
                        default: img = "archivo.jpg"; break;
                    }
                ltlArchivo.Text = "<a title=\"" + archivo + "\" href=\"Archivos/" + archivo + "\"><img src=\"images/" + img + "\" target=\"_blank\" alt=\"" + archivo + "\" width=\"20\" height=\"20\"/></a>";
            }
        }

        private bool buscarGuardias(TB_GuardiaBE obeGuardia)
        {
            bool exitoIdGuardia = true;
            if (!ddlDepartamento.SelectedValue.Equals("0")) exitoIdGuardia = (obeGuardia.Departamento_id.ToString().Equals(ddlDepartamento.SelectedValue));
            return (exitoIdGuardia);
        }
        private bool buscarCategorias(LUP_CategoriaBE obeCategoria)
        {
            bool exitoIdCategoria = true;
            if (!ddlPilar.SelectedValue.Equals("0")) exitoIdCategoria = (obeCategoria.Pilar_id.ToString().Equals(ddlPilar.SelectedValue));
            return (exitoIdCategoria);
        }
        private void LlenarComboGuardia()
        {
            lTTB_GuardiaBE = (List<TB_GuardiaBE>)Session["Guardias"];
            Predicate<TB_GuardiaBE> pred = new Predicate<TB_GuardiaBE>(buscarGuardias);
            lbeFiltroGuardia = lTTB_GuardiaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroGuardia;

            ddlGuardia.DataSource = lbeFiltroGuardia;
            ddlGuardia.DataValueField = "Guardia_id";
            ddlGuardia.DataTextField = "Guardia_desc";
            ddlGuardia.DataBind();
            ddlGuardia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboCategoria()
        {
            lTLUP_CategoriaBE = (List<LUP_CategoriaBE>)Session["Categoria"];
            Predicate<LUP_CategoriaBE> pred = new Predicate<LUP_CategoriaBE>(buscarCategorias);
            lbeFiltroCategoria = lTLUP_CategoriaBE.FindAll(pred);
            Session["Filtro"] = lbeFiltroCategoria;

            ddlCategoria.DataSource = lbeFiltroCategoria;
            ddlCategoria.DataValueField = "Categoria_id";
            ddlCategoria.DataTextField = "Categoria_desc";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Elija una Opcion..", "0"));
        }
        private void LlenarComboOriginador()
        {
            lTFnc_FuncionariosBE = _Fnc_FuncionariosBL.ListarFnc_FuncionariosO_Act();
            ddlDuenio.DataSource = lTFnc_FuncionariosBE;
            ddlDuenio.DataValueField = "Funcionario_id";
            ddlDuenio.DataTextField = "Funcionario_nome";
            ddlDuenio.DataBind();
            ddlDuenio.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Elija una Opción...", "0"));
        }
        private void LlenarComboAprobador(short Pilar_id)
        {
            ddlAprobador.DataSource = _TB_ResponsablePilarBL.ListarTB_ResponsablePilarByPilar(Pilar_id); ;
            ddlAprobador.DataValueField = "Funcionario_id";
            ddlAprobador.DataTextField = "Funcionario_nome";
            ddlAprobador.DataBind();
            ddlAprobador.Items.Insert(0, new System.Web.UI.WebControls.ListItem(((TB_ResponsableBE)Session["Responsable"]).Funcionario_nome, ((TB_ResponsableBE)Session["Responsable"]).Funcionario_id.ToString()));
        }
        private void LlenarComboPilar()
        {
            ddlPilar.DataSource = _TB_PilarBL.ListarTB_Pilar_Act();
            ddlPilar.DataValueField = "Pilar_id";
            ddlPilar.DataTextField = "Pilar_desc";
            ddlPilar.DataBind();
            ddlPilar.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Elija una Opción...", "0"));
        }

        private void LlenarComboDepartamento()
        {
            lTTB_DepartamentoBE = _TB_DepartamentoBL.ListarTB_Departamento_All("1");
            ddlDepartamento.DataSource = lTTB_DepartamentoBE;
            ddlDepartamento.DataValueField = "Departamento_id";
            ddlDepartamento.DataTextField = "Departamento_desc";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Elija una Opción...", "0"));
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string msj;
            msj = subirArchivo();
            switch (msj)
            {

                case "":
                    guardarLup(msj);
                    LlenarComboAprobador(short.Parse(ddlPilar.SelectedValue));
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
                    break;
                case "Error":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al subir archivo')", true);
                    break;
                case "Formato":
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Tipo de archivo no valido')", true);
                    break;
                default:
                    guardarLup(msj);
                    LlenarComboAprobador(short.Parse(ddlPilar.SelectedValue));
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
                    break;
            }
        }

        private void guardarLup(string msj)
        {
            LUP_LupBE _LUP_LupBE = new LUP_LupBE();
            _LUP_LupBE.Lup_id = Convert.ToInt32(Request.QueryString["Lup_id"]);
            _LUP_LupBE.Departamento_id = short.Parse(ddlDepartamento.SelectedValue);
            _LUP_LupBE.Guardia_id = short.Parse(ddlGuardia.SelectedValue);
            _LUP_LupBE.Pilar_id = short.Parse(ddlPilar.SelectedValue);
            _LUP_LupBE.Categoria_id = short.Parse(ddlCategoria.SelectedValue);
            _LUP_LupBE.Encargado = short.Parse(ddlDuenio.SelectedValue);
            _LUP_LupBE.fecha_ven = Convert.ToDateTime(txtFecha.Text);
            _LUP_LupBE.Lup_Titulo = txtTitulo.Text;
            _LUP_LupBE.Lup_desc = txtDescripcion.Text;
            _LUP_LupBE.Estado = short.Parse(rblEstado.SelectedValue);
            if (msj != "")
            {
                _LUP_LupBE.adjunto_lup = msj;
                _LUP_LupBE.adjunto_aprob = msj;
            }
            else { 
                _LUP_LupBE.adjunto_lup = lblArchivo.Text;
                _LUP_LupBE.adjunto_aprob = msj;
            }
            if (_LUP_LupBL.ActualizarLUP_Lup(_LUP_LupBE))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El registro se actualizó con exito')", true);
                if (_LUP_LupBE.Estado == 2)
                    PonerSello2("rptEvaColega.pdf");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se pudo actualizar, por favor contactar al admimistrador')", true);
            }
        }

        private void PonerSello(string _Archivo)
        {
            string path = @"C:\ProyMondelez\Seguridad\IncidentesWEB\LUPs\Archivos\" + _Archivo;
            PdfReader reader = new PdfReader(path);
            PdfReader.unethicalreading = true;
            FileStream fs = null;
            PdfStamper stamp = null;
            Document document = null;
            try
            {
                document = new Document();
                string outputPdf = String.Format(@"C:\ProyMondelez\Seguridad\IncidentesWEB\LUPs\Archivos\{0}.pdf",
                Guid.NewGuid().ToString());
                fs = new FileStream(outputPdf,
                          FileMode.CreateNew,
                          FileAccess.Write);
                stamp = new PdfStamper(reader, fs);
                BaseFont bf =
                  BaseFont.CreateFont(@"c:\windows\fonts\arial.ttf",
                              BaseFont.CP1252, true);
                PdfGState gs = new PdfGState();
                gs.FillOpacity = 0.35F;
                gs.StrokeOpacity = 0.35F;
                for (int nPag = 1; nPag <= reader.NumberOfPages; nPag++)
                {
                    Rectangle tamPagina = reader.GetPageSizeWithRotation(nPag);
                    PdfContentByte over = stamp.GetOverContent(nPag);
                    over.BeginText();
                    WriteTextToDocument(bf, tamPagina, over, gs, "APROBADO");
                    over.EndText();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                reader.Close();
                //if (stamp != null) stamp.Close();
                if (fs != null) fs.Close();
                if (document != null) document.Close();
            }
        }
        private void sello(string _Archivo)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream((@"C:\ProyMondelez\Seguridad\IncidentesWEB\LUPs\Archivos\" + _Archivo), FileMode.Create));

            doc.Open();

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("localización de la imagen");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_RIGHT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            // Insertamos la imagen en el documento
            doc.Add(imagen);

            // Cerramos el documento
            doc.Close();
        }
        private void PonerSello2(string _Archivo)
        {
            Document doc = new Document(PageSize.A4);

            try
            {

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream((@"C:\ProyMondelez\Seguridad\IncidentesWEB\LUPs\Archivos\" + _Archivo), FileMode.Create));
                doc.Open();
                //doc.Add(this.AddParagraphHeader("Getting ready"));
                //doc.Add(this.AddParagragh(@"At the top level, there is a Figure instance containing all that we see and some more (that we don't see). The figure contains, among other things, instances of the Axes class as a Figure.axes field. The Axes instances contain almost everything we care about: all the lines, points, ticks, and labels. So, when we call plot(), we are adding a line (matplotlib.lines.Line2D) to the Axes.lines list. If we plot a histogram (hist()), we are adding rectangles to the list of Axes.patches ('patches' is the term inherited from MATLAB®, and it represents the 'patch of color' concept)."));
                //doc.Add(this.AddParagragh(@"An instance of Axes also holds references to the XAxis and YAxis instances, which in turn refer to the x axis and y axis, respectively. The XAxis and YAxis instances manage the drawing of the axis, labels, ticks, tick labels, locators, and formatters. We can reference these through Axes.xaxis and Axes.yaxis, respectively. We don't have to go all the way down to XAxis or YAxis instances to get to the labels as matplotlib gives us a helper method (practically a shortcut) that enables iterations via these labels: matplotlib.pyplot.xlabel() and matplotlib.pyplot.ylabel()."));

                //water mark
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, false);
                BaseColor bc = new BaseColor(0, 0, 0, 65);
                iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 145.5F, iTextSharp.text.Font.ITALIC, bc);

                // Dim wfont = New Font(BaseFont.TIMES_ROMAN, 1.0F, BaseFont.COURIER, BaseColor.LIGHT_GRAY)
                ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER, new Phrase("Confidential", times), 245.5F, 480.0F, -55);

                //End water mark

                doc.Close();
                System.Diagnostics.Process.Start(Environment.GetFolderPath(
                         Environment.SpecialFolder.Desktop) + "/WaterMark1.pdf");
            }
            catch (Exception ae)
            {
                doc.Close();
            }
        }
        public Paragraph AddParagragh(string ParagraphText)
        {
            Paragraph p = new Paragraph();
            p.SpacingBefore = 10f;
            p.FirstLineIndent = 10f;
            p.SpacingAfter = 15f;

            iTextSharp.text.Font f = new iTextSharp.text.Font();
            p.Font.SetFamily("Courier");
            p.Alignment = Element.ALIGN_JUSTIFIED;
            p.Font.Size = 13f;
            p.Font.SetColor(0, 0, 0);
            p.Add(ParagraphText);
            return p;
        }
        public Chunk AddParagraphHeader(string headingText)
        {
            Chunk ch = new Chunk(headingText);
            ch.Font.Size = 16f;
            ch.Font.SetStyle("bold");
            ch.Font.SetColor(0, 0, 0);
            return ch;
        }
        private static void WriteTextToDocument(BaseFont bf, Rectangle tamPagina, PdfContentByte over, PdfGState gs, string texto)
        {
            over.SetGState(gs);
            over.SetRGBColorFill(220, 220, 220);
            over.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_STROKE);
            over.SetFontAndSize(bf, 46);
            Single anchoDiag = (Single)Math.Sqrt(Math.Pow((tamPagina.Height - 120), 2)
                + Math.Pow((tamPagina.Width - 60), 2));
            Single porc = (Single)100 * (anchoDiag / bf.GetWidthPoint(texto, 46));
            over.SetHorizontalScaling(porc);
            double angPage = (-1)
            * Math.Atan((tamPagina.Height - 60) / (tamPagina.Width - 60));
            over.SetTextMatrix((float)Math.Cos(angPage), (float)Math.Sin(angPage),
                       (float)((-1F) * Math.Sin(angPage)),
                       (float)Math.Cos(angPage),
                       30F,
                       (float)tamPagina.Height - 60);
            over.ShowText(texto);
        }
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboGuardia();
            TraerResponsable(Convert.ToInt16(ddlDepartamento.SelectedValue));
        }
        private void TraerResponsable(Int16 _Departamento_id)
        {
            _TB_ResponsableBL = new TB_ResponsableBL();
            Session["Responsable"] = _TB_ResponsableBL.TraerTB_ResponsableByDepartamento(_Departamento_id);
            lblResponsable.Text = ((TB_ResponsableBE)Session["Responsable"]).Funcionario_nome;
        }
        private string subirArchivo()
        {
            Boolean fileOK = false;
            String path = Server.MapPath("Archivos/");
            string mensaje;
            if (fupLup.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(fupLup.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf", ".doc", ".docx", ".docm", ".xls", ".xlsx", ".ppt", ".pptx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
                if (fileOK)
                {
                    try
                    {
                        fupLup.PostedFile.SaveAs(path
                            + fupLup.FileName);
                        return mensaje = fupLup.FileName;

                    }
                    catch (Exception ex)
                    {
                        return mensaje = "Error";
                    }
                }
                else
                {
                    return mensaje = "Formato";
                }
            }
            else
                return "";

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            LUP_AprobadorBL _LUP_AprobadorBL = new LUP_AprobadorBL();
            if (_LUP_AprobadorBL.InsertarLUP_Aprobador(int.Parse(lblId.Text), short.Parse(ddlAprobador.SelectedValue)))
            {
                generarTablaAprobadores(int.Parse(lblId.Text));
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Error al agregar nuevo aprobador, verifique si ya existe');", true);
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error al agregar nuevo aprobador, verifique si ya existe')", true);
        }

        protected void ddlPilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarComboCategoria();
            LlenarComboAprobador(short.Parse(ddlPilar.SelectedValue));
        }

        protected void ibnActualizar1_Click(object sender, ImageClickEventArgs e)
        {
            LUP_AprobadorBE _LUP_AprobadorBE = new LUP_AprobadorBE();
            LUP_AprobadorBL _LUP_AprobadorBL = new LUP_AprobadorBL();
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            short _Registro_id = short.Parse(((Label)fila.Controls[1]).Text);
            string _Var = ((Label)fila.Controls[5]).Text;

            _LUP_AprobadorBE.Lup_id = Convert.ToInt32(Request.QueryString["Lup_id"]);
            _LUP_AprobadorBE.Funcionario_Id = _Registro_id;
            if (_Var == "Pendiente")
                _LUP_AprobadorBE.Estado = 2;
            else
                _LUP_AprobadorBE.Estado = 1;

            if (!_LUP_AprobadorBL.ProcesarLUP_Aprobador(_LUP_AprobadorBE))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo actualizar!');", true);
            }
            generarTablaAprobadores(int.Parse(Request.QueryString["Lup_id"]));
        }

        protected void rptAprobador_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.AlternatingItem || e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item)
            {
                short IdSes = ((Fnc_FuncionariosBE)Session["Fnc_Funcionarios"]).Funcionario_Id;
                ImageButton ib = (ImageButton)e.Item.FindControl("ibnActualizar");
                TB_AccesosBE _TB_AccesosBE = new TB_AccesosBE();
                TB_AccesosBL _TB_AccesosBL = new TB_AccesosBL();
                _TB_AccesosBE = _TB_AccesosBL.TraerTB_Accesos(IdSes, 8);
                RepeaterItem fila = (RepeaterItem)ib.Parent;
                if (ib != null)
                {

                    short _Registro_id = short.Parse(((Label)fila.Controls[1]).Text);
                    if (_Registro_id == IdSes)
                        ib.Enabled = true;
                    else
                    {
                        if (_TB_AccesosBE.Permiso == 1)
                            ib.Enabled = true;
                        else
                            ib.Enabled = false;
                    }
                }
                ImageButton ibe = (ImageButton)e.Item.FindControl("ibnEliminar");
                if (ib != null)
                {
                    string exito = "";
                    if (Request.QueryString["reggistro"] != null)
                        exito = (Request.QueryString["reggistro"]).ToString();
                    if (exito == "exito")
                    {
                        string lblAprobador = ((Label)fila.Controls[3]).Text;
                        if (lblResponsable.Text != lblAprobador)
                            ibe.Visible = true;
                    }
                    else
                        if (_TB_AccesosBE.Permiso == 1)
                            ibe.Visible = true;
                }
            }
        }

        protected void ibnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            LUP_AprobadorBL _LUP_AprobadorBL = new LUP_AprobadorBL();
            ImageButton ibn = (ImageButton)sender;
            RepeaterItem fila = (RepeaterItem)ibn.Parent;
            short _Registro_id = short.Parse(((Label)fila.Controls[1]).Text);
            int Lup_id = Convert.ToInt32(Request.QueryString["Lup_id"]);
            short Funcionario_Id = _Registro_id;

            if (!_LUP_AprobadorBL.EliminarLUP_Aprobador(Lup_id, Funcionario_Id))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('No se pudo eliminar aprobador!');", true);
            }
            generarTablaAprobadores(int.Parse(Request.QueryString["Lup_id"]));
        }

        protected void rblEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            short Lup_id = short.Parse(lblId.Text);
            short aprob = _LUP_LupBL.ContarLUP_LupAprobacion(Lup_id);
            if (aprob > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('Para cambiar de estado no debe tener aprobaciones pendientes');", true);
                rblEstado.SelectedValue = "1";
            }
            else
            {

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int Lup_id = Convert.ToInt32(Request.QueryString["Lup_id"]);
            bool vexito = _LUP_LupBL.EliminarLUP_Lup(Lup_id);
            if (vexito)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "jAlert", "jAlert('El registro se eliminó con exito');Salir();", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "ActualizoExito();", true);
            }
        }

    }
}