using System;
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
            txtdescripcion.Text = registro.Cells[3].Text;
             
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
            String cadena_conexion = param.ConnectionString;
            SqlConnection conexion = new SqlConnection(cadena_conexion);
            SqlCommand OrdenSqlSelect = new SqlCommand("SELECT  id from tb_categorias_cursos where descripcion = '"+registro.Cells[4].Text+"'");
            SqlDataAdapter da = new SqlDataAdapter(OrdenSqlSelect.CommandText, conexion);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlcategoria.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["id"].ToString()); ;

            txtobjetivos.Text = registro.Cells[5].Text;
            txtva_dirigido.Text = registro.Cells[6].Text;
            txtprerequisito.Text = registro.Cells[7].Text;
            txtaprendizaje.Text = registro.Cells[8].Text;
            txtprecio_ucsg.Text = registro.Cells[9].Text;
            txtprecio_publico.Text = registro.Cells[10].Text;
            txtmax_estudiante.Text = registro.Cells[11].Text;
            txtmin_estudiante.Text = registro.Cells[12].Text;
            txthorario.Text = registro.Cells[13].Text;
            txtdocente.Text = registro.Cells[14].Text;
            rblcertificacion.SelectedValue = registro.Cells[15].Text;
            txtn_horas.Text = registro.Cells[16].Text;
            txtfecha_inicio.Text = registro.Cells[17].Text;

            txttema_1.Text = registro.Cells[18].Text;
            txttema_2.Text = registro.Cells[19].Text;
            txttema_3.Text = registro.Cells[20].Text;
            // fufoto. = registro.Cells[21].Text;
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
            lblmensaje.Text = "";
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
            String cadena_conexion = param.ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena_conexion);
            string sql = "";

            if (Session["modo"] == "I")
            {
                sql = "INSERT INTO tb_curso (nombre,descripcion,categoria,objetivos,va_dirigido,prerequisito,aprendizaje,precio_ucsg,precio_publico,max_estudiante,min_estudiante,horario,docente,certificacion,n_horas,fecha_inicio,tema_1,tema_2,tema_3, estado, foto) VALUES ('" + txtnombre.Text + "','" + txtdescripcion.Text + "','" + ddlcategoria.SelectedValue + "','" + txtobjetivos.Text + "','" + txtva_dirigido.Text + "','" + txtprerequisito.Text + "','" + txtaprendizaje.Text + "','" + txtprecio_ucsg.Text + "','" + txtprecio_publico.Text + "','" + txtmax_estudiante.Text + "','" + txtmin_estudiante.Text + "','" + txthorario.Text + "','" + txtdocente.Text + "','" + rblcertificacion.Text + "','" + txtn_horas.Text + "','" + txtfecha_inicio.Text + "','" + txttema_1.Text + "','" + txttema_2.Text + "','" + txttema_3.Text + "','A' , '" + rutaImagenes + "/" + txtfoto.Text + "')";
                
            }
            else
            {
                if (Session["modo"] == "M")
                {
                    sql = "UPDATE tb_curso SET nombre = '" + txtnombre.Text + "', descripcion='" + txtdescripcion.Text + "', categoria='" + ddlcategoria.SelectedValue + "', objetivos='" + txtobjetivos.Text + "', va_dirigido='" + txtva_dirigido.Text + "', prerequisito='" + txtprerequisito.Text + "' , aprendizaje='" + txtaprendizaje.Text + "',precio_ucsg=" + txtprecio_ucsg.Text + ", precio_publico=" + txtprecio_publico.Text + " , max_estudiante='" + txtmax_estudiante.Text + "', min_estudiante='" + txtmin_estudiante.Text + "', horario='" + txthorario.Text + "', docente='" + txtdocente.Text + "', certificacion='" + rblcertificacion.Text + "', n_horas='" + txtn_horas.Text + "', fecha_inicio='" + txtfecha_inicio.Text + "', tema_1='" + txttema_1.Text + "', tema_2='" + txttema_2.Text + "', tema_3='" + txttema_3.Text + "', foto ='"+rutaImagenes+"/"+txtfoto.Text+"' WHERE codigo=" + Session["codigo"];
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
            conexion.Close();
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
                    txtfoto.Text = fufoto.FileName;
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
            
            string Sql = "SELECT c.codigo, c.nombre, c.descripcion, ca.descripcion as categoria, c.objetivos, c.va_dirigido, c.prerequisito, " +
                                "c.aprendizaje, c.precio_ucsg, c.precio_publico, c.max_estudiante, c.min_estudiante, c.horario, c.docente, " +
                                "c.certificacion, c.n_horas, c.fecha_inicio, c.foto, c.tema_1, c.tema_2, c.tema_3, c.estado " +
                         "FROM tb_curso WHERE c.estado='A' AND c." + ddlbuscar.SelectedValue + " LIKE '%" + txtbuscar.Text + "%' and c.categoria=ca.id";
            try
            {
                lblbuscarerror.Text = "";
                ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
                string cadenaConexion = param.ConnectionString;
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                string sql = "SELECT c.codigo, c.nombre, c.descripcion, ca.descripcion as categoria, c.objetivos, c.va_dirigido, c.prerequisito, " +
                                    "c.aprendizaje, c.precio_ucsg, c.precio_publico, c.max_estudiante, c.min_estudiante, c.horario, c.docente, " +
                                    "c.certificacion, c.n_horas, c.fecha_inicio, c.foto, c.tema_1, c.tema_2, c.tema_3, c.estado " +
                                    " from tb_curso c, tb_categorias_cursos ca where c.estado='A' and c.categoria=ca.id ";
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
            catch (Exception)
            { }
        }

       
    }
}
       
        

       
  