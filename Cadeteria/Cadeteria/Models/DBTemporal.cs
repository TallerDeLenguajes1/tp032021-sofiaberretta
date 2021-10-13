using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class DBTemporal
    {
        private Cadeteria cadeteria;
        string ubicacionCadetes = @"Cadetes";
        public DBTemporal()
        {
            Cadeteria = new Cadeteria();
            if(getListCadetes() != null)
            {
                Cadeteria.ListaCadetes = getListCadetes();
            }
        }

        public void GuardarCadete(List<Cadete> cadetes)
        {
            try
            {
                string cadetesJson = JsonSerializer.Serialize(cadetes);
                using(FileStream miArchivo = new FileStream(ubicacionCadetes, FileMode.Create))
                {
                    using(StreamWriter strWrite = new StreamWriter(miArchivo))
                    {
                        strWrite.Write(cadetesJson);
                        strWrite.Close();
                        strWrite.Dispose();
                    }
                }

            } catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        public List<Cadete> getListCadetes()
        {
            List<Cadete> cadetesJson = null;
            try
            {
                if(File.Exists(ubicacionCadetes))
                {
                    using(FileStream miArchivo = new FileStream(ubicacionCadetes, FileMode.Open))
                    {
                        using(StreamReader strReader = new StreamReader(miArchivo))
                        {
                            string strCadetes = strReader.ReadToEnd();
                            cadetesJson = JsonSerializer.Deserialize<List<Cadete>>(strCadetes);
                        }
                    }
                }
            } catch(Exception ex)
            {
                string error = ex.Message;
            }
            return cadetesJson;
        }

        public void BorrarCadete(int id)
        {
            try
            {
                List<Cadete> listaDeCadetes = getListCadetes();

                Cadete cadeteAEliminar = listaDeCadetes.Where(cadete => cadete.Id == id).Single();
                listaDeCadetes.Remove(cadeteAEliminar);

                GuardarCadete(listaDeCadetes);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        public void ModificarCadete(Cadete cadete)
        {
            try
            {
                List<Cadete> listaCadetes = getListCadetes();

                Cadete cadeteSeleccionado = listaCadetes.Where(cad => cad.Id == cadete.Id).Single();

                if (cadeteSeleccionado != null)
                {

                    cadeteSeleccionado.Nombre = cadete.Nombre;
                    cadeteSeleccionado.Direccion = cadete.Direccion;
                    cadeteSeleccionado.Telefono = cadete.Telefono;

                    GuardarCadete(listaCadetes);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }
    }
}
