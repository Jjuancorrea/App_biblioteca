﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Negocio
{
    public class cls_conexion
    {
        public MySqlConnection conex;
        String cadenaconexion;
        public void fnt_conectar()
        {
            conex = new MySqlConnection();
            //************* CONEXION LOCAL ******************
            String servidor = "localhost";
            String bd = "dbs_biblioteca";
            String usuario = "root";
            String contraseña = "";
            String puerto = "3306";
            cadenaconexion = "server=" + servidor + ";port=" + puerto + ";user id=" + usuario + ";password=" + contraseña + ";database=" + bd + ";";
            try
            {
                conex.ConnectionString = cadenaconexion;
                conex.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("No connection", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fnt_Desconectar() { conex.Close(); }
    }

}
