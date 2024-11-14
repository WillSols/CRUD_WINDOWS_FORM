using CRUD_WINDOWS_FORM_TESTE.Forms;

namespace CRUD_WINDOWS_FORM_TESTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clientes c1 = new Clientes();
            c1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Produtos p1 = new Produtos();
            p1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sales s1 = new Sales();
            s1.ShowDialog();
        }
    }
}
