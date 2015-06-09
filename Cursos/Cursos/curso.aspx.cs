using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cursos
{
    public partial class curso : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            lblcodigo.Visible = false;
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
            lbltema_1.Visible = false;
            txttema_1.Visible = false;
            lbltema_2.Visible = false;
            txttema_2.Visible = false;
            lbltema_3.Visible = false;
            txttema_3.Visible = false;
           grvcursos.DataBind
        }

       protected void btnnuevo_Click(object sender, EventArgs e)
       {

       }

       protected void btnbuscar_Click(object sender, EventArgs e)
       {

       }

     
        }

       
        
    }
