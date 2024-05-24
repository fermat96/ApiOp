using Entity.DTO.Common;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.IO;
using System.Net;
using System.Linq;

namespace Data
{
    public class FPAVENT002MWData
    {
        #region METODOS GET
        //OBTENER CLIENTES POR NOMBRE
        public async Task<Result> ObtenerClientes(TokenData datosToken, string nombre)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 0,
                            nombre = nombre,
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Cliente>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER PEDIDO POR OP Y TIPO
        public async Task<Result> ObtenerPedidoOP(TokenData datosToken, string op, string tipo)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 2,
                            tipoPedido = tipo,
                            op = op
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Pedidos>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER PEDIDO POR FECHA
        public async Task<Result> ObtenerPedidoFecha(TokenData datosToken, Filtros fl)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 1,
                            fechaIn = fl.fechaInicio,
                            fechaFn = fl.fechaFin,
                            estadoG = fl.estadosP.generadas,
                            estadoA = fl.estadosP.completamenteAutorizadas,
                            estadoAP = fl.estadosP.parcialmenteAutorizadas,
                            estadoC = fl.estadosP.canceladas
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Pedidos>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER PEDIDO POR CLIENTE
        public async Task<Result> ObtenerPedidoCliente(TokenData datosToken, Filtros fl)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 3,
                            idCliente = fl.idCliente,
                            fechaIn = fl.fechaInicio,
                            fechaFn = fl.fechaFin,
                            estadoG = fl.estadosP.generadas,
                            estadoA = fl.estadosP.completamenteAutorizadas,
                            estadoAP = fl.estadosP.parcialmenteAutorizadas,
                            estadoC = fl.estadosP.canceladas
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Pedidos>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER CLIENTE POR ID
        public async Task<Result> ObtenerClientesID(TokenData datosToken, string idCliente)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 4,
                            idCliente = idCliente,
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Cliente>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //AUTORIZAR CC
        public async Task<Result> ValidarAutorizacionCC(TokenData datosToken, string usuario)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 5,
                            usuario = usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Autorizacion>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //AUTORIZAR GP
        public async Task<Result> ValidarAutorizacionGP(TokenData datosToken, string usuario)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 6,
                            usuario = usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Autorizacion>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //AUTORIZAR CO
        public async Task<Result> ValidarAutorizacionCO(TokenData datosToken, string usuario)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 7,
                            usuario = usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Autorizacion>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //ENCONTRAR OP
        public async Task<Result> BuscarValidarOP(TokenData datosToken, string op)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 8,
                            op = op
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<DatosOP>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //VALIDAR OP ENLACES
        public async Task<Result> ValidarOP(TokenData datosToken, string op)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 10,
                            op = op
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<VerificacionOP>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER VALIDAR CONTRASEÑA
        public async Task<Result> ObtenerValidarContraseña(TokenData datosToken, string usuario)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 9,
                            usuario = usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<Password>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER TERMINACION OP
        public async Task<Result> ObtenerTerminacionOP(TokenData datosToken)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 11
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<TerminacionOP>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER CORREO
        public async Task<Result> ObtenerCorreo(TokenData datosToken, string usuario)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 13,
                            usuario = usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<CORREO>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER NOMBRE CORREO
        public async Task<Result> ObtenerNombreCorreo(TokenData datosToken, string usuario)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 14,
                            usuario = usuario
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<NOMBRE_CORREO>();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //OBTENER DATOS DESCARGAR
        public async Task<Result> downloadFTP(TokenData datosToken, string url,string FileName)
        {
            Result objResult = new Result();
            try
            {
                List<string> Base64Files = new List<string>();
                FTPInfo FTPServer = new FTPInfo(); //CONTINUARLO PARA OBTENER DATOS DINAMICOS

                if (FTPServer.Servidor == "")
                {
                    objResult.Correcto = false;
                    objResult.Mensaje = "No se ha podido encontrar el servidor FTP";
                    return objResult;
                }

                string downloadsFolderPath = @"C:\Users\user\Desktop";
                downloadsFolderPath = downloadsFolderPath.Replace("\\", "/") + '/' + FileName;
                string fileExtention = Path.GetExtension(FileName);

                int consecutive = 0;
                while (File.Exists(downloadsFolderPath))
                {
                    consecutive++;
                    downloadsFolderPath = downloadsFolderPath.Replace(fileExtention, "").Replace("(" + (consecutive - 1).ToString() + ")", "") + "(" + consecutive + ")" + fileExtention;
                }

                DataFTP tempDataFTP = await this.obtenerCredencialesFTP(datosToken);

               

                //CREAR SOLICITUD PARA DESCARGA
                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://172.16.15.45/2023/DICIEMBRE/ARIAN/" + FileName);
                //request.Credentials = new NetworkCredential("userftp", "ciipdetec$123");

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tempDataFTP.Path+"/"+FileName);
                request.Credentials = new NetworkCredential(tempDataFTP.Usuario.Trim(), tempDataFTP.Password.Trim());

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fileStream = new FileStream(downloadsFolderPath, FileMode.Create))
                    {
                        byte[] buffer = new byte[16 * 1024];
                        int bytesRead;
                        while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                byte[] fileData = File.ReadAllBytes(downloadsFolderPath);
                string base64Data = Convert.ToBase64String(fileData);
                Base64Files.Add(base64Data);
                response.Close();

                objResult.data = Base64Files;
                objResult.Agent = FileName;
                objResult.Correcto = true;
                objResult.Mensaje = "Archivo <strong>" + FileName + "</strong> descargado y guardado en <br><strong style='color:darkblue'>" + downloadsFolderPath + "</strong>";
                objResult.Route = downloadsFolderPath;
                return objResult;
            }
            catch(WebException ex)
            {
                objResult.Correcto = false;
                objResult.Mensaje = "El archivo <strong>" + FileName + "</strong> No se ha podido Descargar";
                return objResult;
            }
        }

        public async Task<DataFTP> obtenerCredencialesFTP(TokenData datosToken)
        {
            DataFTP objResult = new DataFTP();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPC1",
                        new
                        {
                            accion = 15,
                            Zona = "1"
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult = (await result.ReadAsync<DataFTP>()).FirstOrDefault();
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        #endregion

        #region METODOS UPDATE
        public async Task<Result> UpdateAutorizar(TokenData datosToken, string clave, string notasAuth, string op, string tipoMateria, string tipoAuth, string autorizacion)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPA2",
                        new
                        {
                            accion = tipoAuth,
                            notasAuth = notasAuth,
                            tipoMaterial = tipoMateria,
                            op = op,
                            usuarioERP = datosToken.Usuario,
                            autorizar = autorizacion
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> UpdateBloquear(TokenData datosToken, string op, string tipoMaterial, bool cancelaRemision)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPA2",
                        new
                        {
                            accion = 3,
                            tipoMaterial = tipoMaterial,
                            op = op,
                            usuarioERP = datosToken.Usuario,
                            cancelaRemision = cancelaRemision
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<bool>();

                    objResult.Correcto = true;
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> UpdateNotificacion(TokenData datosToken, string op)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPA2",
                        new
                        {
                            accion = 6,
                            op = op,
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.data = await result.ReadAsync<bool>();

                    objResult.Correcto = true;
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> UpdateClaveEnvio(TokenData datosToken, string destino, string mensaje, string remitente, string nombreRemitente, string subject, string claveEnvio)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion))
                {
                    var result = await con.QueryMultipleAsync(
                        "FPAVENT002MWSPA2",
                        new
                        {
                            accion = 5,
                            Destino = destino,
                            Mensaje = mensaje,
                            Remitente = remitente,
                            NombreRemitente = nombreRemitente,
                            Subject = subject,
                            ClaveEnvio = claveEnvio
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> EnviarCorreo(TokenData datosToken, string claveEnvio)
        {
            Result objResult = new Result();
            try
            {
                using (var con = new SqlConnection(datosToken.Conexion2))
                {
                    var result = await con.QueryMultipleAsync(
                        "MnuSP001",
                        new
                        {
                            ClaveEnvio = claveEnvio,
                            MensajeAdicional = ""
                        },
                    commandType: CommandType.StoredProcedure);
                    objResult.Correcto = true;
                }
                return objResult;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion
    }
}
