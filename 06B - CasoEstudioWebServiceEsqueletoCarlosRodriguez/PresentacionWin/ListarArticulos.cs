﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentacionWin.Windows;
namespace PresentacionWin
{
    public partial class ListarArticulos : Form
    {
        public ListarArticulos()
        {
            InitializeComponent();
        }

        private void ListarArticulos_Load(object sender, EventArgs e)
        {
          
                ServicioArticulos Larticulos = new ServicioArticulos();
                DGVListado.DataSource = Larticulos.Listar().ToList();
           
          
        }
    }
}
