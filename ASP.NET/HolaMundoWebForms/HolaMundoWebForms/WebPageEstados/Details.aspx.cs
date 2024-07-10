using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundoWebForms.WebPageEstados
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Estado> listaEstados = new List<Estado>
            {
                new Estado
                {
                    id = 1, nombre="Veracruz"
                },
                new Estado
                {
                    id = 2, nombre="Yucatan"
                },
                new Estado
                {
                    id = 3, nombre="Michoacan"
                },
                new Estado
                {
                    id = 4, nombre="Puebla"
                }
            };
            int id = Convert.ToInt16(Request.QueryString["id"]);

            Estado estado = listaEstados.Find(x => x.id == id);
            lbliddef.Text = estado.id.ToString();
            lblnombredef.Text = estado.nombre.ToString();
        }
    }
}