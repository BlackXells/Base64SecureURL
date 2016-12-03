/*  BlackXells
 *  Herramienta de conversión a Base64 seguro para URL.
 *  Programador: Miguel Rivas Méndez.
 */

using System;
using System.Text;

namespace BlackXells.Tools
{
    /// <summary>
    /// Conversor de Base64 seguro para utilización en URLs.
    /// </summary>
    public static class Base64SecureURL
    {
        /// <summary>
        /// Codifica una cadena de texto a Base64 seguro para uso en URLs.
        /// </summary>
        /// <param name="text">Cadena de texto a codificar.</param>
        /// <returns>Cadena de texto codificada.</returns>
        public static string Encode(string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            var base64 = Convert.ToBase64String(plainTextBytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
            return base64;
        }

        /// <summary>
        /// Decodifica una cadena de texto de Base64 seguro para URLs.
        /// </summary>
        /// <param name="secureUrlBase64">Cadena de texto Base64 seguro para URLs.</param>
        /// <returns>Cadena de texto decodificada.</returns>
        public static string Decode(string secureUrlBase64)
        {
            secureUrlBase64 = secureUrlBase64.Replace('-', '+').Replace('_', '/');
            switch (secureUrlBase64.Length % 4) {
                case 2:
                    secureUrlBase64 += "==";
                    break;
                case 3:
                    secureUrlBase64 += "=";
                    break;
            }
            var bytes = Convert.FromBase64String(secureUrlBase64);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
