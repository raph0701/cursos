﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Globalization;
using System.Threading;

namespace Cursos
{
    public partial class curso : System.Web.UI.Page
    {
        static string rutaImagenes ="~/fotos";
        protected void Page_Load(object sender, EventArgs e)
        {
          
            

            if (!Page.IsPostBack)
            {
                tbCampos.Visible = false;
                cargaCategorias();
                cargaGrid();
            }

        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            
            tbCampos.Visible = true;

            habilitaCampos(true);
            limpiaCampos();

            cargaIdCurso();
            Session["modo"] = "I";

        }

        protected void grvcurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            tbCampos.Visible = true;
            int fila = Convert.ToInt32(e.CommandArgument);
            GridViewRow registro = grvcursos.Rows[fila];

            txtcodigo.Text = registro.Cells[1].Text;
            txtcodigo.Enabled = false;
            txtnombre.Text = registro.Cells[2].Text;
             
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
            String cadena_conexion = param.ConnectionString;
            SqlConnection conexion = new SqlConnection(cadena_conexion);
            SqlCommand OrdenSqlSelect = new SqlCommand("SELECT  id from tb_categorias_cursos where descripcion = '"+registro.Cells[3].Text+"'");
            SqlDataAdapter da = new SqlDataAdapter(OrdenSqlSelect.CommandText, conexion);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlcategoria.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["id"].ToString()); ;
            txtprecio_ucsg.Text = registro.Cells[4].Text;
            txtprecio_publico.Text = registro.Cells[5].Text;
            
            txthorario.Text = registro.Cells[6].Text;
            txtdocente.Text = registro.Cells[7].Text;
            rblcertificacion.SelectedValue =  (registro.Cells[8].Text=="si")? "S" : "N" ;
            txtn_horas.Text = registro.Cells[9].Text;
            string fec = registro.Cells[10].Text;
            fec = fec.Remove(10);
            string[] split = fec.Split(new Char[] { '/'});
            fec= split[2]+"-"+split[1]+"-"+split[0];
            txtfecha_inicio.Text = (DateTime.ParseExact(fec, "yyyy-mm-dd", CultureInfo.InvariantCulture).ToString("yyyy-mm-dd"));
           
            OrdenSqlSelect = new SqlCommand("SELECT  foto, descripcion, objetivos, va_dirigido, prerequisito, aprendizaje, max_estudiante, min_estudiante, tema_1, tema_2, tema_3 from tb_curso where codigo = '"+registro.Cells[1].Text+"'");
             da = new SqlDataAdapter(OrdenSqlSelect.CommandText, conexion);
             ds = new DataSet();
            da.Fill(ds);
            txtfoto.Text = Convert.ToString(ds.Tables[0].Rows[0]["foto"].ToString());
            txtmax_estudiante.Text = ds.Tables[0].Rows[0]["max_estudiante"].ToString();
            txtmin_estudiante.Text = ds.Tables[0].Rows[0]["min_estudiante"].ToString();
            txtdescripcion.Text = ds.Tables[0].Rows[0]["descripcion"].ToString();
            txtobjetivos.Text = ds.Tables[0].Rows[0]["objetivos"].ToString();
            txtva_dirigido.Text = ds.Tables[0].Rows[0]["va_dirigido"].ToString();
            txtprerequisito.Text = ds.Tables[0].Rows[0]["prerequisito"].ToString();
            txtaprendizaje.Text = ds.Tables[0].Rows[0]["aprendizaje"].ToString();
            txttema_1.Text = ds.Tables[0].Rows[0]["tema_1"].ToString();
            txttema_2.Text = ds.Tables[0].Rows[0]["tema_2"].ToString();
            txttema_3.Text = ds.Tables[0].Rows[0]["tema_3"].ToString();
            
            Session["codigo"] = registro.Cells[1].Text;

            if (e.CommandName == "modificar")
            {
                tbCampos.Visible = true;
                Session["modo"] = "M";
            }
            else
            {
                habilitaCampos(false);
                btngrabar.Enabled = true;
                btnlimpiar.Enabled = true;
                tbCampos.Visible = true;

                Session["modo"] = "E";
                lblmensaje.Text = "Esta seguro que desea eliminar el registro";
            }


        }

        protected void btngrabar_Click(object sender, EventArgs e)
        {
            
            if (!txtfecha_inicio.Text.Equals("") || !string.IsNullOrWhiteSpace(txtnombre.Text) || !string.IsNullOrEmpty(txtnombre.Text) || !string.IsNullOrWhiteSpace(txtdescripcion.Text) || !string.IsNullOrEmpty(txtdescripcion.Text) || !string.IsNullOrWhiteSpace(txtdocente.Text) || !string.IsNullOrEmpty(txtdocente.Text) || !string.IsNullOrWhiteSpace(txtfecha_inicio.Text) || !string.IsNullOrEmpty(txtfecha_inicio.Text) || !string.IsNullOrWhiteSpace(txthorario.Text) || !string.IsNullOrEmpty(txthorario.Text) || !string.IsNullOrWhiteSpace(txtmax_estudiante.Text) || !string.IsNullOrEmpty(txtmax_estudiante.Text) || !string.IsNullOrWhiteSpace(txtmin_estudiante.Text) || !string.IsNullOrEmpty(txtmin_estudiante.Text) || !string.IsNullOrWhiteSpace(txtn_horas.Text) || !string.IsNullOrEmpty(txtn_horas.Text) || !string.IsNullOrWhiteSpace(txthorario.Text) || !string.IsNullOrEmpty(txthorario.Text) || !string.IsNullOrWhiteSpace(txtobjetivos.Text) || !string.IsNullOrEmpty(txtobjetivos.Text))
            {
                if (Convert.ToInt32(txtmin_estudiante.Text) > Convert.ToInt32(txtmax_estudiante.Text))
                {
                    lblmensaje.Text = "El mínimo de estudiantes no puede ser mayor al primero";
                    lblmensaje.Visible = true;
                }
                else
                {
                    lblmensaje.Text = "";
                    ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
                    String cadena_conexion = param.ConnectionString;

                    SqlConnection conexion = new SqlConnection(cadena_conexion);
                    string sql = "";

                    if (Session["modo"] == "I")
                    {
                        sql = "INSERT INTO tb_curso (nombre,descripcion,categoria,objetivos,va_dirigido,prerequisito,aprendizaje,precio_ucsg,precio_publico,max_estudiante,min_estudiante,horario,docente,certificacion,n_horas,fecha_inicio,tema_1,tema_2,tema_3, estado, foto) VALUES ('" + txtnombre.Text + "','" + txtdescripcion.Text + "','" + ddlcategoria.SelectedValue + "','" + txtobjetivos.Text + "','" + txtva_dirigido.Text + "','" + txtprerequisito.Text + "','" + txtaprendizaje.Text + "','" + txtprecio_ucsg.Text + "','" + txtprecio_publico.Text + "','" + txtmax_estudiante.Text + "','" + txtmin_estudiante.Text + "','" + txthorario.Text + "','" + txtdocente.Text + "','" + rblcertificacion.Text + "','" + txtn_horas.Text + "','" + txtfecha_inicio.Text + "','" + txttema_1.Text + "','" + txttema_2.Text + "','" + txttema_3.Text + "','A' , '" + txtfoto.Text + "')";

                    }
                    else
                    {
                        if (Session["modo"] == "M")
                        {
                            sql = "UPDATE tb_curso SET nombre = '" + txtnombre.Text + "', descripcion='" + txtdescripcion.Text + "', categoria='" + ddlcategoria.SelectedValue + "', objetivos='" + txtobjetivos.Text + "', va_dirigido='" + txtva_dirigido.Text + "', prerequisito='" + txtprerequisito.Text + "' , aprendizaje='" + txtaprendizaje.Text + "',precio_ucsg=" + txtprecio_ucsg.Text + ", precio_publico=" + txtprecio_publico.Text + " , max_estudiante='" + txtmax_estudiante.Text + "', min_estudiante='" + txtmin_estudiante.Text + "', horario='" + txthorario.Text + "', docente='" + txtdocente.Text + "', certificacion='" + rblcertificacion.Text + "', n_horas='" + txtn_horas.Text + "', fecha_inicio='" + txtfecha_inicio.Text + "', tema_1='" + txttema_1.Text + "', tema_2='" + txttema_2.Text + "', tema_3='" + txttema_3.Text + "', foto ='" + txtfoto.Text + "' WHERE codigo=" + Session["codigo"];
                        }
                        else
                        {
                            sql = "UPDATE tb_curso SET estado='I' WHERE codigo =" + Session["codigo"];

                        }

                    }

                    SqlCommand comando = new SqlCommand(sql, conexion);
                    conexion.Open();

                    int numero_registro = comando.ExecuteNonQuery();

                    if (numero_registro == 1)
                    {
                        lblmensaje.Text = "La transaccion se ejecuto correctamente";

                    }
                    else
                    {
                        lblmensaje.Text = "Ocurrio un error al ejecutar la transaccion";

                    }
                    lblmensaje.Visible = true;
                    cargaGrid();
                    limpiaCampos();
                    tbCampos.Visible = false;
                    conexion.Close();
                }
            }
            else
            {
                lblmensaje.Text = "No puede dejar campos vacios";
                lblmensaje.Visible = true;
             }
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            cargaGrid();

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (fufoto.HasFile)
            {
                //create the path to save the file to
                try
                {
                    string fileName = Path.Combine(Server.MapPath(rutaImagenes), fufoto.FileName);
                    txtfoto.Text = fileName;
                    //save the file to our local path
                    fufoto.SaveAs(fileName);
                    lblRFoto.Text = "Foto subida correctamente";
                    txtfoto.Text = rutaImagenes + "/"+ fufoto.FileName;
                }
                catch (IOException)
                {
                    lblRFoto.Text = "Hubo un problema al cargar foto, por favor intente luego";
                    txtfoto.Text = string.Empty;
                }
                finally
                {
                    btngrabar.Focus();
                }
            }
        }
        protected void cargaCategorias()
        {
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
            String cadena_conexion = param.ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena_conexion);
            SqlCommand OrdenSqlSelect = new SqlCommand("select id, descripcion from tb_categorias_cursos where estado = 'A'");
            SqlDataAdapter da = new SqlDataAdapter(OrdenSqlSelect.CommandText, conexion);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlcategoria.DataSource = ds;
            ddlcategoria.DataValueField = "id";
            ddlcategoria.DataTextField = "descripcion"; 
            ddlcategoria.DataBind();
        }

        protected void cargaIdCurso()
        {
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
            String cadena_conexion = param.ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena_conexion);
            SqlCommand OrdenSqlSelect = new SqlCommand("SELECT  ISNULL(MAX(CAST(codigo AS INT)),0) + 1 As 'nuevocodigo' From tb_curso");
            SqlDataAdapter da = new SqlDataAdapter(OrdenSqlSelect.CommandText, conexion);
            DataSet ds = new DataSet();
            da.Fill(ds);
           
            txtcodigo.Text = Convert.ToString(ds.Tables[0].Rows[0]["nuevocodigo"].ToString());
        }
        protected void limpiaCampos()
        {
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            ddlcategoria.SelectedIndex = 0;
            txtobjetivos.Text = "";
            txtva_dirigido.Text = "";
            txtprerequisito.Text = "";
            txtaprendizaje.Text = "";
            txtprecio_ucsg.Text = "";
            txtprecio_publico.Text = "";
            txtmax_estudiante.Text = "";
            txtmin_estudiante.Text = "";
            txthorario.Text = "";
            txtdocente.Text = "";
            rblcertificacion.SelectedIndex = 0;
            txtn_horas.Text = "";
            txtfecha_inicio.Text = "";

            txttema_1.Text = "";
            txttema_2.Text = "";
            txttema_3.Text = "";
        }
        protected void habilitaCampos(Boolean estado)
        {
            txtnombre.Enabled = estado;
            txtdescripcion.Enabled = estado;
            ddlcategoria.Enabled = estado;
            txtobjetivos.Enabled = estado;
            txtva_dirigido.Enabled = estado;
            txtprerequisito.Enabled = estado;
            txtaprendizaje.Enabled = estado;
            txtprecio_ucsg.Enabled = estado;
            txtprecio_publico.Enabled = estado;
            txtmax_estudiante.Enabled = estado;
            txtmin_estudiante.Enabled = estado;
            txthorario.Enabled = estado;
            txtdocente.Enabled = estado;
            rblcertificacion.Enabled = estado;
            txtn_horas.Enabled = estado;
            txtfecha_inicio.Enabled = estado;
            // lblfoto.Visible = false;
            txttema_1.Enabled = estado;
            txttema_2.Enabled = estado;
            txttema_3.Enabled = estado;
            fufoto.Enabled = estado;
        }

        protected void cargaGrid()
        {            
            try
            {
                lblbuscarerror.Text = "";
                ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
                string cadenaConexion = param.ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                string sql = "SELECT c.codigo, c.nombre, ca.descripcion as categoria, c.foto," +
                                    " c.precio_ucsg, c.precio_publico, c.horario, c.docente, c.fecha_inicio," +
                                    " case when (c.certificacion)='s' then 'Si' else 'No' end  as certificacion, c.n_horas " +
                               " FROM tb_curso c, tb_categorias_cursos ca WHERE c.estado='A' and c.categoria=ca.id ";
                int numval = 0;
                if (ddlbuscar.SelectedValue == "codigo")
                {
                    try
                    {
                        numval = Convert.ToInt32(txtbuscar.Text);
                        sql = sql+ "   AND c." + ddlbuscar.SelectedValue + " LIKE '%" + numval + "%' ";
                    }
                    catch { lblbuscarerror.Text = "Ingrese un valor numerico"; }


                }
                else if (ddlbuscar.SelectedValue == "categoria")
                {
                    sql = sql + " AND ca.descripcion LIKE '%" + txtbuscar.Text + "%'";
                }
                else
                { sql = sql + " AND c." + ddlbuscar.SelectedValue + " LIKE '%" + txtbuscar.Text + "%'"; }
                SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grvcursos.DataSource = ds;
                grvcursos.DataBind();
                if (grvcursos.Rows.Count == 0)
                    lblbuscarerror.Text = "No hay cursos con los datos de su busqueda '" + txtbuscar.Text + "'";
                txtbuscar.Text = "";
            }
            catch (Exception e)
            { string s= e.Message; }
        }

       
    }
}
       
        

       
  