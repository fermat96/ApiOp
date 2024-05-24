using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Entity;
using Entity.DTO;
using Entity.DTO.Common;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    public class ProduccionSinEntradaData
    {
        public async Task<Result> Get_ListarMaquinas(string strConexion)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(strConexion.Replace("FCA", "")))
                {
                    var result = await con.QueryMultipleAsync("PapSP116",
                        new
                        {
                            Accion = 1,
                            
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Maquinas>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Get_ListarProduccionSinEntrada(string strConexion, int startRow, int endRow, ProduccionSinEntradaFiltro Filtro)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    int R = Convert.ToInt32(Filtro.Rollo);
                    int B = Convert.ToInt32(Filtro.Bobina);
                    var result = await con.QueryMultipleAsync(new SPNombre().Nombre,
                        new
                        {
                            Accion = 1,
                            Filtro.idMaquina,
                            Filtro.Mes,
                            Filtro.Anio,
                            Filtro.Papel,
                            Rollo = R,
                            Bobina = B,
                            startRow,
                            endRow
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<ProduccionSinEntrada>();
                    objResult.totalRecords = await result.ReadFirstAsync<int>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> Get_ListarProduccion(string strConexion, int startRow, int endRow, ProduccionSinEntradaFiltro Filtro)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var result = await con.QueryMultipleAsync(new SPNombre().Nombre,
                        new
                        {
                            Accion = 2,
                            Filtro.idMaquina,
                            Filtro.Mes,
                            Filtro.Anio,
                            startRow,
                            endRow
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<ProduccionSinEntrada>();
                    objResult.totalRecords = await result.ReadFirstAsync<int>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Result> post_Actualizar(TokenData datosToken, int Mes, int Anio, int idMaquina, ProduccionSinEntrada[] Tabla)
        {
            Result objResult = new Result();
            try
            {
                var dsDatos = SerializedDataSet(Tabla);

                if(dsDatos.Tables.Count == 0)
                {
                    Tabla = new ProduccionSinEntrada[1];
                    Tabla[0] = new ProduccionSinEntrada();
                    Tabla[0].FechaProd = "";
                    Tabla[0].FechaProdSinEntrada = "";
                    dsDatos = SerializedDataSet(Tabla);
                    dsDatos.Tables[0].Rows.RemoveAt(0);
                }
                while (dsDatos.Tables[0].Columns.Count > 7)
                    dsDatos.Tables[0].Columns.RemoveAt(7);

                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    SPNombre nombre = new SPNombre(Enums.SpTipo.Actualiza);
                    await con.QueryFirstOrDefaultAsync(
                        nombre.Nombre,
                        new
                        {
                            Accion = 1,
                            Mes,
                            Anio,
                            idMaquina,
                            UsuarioERP = datosToken.Usuario,
                            TablaProduccion = dsDatos.Tables[0].AsTableValuedParameter("FPAPROGDAT001TD_001")
                        },
                        commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                    return objResult;
                }
            }
            catch (Exception ex)
            {
                objResult.Correcto = false;
                objResult.Mensaje = ex.Message;
                return objResult;
            }
        }

        #region SerializedDataSet
        DataSet SerializedDataSet(object[] obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            System.IO.StringWriter sw = new System.IO.StringWriter();
            serializer.Serialize(sw, obj);
            DataSet ds = new DataSet();
            System.IO.StringReader reader = new System.IO.StringReader(sw.ToString());
            ds.ReadXml(reader);
            return ds;
        }
        #endregion

    }
}
