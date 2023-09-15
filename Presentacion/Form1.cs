using System;
using System.Windows.Forms;
using Negocio;
namespace Presentacion
{
    public partial class Form1 : Form
    {
        Negocio.cls_registro objregistro = new Negocio.cls_registro();
        string[,] registros = new string[100,5];
        int int_fila = 0;
        Boolean sw = false;
        int pos = 0;
        public Form1()
        {
            InitializeComponent();
            btn_Actualizar.Enabled = false;
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            objregistro.setAutor(txt_autor.Text);
            objregistro.setReseñas(txt_reseña.Text);
            objregistro.setCodigo(txt_codigo.Text);
            objregistro.setPaginas(Convert.ToDouble(txt_paginas.Text));
            objregistro.setNombre(txt_nombre.Text);
            MessageBox.Show("Datos grabados con éxito", "Grabar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            objregistro.fnt_validar();
            if(objregistro.getValida() == 0)
            {
                MessageBox.Show("No ha grabado los datos","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                registros[int_fila, 0] = objregistro.getCodigo();
                registros[int_fila, 1] = objregistro.getNombre();
                registros[int_fila, 2] = objregistro.getAutor();
                registros[int_fila, 3] = Convert.ToString(objregistro.getPaginas());
                registros[int_fila, 4] = objregistro.getReseña();
                int_fila += 1;
                MessageBox.Show("Libro registrado con éxito", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_id_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                for (int i = 0; i< int_fila; i++)
                {
                    if (registros[i,0] == txt_codigo.Text)
                    {
                        sw = true;
                        pos = i;
                        break;
                    }
                }
                if (sw == false)
                {
                    MessageBox.Show("No se encontraron registros","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btn_Actualizar.Enabled = true;
                    txt_nombre.Text = registros[pos, 1];
                    txt_autor.Text = registros[pos, 2];
                    txt_paginas.Text = registros[pos, 3];
                    txt_reseña.Text = registros[pos, 4];
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_autor.Clear();
            txt_paginas.Clear();
            txt_codigo.Clear();
            txt_nombre.Clear();
            txt_reseña.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objregistro.setAutor(txt_autor.Text);
            objregistro.setReseñas(txt_reseña.Text);
            objregistro.setCodigo(txt_codigo.Text);
            objregistro.setPaginas(Convert.ToDouble(txt_paginas.Text));
            objregistro.setNombre(txt_nombre.Text);

            registros[pos, 1] = txt_nombre.Text;
            registros[pos, 2] = txt_autor.Text;
            registros[pos, 3] = txt_paginas.Text;
            registros[pos, 4] = txt_reseña.Text;
            MessageBox.Show("Datos actualizados con éxito", "Actualizar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            btn_Actualizar.Enabled = false;
        }

        private void btn_database_Click(object sender, EventArgs e)
        {
            objregistro.fnt_database(txt_codigo.Text, txt_nombre.Text, txt_autor.Text, txt_paginas.Text, txt_reseña.Text);
        }

        private void txt_codigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}