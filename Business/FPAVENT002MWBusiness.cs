using Data;
using Entity;
using Entity.DTO.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FPAVENT002MWBusiness
    {
        #region METODOS GET
        public async Task<Result> ObtenerClientes(TokenData datosToken, string nombre)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerClientes(datosToken, nombre);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerPedidoOP(TokenData datosToken, string op, string tipo)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerPedidoOP(datosToken, op, tipo);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerPedidoFecha(TokenData datosToken, Filtros fl)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerPedidoFecha(datosToken, fl);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerPedidoCliente(TokenData datosToken, Filtros fl)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerPedidoCliente(datosToken, fl);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerClientesID(TokenData datosToken, string idCliente)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerClientesID(datosToken, idCliente);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ValidarAutorizacionCC(TokenData datosToken, string usuario)
        {
            try
            {
                return await new FPAVENT002MWData().ValidarAutorizacionCC(datosToken, usuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ValidarAutorizacionGP(TokenData datosToken, string usuario)
        {
            try
            {
                return await new FPAVENT002MWData().ValidarAutorizacionGP(datosToken, usuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ValidarAutorizacionCO(TokenData datosToken, string usuario)
        {
            try
            {
                return await new FPAVENT002MWData().ValidarAutorizacionCO(datosToken, usuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> BuscarValidarOP(TokenData datosToken, string op)
        {
            try
            {
                return await new FPAVENT002MWData().BuscarValidarOP(datosToken, op);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerValidarContraseña(TokenData datosToken, string usuario)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerValidarContraseña(datosToken, usuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerCorreo(TokenData datosToken, string usuario)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerCorreo(datosToken, usuario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ValidarOP(TokenData datosToken, string op)
        {
            try
            {
                return await new FPAVENT002MWData().ValidarOP(datosToken, op);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerTerminacionOP(TokenData datosToken)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerTerminacionOP(datosToken);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> ObtenerNombreCorreo(TokenData datosToken, string usuario)
        {
            try
            {
                return await new FPAVENT002MWData().ObtenerNombreCorreo(datosToken, usuario);
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
            try
            {
                return await new FPAVENT002MWData().UpdateAutorizar(datosToken, clave, notasAuth, op, tipoMateria, tipoAuth, autorizacion);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> UpdateBloquear(TokenData datosToken, string op, string tipoMaterial, bool cancelaRemision)
        {
            try
            {
                return await new FPAVENT002MWData().UpdateBloquear(datosToken, op, tipoMaterial, cancelaRemision);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> UpdateClaveEnvio(TokenData datosToken, string destino, string mensaje, string remitente, string nombreRemitente, string subject, string claveEnvio)
        {
            try
            {
                return await new FPAVENT002MWData().UpdateClaveEnvio(datosToken, destino, mensaje, remitente, nombreRemitente, subject, claveEnvio);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> UpdateNotificacion(TokenData datosToken, string op)
        {
            try
            {
                return await new FPAVENT002MWData().UpdateNotificacion(datosToken, op);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        
        //DESCARGAR PDF
        public byte[] Descargar(TokenData datosToken, string nombreArchivo)
        {
            FPAVENT002MWData fpaDATA = new FPAVENT002MWData();
            FTPInfo ftpinfo = new FTPInfo(); // fpaDATA.GetFTPInfo(datosToken);

            ftpinfo.Password = "ciipdetec$123";
            ftpinfo.Usuario = "userftp";

            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://172.16.15.45/" + "2023/DICIEMBRE/ARIAN/" + "PRUEBA.pdf"));
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(ftpinfo.Usuario.Trim(), ftpinfo.Password.Trim());
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            long cl = response.ContentLength;
            int readCount;
            byte[] buffer;

            buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {

                while ((readCount = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, readCount);
                }

                buffer = ms.ToArray();
            }

            ftpStream.Close();

            response.Close();
            return buffer;
        }
        public async Task<Result> downloadFTP(TokenData datosToken,string url, string FileName)
        {
            try
            {
                return await new FPAVENT002MWData().downloadFTP(datosToken, url, FileName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Result> EnviarCorreo(TokenData datosToken, string claveEnvio)
        {
            try
            {
                return await new FPAVENT002MWData().EnviarCorreo(datosToken, claveEnvio);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion

    }
}
