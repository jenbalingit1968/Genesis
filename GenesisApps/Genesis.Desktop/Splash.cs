using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genesis.Core.Model;

namespace Genesis.Desktop
{
    public partial class Splash : Form
    {

        public Splash()
        {
            InitializeComponent();
        }

        private void btnLoadBooks_Click(object sender, EventArgs e)
        {

            var get = new Core.Logic.Books().ReadCahedBooks.OrderBy(o => o.Name).ToList();

            new Thread(new ThreadStart(() =>
            {
                get.ForEach(f =>
                {
                    this.Invoke(new MethodInvoker(delegate {
                        this.txtBookTitles.Text = f.Name;
                    }));
                });
            })).Start();


            Thread.Sleep(2000);

        }

        private async void Splash_Load(object sender, EventArgs e)
        {
            await new Core.Logic.Books().CachedBookToTextFile();
        }
    }
}
