﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeTexto
{
    public partial class Form1 : Form
    {
        private int numHijos;
        public Form1()
        {
            InitializeComponent();
            numHijos = 0;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Creamos y mostramos el nuevo formulario hijo
            numHijos++;
            FEditorHijo f2 = new FEditorHijo(numHijos);
            f2.MdiParent = this;
            f2.Show();

            //Activamos la ventana y añadimos un tsmi del formulario hiijo
            this.ventanaToolStripMenuItem.Enabled = true;
            ToolStripMenuItem fHijoIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem.DropDownItems.Insert(4+numHijos,fHijoIconsToolStripMenuItem);
            fHijoIconsToolStripMenuItem.Text = numHijos + " Documento " + numHijos;
            fHijoIconsToolStripMenuItem.Checked = true;
            fHijoIconsToolStripMenuItem.Click += (s, ev) => f2.Activate();

            //Si cerramos el formulario hijo lo eliminamos de la ventana.
            f2.FormClosed += (s, ev) => this.ventanaToolStripMenuItem.DropDownItems.Remove(fHijoIconsToolStripMenuItem);
            
            //Si desactivamos el formulario hijo lo desmarcamos en la ventana.
            f2.Deactivate += (s, ev) => fHijoIconsToolStripMenuItem.Checked = false;

            //Si activamos el formulario hijo lo marcamos en la ventana.
            f2.Activated += (s, ev) => fHijoIconsToolStripMenuItem.Checked = true;
            
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
        private void ventanaToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool existeAlguno = false;
            foreach (FEditorHijo fEditorHijo in this.MdiChildren)
            {
                if (fEditorHijo.IsHandleCreated)
                {
                    existeAlguno = true;
                }
            }
            if (!existeAlguno)
            {
                this.ventanaToolStripMenuItem.Enabled = false;
            }
        }
    }
}
