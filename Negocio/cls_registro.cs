using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Negocio
{
    public class cls_registro
    {
        cls_conexion objConectar= new cls_conexion();
        private string str_codigo;
        private string str_nombre;
        private string str_autor;
        private double flt_paginas;
        private string str_reseña;
        private int int_valida;

        public cls_registro()
        {
            this.flt_paginas = 0;
            this.str_autor = "";
            this.str_nombre = "";
            this.str_codigo = "";
            this.str_reseña = "";
        }
        public void fnt_validar()
        {
            if(str_codigo != "" || str_nombre != "" || str_autor != "" || flt_paginas > 0 || str_reseña !="")
            {
                this.int_valida = 1;
            }
            else
            {
                this.int_valida = 0;
            }
        }

        public void setAutor(string a) { this.str_autor = a; }
        public void setPaginas(double p) { this.flt_paginas = p; }
        public void setNombre(string n) { this.str_nombre = n; }
        public void setCodigo(string cod) { this.str_codigo = cod; }
        public void setReseñas(string r) { this.str_reseña = r; }
        public int getValida() { return this.int_valida; }
        //Métodos geters
        public string getNombre() { return this.str_nombre; }
        public string getCodigo() { return this.str_codigo; }
        public string getAutor() { return this.str_autor; }
        public double getPaginas() { return this.flt_paginas; }
        public string getReseña() { return this.str_reseña; }

        public void fnt_database(string cod, string nombre, string autor, string paginas, string reseña)
        {
            objConectar.fnt_conectar();
            string sql = "INSERT INTO tbl_libros (PkCodigo, Nombre, Autor, Fecha_publicacion, N_paginas, Reseña) " +
                         $"VALUES ('{cod}', '{nombre}', '{autor}', current_date(), {paginas}, '{reseña}')";
            MySqlCommand comando = new MySqlCommand(sql, objConectar.conex);

            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Registrado con éxito", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            objConectar.fnt_Desconectar();


        }
    }
}