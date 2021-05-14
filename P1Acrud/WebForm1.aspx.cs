using P1Acrud.Clases.Archivos;
using P1Acrud.Clases.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P1Acrud
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CargarArchivoExterno()
        {
            string Fuente = ((@"C:\Users\alumno\Desktop\ArchivoCrudDB\crudDB.csv"));
            ClsArchivos ar = new ClsArchivos();
            //obtener todo el archivo linea por linea dentro de un arreglo simple--unidimensional
            string[] ArregloNotas = ar.LeerArchivo(Fuente);
            string sentencia_Mysql = "";
            int NumeroLinea = 0;

            ClsConecxion cn = new ClsConecxion();

            foreach (string linea in ArregloNotas)
            {
                //obteniendo datos
                string[] datos = linea.Split(';');
                if(NumeroLinea > 0)
                {
                    sentencia_Mysql += $"insert into bases values({datos[0]}, '{datos[1]} ', {datos[2]}, {datos[3]}, {datos[4]}, {datos[5]}, '{datos[6]}'\n);";
                }
                NumeroLinea++;
            }
            NumeroLinea = 0;
          
            cn.EjecutaMySQLDirecto(sentencia_Mysql);
        }
       


        protected void SubirInformacion_Click(object sender, EventArgs e)
        {
            CargarArchivoExterno();
        }

        protected void CargarMysql_Click(object sender, EventArgs e)
        {
            
        }
    }
}