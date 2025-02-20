using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Cronos360.CP
{
    public partial class frmCargaExcel : Form
    {
        public frmCargaExcel()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Configura la barra de progreso
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            // Simula una operación larga
            for (int i = 0; i <= 100; i++)
            {
                // Actualiza el valor de la barra de progreso
                progressBar1.Value = i;
                // Simula un retraso
                System.Threading.Thread.Sleep(50);
            }
            string filePath = txtRutaArchivo.Text;

            // Validación de la ruta del archivo
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Por favor, selecciona un archivo válido antes de cargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de la extensión del archivo
            if (Path.GetExtension(filePath).ToLower() != ".xlsx")
            {
                MessageBox.Show("El archivo seleccionado no es un archivo Excel válido (.xlsx).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Obtiene la primera hoja
                    var dataTable = new DataTable();

                    // Verifica si la hoja tiene datos
                    if (worksheet.Row(1).CellsUsed().Count() == 0)
                    {
                        MessageBox.Show("El archivo Excel no contiene datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cargar columnas (encabezados)
                    foreach (var header in worksheet.Row(1).CellsUsed())
                    {
                        dataTable.Columns.Add(header.Value.ToString().Trim());
                    }

                    // Cargar filas de datos
                    int rowCount = worksheet.RowsUsed().Count();
                    for (int rowIndex = 2; rowIndex <= rowCount; rowIndex++) // Desde la segunda fila en adelante
                    {
                        var row = worksheet.Row(rowIndex);
                        var dataRow = dataTable.NewRow();

                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            var cellValue = row.Cell(i + 1).Value;

                            // **Verificar tipo de dato**
                            Console.WriteLine($"Valor original: {cellValue}, Tipo: {cellValue.GetType()}");

                            if (row.Cell(i + 1).DataType == XLDataType.Number)
                            {
                                try
                                {
                                    double numericValue = Convert.ToDouble(cellValue);

                                    // **Verificar si el valor numérico corresponde a una fecha válida**
                                    if (numericValue > 10000) // Los valores OADate válidos están generalmente por encima de 10000
                                    {
                                        DateTime periodoFecha = DateTime.FromOADate(numericValue);
                                        string periodoFormato = periodoFecha.ToString("MMMM-yyyy", new System.Globalization.CultureInfo("es-ES"));
                                        dataRow[i] = periodoFormato;
                                    }
                                    else
                                    {
                                        dataRow[i] = numericValue.ToString(); // No parece una fecha, dejarlo como texto
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al convertir la fecha: {ex.Message}");
                                    dataRow[i] = cellValue; // Usar el valor original en caso de error
                                }
                            }
                            else
                            {
                                dataRow[i] = cellValue.ToString().Trim();
                            }
                        }

                        dataTable.Rows.Add(dataRow);

                    }

                    // Asigna los datos al DataGridView
                    dataGridView1.DataSource = dataTable;
                }

                MessageBox.Show("Datos cargados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para procesar el archivo Excel
        private void ProcesarArchivoExcel(string rutaArchivo)
        {
            try
            {
                // Aquí va la lógica para leer y procesar el archivo Excel
                MessageBox.Show($"Archivo {rutaArchivo} procesado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo: {ex.Message}");
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string filePath = txtRutaArchivo.Text;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Por favor, selecciona un archivo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileExtension = Path.GetExtension(filePath).ToLower();
            if (fileExtension != ".xlsx" && fileExtension != ".xls")
            {
                MessageBox.Show("El archivo debe ser de tipo Excel (.xlsx o .xls).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("El archivo es válido.", "Validación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Primero debes cargar los datos desde un archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            try
            {
                string[] columnasRequeridas = { "user_identif", "usuario", "trabajado", "requerido_practia",
                                        "diferencia_hs", "diferencia_dias", "status", "dias_habiles", "horas_habiles" };
                // Validar que todas las columnas requeridas existan en el DataTable
                foreach (string columna in columnasRequeridas)
                {
                    if (!dataTable.Columns.Contains(columna))
                    {
                        MessageBox.Show($"La columna '{columna}' no existe en los datos cargados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Validar si hay valores nulos o vacíos en las columnas requeridas
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (string columna in columnasRequeridas)
                    {
                        if (row[columna] == DBNull.Value || string.IsNullOrWhiteSpace(row[columna].ToString()))
                        {
                            MessageBox.Show($"Error: La columna '{columna}' tiene un valor nulo o vacío en la fila {dataTable.Rows.IndexOf(row) + 1}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                // Normalizar los nombres de columnas eliminando espacios
                foreach (DataColumn column in dataTable.Columns)
                {
                    column.ColumnName = column.ColumnName.Trim();
                }

                string connectionString = "Data Source=TONYA\\SQLEXPRESS;Initial Catalog=SISDE;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    List<string> errores = new List<string>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        try
                        {
                            decimal ParsearDecimal(string valor, string columna, int fila)
                            {
                                if (decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultado))
                                    return resultado;
                                else
                                    throw new FormatException($"Valor inválido en la columna '{columna}' en la fila {fila}.");
                            }
                            // Validar columnas numéricas
                            decimal trabajado = ParsearDecimal(row["trabajado"]?.ToString() ?? "0", "trabajado", dataTable.Rows.IndexOf(row) + 1);
                            int licencias = int.TryParse(row["licencias"]?.ToString(), out int licenciasValido) ? licenciasValido : 0;
                            int requeridoPractica = int.TryParse(row["requerido_practia"]?.ToString(), out int requeridoValido) ? requeridoValido : 0;
                            decimal diferenciaHoras = ParsearDecimal(row["diferencia_hs"]?.ToString() ?? "0", "diferencia_hs", dataTable.Rows.IndexOf(row) + 1);
                            decimal diferenciaDias = ParsearDecimal(row["diferencia_dias"]?.ToString() ?? "0", "diferencia_dias", dataTable.Rows.IndexOf(row) + 1);
                            int diasHabiles = int.TryParse(row["dias_habiles"]?.ToString(), out int diasHabilesValido) ? diasHabilesValido : 0;
                            int horasHabiles = int.TryParse(row["horas_habiles"]?.ToString(), out int horasHabilesValido) ? horasHabilesValido : 0;

                            Console.WriteLine($"Fila {dataTable.Rows.IndexOf(row) + 1} - Periodo: {row["periodo"]}");

                            // Construir la consulta SQL
                            string query = "INSERT INTO control_horas " +
                                           "(user_identif,usuario, trabajado, licencias, observaciones, requerido_practia, " +
                                           "diferencia_hs, diferencia_dias, status, dias_habiles, horas_habiles, periodo) " +
                                           "VALUES " +
                                           "(@user_identif, @usuario, @trabajado, @licencias, @observaciones, @requerido_practia, " +
                                           "@diferencia_hs, @diferencia_dias, @status, @dias_habiles, @horas_habiles, @periodo)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Asignar parámetros
                                command.Parameters.AddWithValue("@user_identif", row["user_identif"]?.ToString() ?? "");
                                command.Parameters.AddWithValue("@usuario", row["usuario"]?.ToString() ?? "");
                                command.Parameters.AddWithValue("@trabajado", trabajado);
                                command.Parameters.AddWithValue("@licencias", licencias);
                                command.Parameters.AddWithValue("@observaciones", row["observaciones"]?.ToString() ?? "");
                                command.Parameters.AddWithValue("@requerido_practia", requeridoPractica);
                                command.Parameters.AddWithValue("@diferencia_hs", diferenciaHoras);
                                command.Parameters.AddWithValue("@diferencia_dias", diferenciaDias);
                                command.Parameters.AddWithValue("@status", row["status"]?.ToString() ?? "");
                                command.Parameters.AddWithValue("@dias_habiles", diasHabiles);
                                command.Parameters.AddWithValue("@horas_habiles", horasHabiles);

                                Console.WriteLine($"Valor crudo de 'periodo': {row["periodo"]?.ToString()}");
                                // Obtener el valor del periodo
                                string periodoStr = row["periodo"]?.ToString()?.Trim().TrimStart('\''); // Eliminar el apostrofe
                                Console.WriteLine($"Fila {dataTable.Rows.IndexOf(row) + 1} - Periodo: {row["periodo"]}");

                                // Asignar un valor predeterminado si el periodo está vacío o nulo
                                if (string.IsNullOrEmpty(periodoStr))
                                {
                                    periodoStr = "ene-25";
                                }

                                // Convertir manualmente el periodo a una fecha
                                DateTime fechaValida;
                                if (TryConvertPeriodoToDate(periodoStr, out fechaValida))
                                {
                                    // Debug: Verificar si se está asignando bien la fecha
                                    Console.WriteLine($"Valor original: '{periodoStr}', Convertido: '{fechaValida:yyyy-MM-dd}'");

                                    // Asignar el valor al parámetro
                                    command.Parameters.Add("@periodo", SqlDbType.Date).Value = fechaValida;
                                }
                                else
                                {
                                    Console.WriteLine($"⚠️ No se pudo convertir el periodo: '{periodoStr}', se insertará NULL");
                                    command.Parameters.Add("@periodo", SqlDbType.Date).Value = DBNull.Value;
                                }

                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            errores.Add($"Error en la fila {dataTable.Rows.IndexOf(row) + 1}: {ex.Message}");
                        }
                    }

                    if (errores.Any())
                    {
                        MessageBox.Show($"Algunos registros no pudieron ser importados:\n{string.Join("\n", errores)}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Todos los datos fueron importados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TryConvertPeriodoToDate(string periodoStr, out DateTime fechaValida)
        {
            // Diccionario de meses en español
            Dictionary<string, int> meses = new Dictionary<string, int>
    {
        { "ene", 1 }, { "feb", 2 }, { "mar", 3 }, { "abr", 4 },
        { "may", 5 }, { "jun", 6 }, { "jul", 7 }, { "ago", 8 },
        { "sep", 9 }, { "oct", 10 }, { "nov", 11 }, { "dic", 12 }
    };

            fechaValida = DateTime.MinValue;
            if (string.IsNullOrEmpty(periodoStr))
            {
                return false;
            }

            // Eliminar el apostrofe si existe
            periodoStr = periodoStr.TrimStart('\'');

            // Separar el mes y el año
            string[] partes = periodoStr.Split('-');
            if (partes.Length == 2 && meses.ContainsKey(partes[0].ToLower()))
            {
                int mes = meses[partes[0].ToLower()];
                if (int.TryParse(partes[1], out int año))
                {
                    // Asignar la fecha válida
                    fechaValida = new DateTime(año < 100 ? 2000 + año : año, mes, 1);
                    return true;
                }
            }

            return false;
        }
        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos Excel|*.xlsx;*.xls";
                openFileDialog.Title = "Seleccionar archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaArchivo.Text = openFileDialog.FileName; // Establece la ruta seleccionada
                }
            }
        }

        private void frmCargaExcel_Load(object sender, EventArgs e)
        {
            this.Text = ""; // Oculta el nombre
            this.ControlBox = true; // Oculta los botones de minimizar, maximizar y cerrar
            //this.FormBorderStyle = FormBorderStyle.None; // Elimina la barra de título
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Confirmar si el usuario realmente quiere salir
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cerrar la aplicación
                Application.Exit();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
