
using System.Drawing;
using System.Windows.Forms;

namespace SparkClean
{
    public static class FormStyle
    {
        public static void Apply(Form form)
        {
            form.BackColor = Color.White;
            form.ForeColor = Color.Black;
            form.Font = new Font("Arial", 10);

            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.ForeColor = Color.Black;

                if (control is Button button)
                {
                    button.BackColor = Color.LightGray;
                    button.ForeColor = Color.Black;
                    button.FlatStyle = FlatStyle.Standard;
                    button.Font = new Font("Arial", 10);
                }
                else if (control is Label label)
                {
                    label.BackColor = Color.White;
                    label.ForeColor = Color.Black;
                    label.Font = new Font("Arial", 10);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.Black;
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = Color.White;
                    grid.ForeColor = Color.Black;
                    grid.DefaultCellStyle.BackColor = Color.White;
                    grid.DefaultCellStyle.ForeColor = Color.Black;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    grid.EnableHeadersVisualStyles = false;
                }

                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }
    }
}
