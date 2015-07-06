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

namespace Cursos
{
    public partial class curso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*lblcodigo.Visible = false;
            txtcodigo.Visible = false;
            lblnombre.Visible = false;
            txtnombre.Visible = false;
            lbldescripcion.Visible = false;
            txtdescripcion.Visible = false;
            lblcategoria.Visible = false;
            txtcategoria.Visible = false;
            lblobjetivos.Visible = false;
            txtobjetivos.Visible = false;
            lblva_dirigido.Visible = false;
            txtva_dirigido.Visible = false;
            lblprerrequisito.Visible = false;
            txtprerrequisito.Visible = false;
            lblaprendizaje.Visible = false;
            txtaprendizaje.Visible = false;
            lblprecio_ucsg.Visible = false;
            txtprecio_ucsg.Visible = false;
            lblprecio_publico.Visible = false;
            txtprecio_publico.Visible = false;
            lblmax_estudiante.Visible = false;
            txtmax_estudiante.Visible = false;
            lblmin_estudiante.Visible = false;
            txtmin_estudiante.Visible = false;
            lblhorario.Visible = false;
            txthorario.Visible = false;
            lbldocente.Visible = false;
            txtdocente.Visible = false;
            lblcertificacion.Visible = false;
            rblcertificacion.Visible = false;
            lbln_horas.Visible = false;
            txtn_horas.Visible = false;

            lblfecha_inicio.Visible = false;
            txtfecha_inicio.Visible = false;
            lblfoto.Visible = false;
            fufoto.Visible = false;
            lbltema_1.Visible = false;
            txttema_1.Visible = false;
            lbltema_2.Visible = false;
            txttema_2.Visible = false;
            lbltema_3.Visible = false;
            txttema_3.Visible = false;


            if (!Page.IsPostBack)
            {
                ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["tutoriaConnectionString"];
                String cadena_conexion = param.ConnectionString;

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                String sql = "SELECT * FROM tb_curso WHERE estado = 'A'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                grvcursos.DataSource = ds;
                grvcursos.DataBind();
            }

        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            /*txtcodigo.Visible = true;
            lblnombre.Visible = true;
            txtnombre.Visible = true;
            lbldescripcion.Visible = true;
            txtdescripcion.Visible = true;
            lblcategoria.Visible = true;
            txtcategoria.Visible = true;
            lblobjetivos.Visible = true;
            txtobjetivos.Visible = true;
            lblva_dirigido.Visible = true;
            txtva_dirigido.Visible = true;
            lblprerrequisito.Visible = true;
            txtprerrequisito.Visible = true;
            lblaprendizaje.Visible = true;
            txtaprendizaje.Visible = true;
            lblprecio_ucsg.Visible = true;
            txtprecio_ucsg.Visible = true;
            lblprecio_publico.Visible = true;
            txtprecio_publico.Visible = true;
            lblmax_estudiante.Visible = true;
            txtmax_estudiante.Visible = true;
            lblmin_estudiante.Visible = true;
            txtmin_estudiante.Visible = true;
            lblhorario.Visible = true;
            txthorario.Visible = true;
            lbldocente.Visible = true;
            txtdocente.Visible = true;
            lblcertificacion.Visible = true;
            rblcertificacion.Visible = true;
            lbln_horas.Visible = true;
            txtn_horas.Visible = true;

            lblfecha_inicio.Visible = true;
            txtfecha_inicio.Visible = true;
            // lblfoto.Visible = false;
            lbltema_1.Visible = true;
            txttema_1.Visible = true;
            lbltema_2.Visible = true;
            txttema_2.Visible = true;
            lbltema_3.Visible = true;
            txttema_3.Visible = true;
            lblfoto.Visible = true;
            fufoto.Visible = true;
            */
            tbCampos.Visible = true;

            txtcodigo.Enabled = false;
            txtnombre.Enabled = true;
            txtdescripcion.Enabled = true;
            txtcategoria.Enabled = true;
            txtobjetivos.Enabled = true;
            txtva_dirigido.Enabled = true;
            txtprerrequisito.Enabled = true;
            txtaprendizaje.Enabled = true;
            txtprecio_ucsg.Enabled = true;
            txtprecio_publico.Enabled = true;
            txtmax_estudiante.Enabled = true;
            txtmin_estudiante.Enabled = true;
            txthorario.Enabled = true;
            txtdocente.Enabled = true;
            rblcertificacion.Enabled = true;
            txtn_horas.Enabled = true;
            txtfecha_inicio.Enabled = true;
            // lblfoto.Visible = false;
            txttema_1.Enabled = true;
            txttema_2.Enabled = true;
            txttema_3.Enabled = true;
            fufoto.Enabled = true;

            txtcodigo.Text = "";
            txtcodigo.Enabled = false;
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtcategoria.Text = "";
            txtobjetivos.Text = "";
            txtva_dirigido.Text = "";
            txtprerrequisito.Text = "";
            txtaprendizaje.Text = "";
            txtprecio_ucsg.Text = "";
            txtprecio_publico.Text = "";
            txtmax_estudiante.Text = "";
            txtmin_estudiante.Text = "";
            txthorario.Text = "";
            txtdocente.Text = "";
            rblcertificacion.Text = "";
            txtn_horas.Text = "";
            txtfecha_inicio.Text = "";
            lblfoto.Visible = false;
            txttema_1.Text = "";
            txttema_2.Text = "";
            txttema_3.Text = "";


            Session["modo"] = "I";

        }

        protected void grvcurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            txtcodigo.Visible = true;
            lblnombre.Visible = true;
            txtnombre.Visible = true;
            lbldescripcion.Visible = true;
            txtdescripcion.Visible = true;
            lblcategoria.Visible = true;
            txtcategoria.Visible = true;
            lblobjetivos.Visible = true;
            txtobjetivos.Visible = true;
            lblva_dirigido.Visible = true;
            txtva_dirigido.Visible = true;
            lblprerrequisito.Visible = true;
            txtprerrequisito.Visible = true;
            lblaprendizaje.Visible = true;
            txtaprendizaje.Visible = true;
            lblprecio_ucsg.Visible = true;
            txtprecio_ucsg.Visible = true;
            lblprecio_publico.Visible = true;
            txtprecio_publico.Visible = true;
            lblmax_estudiante.Visible = true;
            txtmax_estudiante.Visible = true;
            lblmin_estudiante.Visible = true;
            txtmin_estudiante.Visible = true;
            lblhorario.Visible = true;
            txthorario.Visible = true;
            lbldocente.Visible = true;
            txtdocente.Visible = true;
            lblcertificacion.Visible = true;
            rblcertificacion.Visible = true;
            lbln_horas.Visible = true;
            txtn_horas.Visible = true;

            lblfecha_inicio.Visible = true;
            txtfecha_inicio.Visible = true;
            // lblfoto.Visible = false;
            lbltema_1.Visible = true;
            txttema_1.Visible = true;
            lbltema_2.Visible = true;
            txttema_2.Visible = true;
            txttema_3.Visible = true;
            fufoto.Visible = true;

            int fila = Convert.ToInt32(e.CommandArgument);
            GridViewRow registro = grvcursos.Rows[fila];

            txtcodigo.Text = registro.Cells[1].Text;
            txtcodigo.Enabled = false;
            txtnombre.Text = registro.Cells[2].Text;
            txtdescripcion.Text = registro.Cells[3].Text;
            txtcategoria.Text = registro.Cells[4].Text;
            txtobjetivos.Text = registro.Cells[5].Text;
            txtva_dirigido.Text = registro.Cells[6].Text;
            txtprerrequisito.Text = registro.Cells[7].Text;
            txtaprendizaje.Text = registro.Cells[8].Text;
            txtprecio_ucsg.Text = registro.Cells[9].Text;
            txtprecio_publico.Text = registro.Cells[10].Text;
            txtmax_estudiante.Text = registro.Cells[11].Text;
            txtmin_estudiante.Text = registro.Cells[12].Text;
            txthorario.Text = registro.Cells[13].Text;
            txtdocente.Text = registro.Cells[14].Text;
            rblcertificacion.Text = registro.Cells[15].Text;
            txtn_horas.Text = registro.Cells[16].Text;
            txtfecha_inicio.Text = registro.Cells[17].Text;
            txttema_1.Text = registro.Cells[18].Text;
            txttema_2.Text = registro.Cells[19].Text;
            txttema_3.Text = registro.Cells[20].Text;
            // fufoto. = registro.Cells[21].Text;
            Session["codigo"] = registro.Cells[1].Text;

            if (e.CommandName == "modificar")
            {
                txtcodigo.Enabled = false;
                txtnombre.Enabled = false;
                txtdescripcion.Enabled = false;
                txtcategoria.Enabled = false;
                txtobjetivos.Enabled = false;
                txtva_dirigido.Enabled = false;
                txtprerrequisito.Enabled = false;
                txtaprendizaje.Enabled = false;
                txtprecio_ucsg.Enabled = false;
                txtprecio_publico.Enabled = false;
                txtmax_estudiante.Enabled = false;
                txtmin_estudiante.Enabled = false;
                txthorario.Enabled = false;
                txtdocente.Enabled = false;
                rblcertificacion.Enabled = false;
                txtn_horas.Enabled = false;
                txtfecha_inicio.Enabled = false;
                fufoto.Enabled = false;
                txttema_1.Enabled = false;
                txttema_2.Enabled = false;
                txttema_3.Enabled = false;
                // lblmensa.Text = "";
                btngrabar.Enabled = true;
                btnlimpiar.Enabled = true;

                Session["modo"] = "M";
            }
            else
            {
                txtcodigo.Enabled = true;
                txtnombre.Enabled = true;
                txtdescripcion.Enabled = true;
                txtcategoria.Enabled = true;
                txtobjetivos.Enabled = true;
                txtva_dirigido.Enabled = true;
                txtprerrequisito.Enabled = true;
                txtaprendizaje.Enabled = true;
                txtprecio_ucsg.Enabled = true;
                txtprecio_publico.Enabled = true;
                txtmax_estudiante.Enabled = true;
                txtmin_estudiante.Enabled = true;
                txthorario.Enabled = true;
                txtdocente.Enabled = true;
                rblcertificacion.Enabled = true;
                txtn_horas.Enabled = true;
                txtfecha_inicio.Enabled = true;
                fufoto.Enabled = true;
                txttema_1.Enabled = true;
                txttema_2.Enabled = true;
                txttema_3.Enabled = true;
                // lblmensa.Text = "";
                btngrabar.Enabled = true;
                btnlimpiar.Enabled = true;


                Session["modo"] = "E";
                lblmensaje.Text = "Esta seguro que desea eliminar el registro";
            }


        }

        protected void btngrabar_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = "";
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["ApplicationServices"];
            String cadena_conexion = param.ConnectionString;

            SqlConnection conexion = new SqlConnection(cadena_conexion);
            string sql = "";

            if (Session["modo"] == "I")
            {
                sql = "INSERT INTO evento (nombre,descripcion,categoria,objetivos,va_dirigido,prerrequisitos,aprendizaje,precio_ucsg,precio_publico,max_estudiante,min_estudiante,horario,docente,certificacion,n_horas,fecha_inicio,tema_1,tema_2,tema3) VALUES ('" + txtnombre.Text + "','" + txtdescripcion.Text + "','" + txtcategoria.Text + "','" + txtobjetivos.Text + "','" + txtva_dirigido.Text + "','" + txtprerrequisito.Text + "','" + txtaprendizaje.Text + "'," + txtprecio_ucsg.Text + "','" + txtprecio_publico.Text + "','" + txtmax_estudiante.Text + "','" + txtmin_estudiante.Text + "','" + txthorario.Text + "','" + txtdocente.Text + "','" + rblcertificacion.Text + "','" + txtn_horas.Text + "','" + txtfecha_inicio.Text + "','" + txttema_1.Text + "','" + txttema_2.Text + "','" + txttema_3.Text + "','A' )";

            }
            else
            {
                if (Session["modo"] == "M")
                {
                    sql = "UPDATE evento SET nombre = '" + txtnombre.Text + "', descripcion='" + txtdescripcion.Text + "', categoria='" + txtcategoria.Text + "', objetivos='" + txtobjetivos.Text + "', va_dirigido='" + txtva_dirigido.Text + "', prerrequisitos='" + txtprerrequisito + "' , aprendizaje='" + txtaprendizaje.Text + "',precio_ucsg='" + txtprecio_ucsg + "', precio_publico='" + txtprecio_publico + "' , max_estudiante='" + txtmax_estudiante.Text + "', min_estudiante='" + txtmin_estudiante.Text + "', horario='" + txthorario.Text + "', docente='" + txtdocente.Text + "', certificacion='" + rblcertificacion.Text + "', n_horas='" + txtn_horas.Text + "', fecha_inicio='" + txtfecha_inicio + "', tema_1='" + txttema_1 + "', tema_2='" + txttema_2 + "', tema_3='" + txttema_3 + "' WHERE codigo" + Session["codigo"];
                }
                else
                {
                    sql = "UPDATE evento SET estado='I' WHERE codigo =" + Session["codigo"];

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

            conexion.Close();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            string Sql = "SELECT codigo, nombre, categoria, FROM tb_curso WHERE estado='A' AND " + ddlbuscar.SelectedValue + " LIKE '%" + txtbuscar.Text + "%'";

            lblbuscarerror.Text = "";
            ConnectionStringSettings param = ConfigurationManager.ConnectionStrings["applicationservices"];
            string cadenaConexion = param.ConnectionString;
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql;
            int numval = 0;
            if (ddlbuscar.SelectedValue == "codigo")
            {
                try
                {
                    numval = Convert.ToInt32(txtbuscar.Text);
                }
                catch { lblbuscarerror.Text = "Ingrese un valor numerico"; }

                sql = " SELECT * from tb_curso where estado='A' AND " + ddlbuscar.SelectedValue + " LIKE '%" + numval + "%'";
                ;
            }
            else
            {
                sql = " SELECT * from tb_curso where estado='A' AND " + ddlbuscar.SelectedValue + " LIKE '%" + txtbuscar.Text + "%'";
                ;

            }
            txtbuscar.Text = "";
            SqlDataAdapter da = new SqlDataAdapter(sql, conexion);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grvcursos.DataSource = ds;
            grvcursos.DataBind();

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (fufoto.HasFile)
            {
                //create the path to save the file to
                try
                {
                    string fileName = Path.Combine(Server.MapPath("~/fotos"), fufoto.FileName);
                    txtfoto.Text = fileName;
                    //save the file to our local path
                    fufoto.SaveAs(fileName);
                    lblRFoto.Text = "Foto subida correctamente";
                }
                catch (IOException )
                { 
                    lblRFoto.Text = "Hubo un problema al cargar foto, por favor intente luego";
                    txtfoto.Text = string.Empty;
                }
            }
        }



    }
}
       
        

       
  