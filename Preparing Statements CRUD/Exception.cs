using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preparing_Statements_CRUD
{
    public class ExceptionText
    {
        public static void MetodoComExcecao(Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message,
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
