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
                string ubicacion = @"Cadetes";
                string cadetesJson = JsonSerializer.Serialize(cadetes);
                using(FileStream miArchivo = new FileStream(ubicacion, FileMode.OpenOrCreate))
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
                string ubicacion = @"Cadetes";

                if(File.Exists(ubicacion))
                {
                    using(FileStream miArchivo = new FileStream(ubicacion, FileMode.Open))
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

        public Cadeteria Cadeteria { get => cadeteria; set => cadeteria = value; }
    }
}
