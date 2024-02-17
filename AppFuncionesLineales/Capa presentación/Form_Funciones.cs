using AppFuncionesLineales.Capa__acceso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AppFuncionesLineales
{
    public partial class Form_Funciones : Form
    {

        private FuncionesManager funcionesManager = new FuncionesManager();
        private DataAccess dataAccess = new DataAccess();
        public Form_Funciones()
        {
            InitializeComponent();
            SetupChart();
            dataGridView1.DataSource = dataAccess.ObtenerDatos();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Asumiendo que las columnas A, B, y C existen y contienen los valores deseados
                double a = Convert.ToDouble(selectedRow.Cells["A"].Value);
                double b = Convert.ToDouble(selectedRow.Cells["B"].Value);
                double c = Convert.ToDouble(selectedRow.Cells["C"].Value);

                // Llama al método para refrescar el gráfico con los valores seleccionados
                refrescarseleccion(a, b, c);
            }
        }


        private void SetupChart()
        {
            // Añade una serie para la función lineal
            Series series = chart1.Series.Add("Linear Function");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Blue; // Color de la línea

            // Personaliza los ejes
            ChartArea ca = chart1.ChartAreas[0];
            ca.AxisX.Crossing = 0; // El eje X cruza en el origen
            ca.AxisY.Crossing = 0; // El eje Y cruza en el origen

            ca.AxisX.Interval = 1; // Intervalos de la cuadrícula
            ca.AxisY.Interval = 1;

            // Personaliza la apariencia de la cuadrícula
            ca.AxisX.MajorGrid.LineColor = Color.LightGray;
            ca.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Establece los límites del gráfico
            ca.AxisX.Minimum = -10;
            ca.AxisX.Maximum = 10;
            ca.AxisY.Minimum = -10;
            ca.AxisY.Maximum = 10;

            chart1.Legends[0].Position.Auto = false;
            chart1.Legends[0].Position = new ElementPosition(0, 90, 100, 10);
        }



        private void AddAnnotatedPoint(double x, double y, bool annotate = false)
        {
            // Asegúrate de cambiar el tipo de serie a Point o Bubble si solo quieres mostrar puntos individuales
            Series series = chart1.Series["Linear Function"];
            series.ChartType = SeriesChartType.Point; // Cambia a Point

            // Añade un punto individual con etiqueta
            DataPoint point = new DataPoint(x, y)
            {
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 10,
                LabelAngle = -45,
                MarkerColor = Color.DarkBlue,
                LabelBorderWidth = 1,
                LabelBorderColor = Color.Black,
                Label = annotate ? $"({x}, {y})" : ""

                // Añade una etiqueta al punto
            };
            series.Points.Add(point);
        }


        private void refrescarseleccion(double a, double b, double c)
        {
            chart1.Series["Linear Function"].Points.Clear(); // Limpiar puntos anteriores


            List<(double, double)> puntos = new List<(double, double)>();
            double maxX = double.MinValue, maxY = double.MinValue, minX = double.MaxValue, minY = double.MaxValue;

            // Grafica la función lineal con valores enteros de x
            for (int x = -10; x <= 10; x++)
            {
                double y = funcionesManager.CalcularY(x, a, b, c);
                puntos.Add((x, y));
                maxX = Math.Max(maxX, x);
                minX = Math.Min(minX, x);
                maxY = Math.Max(maxY, y);
                minY = Math.Min(minY, y);
            }

            // Ajusta los límites del gráfico basándose en los puntos extremos
            chart1.ChartAreas[0].AxisX.Minimum = minX - 1; // Ajuste para garantizar visibilidad
            chart1.ChartAreas[0].AxisX.Maximum = maxX + 1;
            chart1.ChartAreas[0].AxisY.Minimum = minY - 1;
            chart1.ChartAreas[0].AxisY.Maximum = maxY + 1;

            // Añade etiquetas solo al primer y último punto
            if (puntos.Any())
            {
                var primerPunto = puntos.First();
                var ultimoPunto = puntos.Last();

                // Añade de nuevo todos los puntos, esta vez sin marcar ninguno con etiqueta
                foreach (var punto in puntos)
                {
                    bool etiquetar = punto.Equals(primerPunto) || punto.Equals(ultimoPunto);
                    AddAnnotatedPoint(punto.Item1, punto.Item2, etiquetar);
                }
            }


        }

        

        private void btnGraficarGuardar_Click(object sender, EventArgs e)
        {
            chart1.Series["Linear Function"].Points.Clear(); // Limpiar puntos anteriores
            double A, B, C;

            if (!double.TryParse(txtA.Text, out A) || !double.TryParse(txtB.Text, out B) || !double.TryParse(txtC.Text, out C))
            {
                MessageBox.Show("Los valores de A, B y C deben ser números válidos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<(double, double)> puntos = new List<(double, double)>();
            double maxX = double.MinValue, maxY = double.MinValue, minX = double.MaxValue, minY = double.MaxValue;

            // Grafica la función lineal con valores enteros de x
            for (int x = -10; x <= 10; x++)
            {
                double y = funcionesManager.CalcularY(x, A, B, C);
                puntos.Add((x, y));
                maxX = Math.Max(maxX, x);
                minX = Math.Min(minX, x);
                maxY = Math.Max(maxY, y);
                minY = Math.Min(minY, y);
            }

            // Ajusta los límites del gráfico basándose en los puntos extremos
            chart1.ChartAreas[0].AxisX.Minimum = minX - 1; // Ajuste para garantizar visibilidad
            chart1.ChartAreas[0].AxisX.Maximum = maxX + 1;
            chart1.ChartAreas[0].AxisY.Minimum = minY - 1;
            chart1.ChartAreas[0].AxisY.Maximum = maxY + 1;

            // Añade etiquetas solo al primer y último punto
            if (puntos.Any())
            {
                var primerPunto = puntos.First();
                var ultimoPunto = puntos.Last();

                // Añade de nuevo todos los puntos, esta vez sin marcar ninguno con etiqueta
                foreach (var punto in puntos)
                {
                    bool etiquetar = punto.Equals(primerPunto) || punto.Equals(ultimoPunto);
                    AddAnnotatedPoint(punto.Item1, punto.Item2, etiquetar);
                }
            }

            // Guarda los datos en la base de datos
            dataAccess.GuardarFuncion(A, B, C, puntos);

            // Actualiza el DataGridView con los nuevos datos
            dataGridView1.DataSource = dataAccess.ObtenerDatos();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void Form_Funciones_Load(object sender, EventArgs e)
        {
            txtA.Select();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el valor del ID de la primera celda de la fila seleccionada
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                // Llamar a la función para eliminar el registro
                dataAccess.EliminarFuncion(id);

                // Eliminar la fila seleccionada del DataGridView
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }
    }
}
