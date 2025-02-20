using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using Cronos360.DAL;
using System.Transactions;

namespace Cronos360.BLL
{
    internal class CargaExcelBLL
    {
        private readonly HorasTrabajadasDAL _dal = new HorasTrabajadasDAL();

        public void ProcesarCarga(string filePath)
        {
            // Validar que el archivo existe y es accesible
            if (!File.Exists(filePath))
                throw new FileNotFoundException("El archivo no existe.");

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Validar si el archivo está siendo utilizado por otro proceso
                }
            }
            catch (IOException ex)
            {
                throw new IOException("El archivo está siendo utilizado por otro proceso.", ex);
            }

            // Leer el archivo Excel y procesar los datos
            var datos = LeerArchivoExcel(filePath);

            // Enviar los datos procesados a la DAL dentro de una transacción
            //using (var transaction = new TransactionScope())
            //{
            //    foreach (var registro in datos)
            //    {
            //        _dal.InsertarRegistro(registro);
            //    }

            //    transaction.Complete(); // Confirmar la transacción
            //}
        }

        private List<Registro> LeerArchivoExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var registros = new List<Registro>();

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    if (package.Workbook.Worksheets.Count == 0)
                        throw new Exception("El archivo Excel no contiene hojas.");

                    var worksheet = package.Workbook.Worksheets[0];
                    if (worksheet.Dimension == null)
                        throw new Exception("La hoja de cálculo está vacía.");

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        if (string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text) ||
                            string.IsNullOrWhiteSpace(worksheet.Cells[row, 2].Text) ||
                            string.IsNullOrWhiteSpace(worksheet.Cells[row, 3].Text))
                        {
                            continue; // Ignorar filas con datos faltantes
                        }

                        if (!int.TryParse(worksheet.Cells[row, 2].Text, out var horasTrabajadas))
                            throw new FormatException($"El valor de horas trabajadas en la fila {row} no es válido.");

                        if (!DateTime.TryParse(worksheet.Cells[row, 3].Text, out var fecha))
                            throw new FormatException($"El valor de fecha en la fila {row} no es válido.");

                        var registro = new Registro
                        {
                            EmpleadoId = worksheet.Cells[row, 1].Text,
                            HorasTrabajadas = horasTrabajadas,
                            Fecha = fecha,
                        };

                        registros.Add(registro);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer el archivo Excel: {ex.Message}", ex);
            }

            return registros;
        }


        //public void InsertarRegistro(Registro registro)
        //{
        //    // Delegar la inserción de registros a la capa DAL
        //    _dal.InsertarRegistro(registro);
        //}

        public static void GuardarHoras(string nombre, int horas)
        {
            if (horas < 0)
                throw new ArgumentException("Las horas trabajadas no pueden ser negativas.");

            EmpleadoDAL.InsertHoras(nombre, horas);
        }
    }
}
