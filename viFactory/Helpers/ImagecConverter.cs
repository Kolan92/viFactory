using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace viFactory.Helpers
{
    public static class ImagecConverter
    {
        public static string ImageFromByteArray(this HtmlHelper helper, byte[] imageArrayBytes)
        {
            
            const int chunkSize = 384;
            var base64StrinBuilder = new StringBuilder();

            using (var stream = new MemoryStream(imageArrayBytes))
            {
                while (stream.Position < stream.Length)
                {
                    var chunkBytes = new byte[chunkSize];

                    var remaining = stream.Length - stream.Position;
                    if (remaining >= chunkSize)
                    {
                        stream.Read(chunkBytes, 0, chunkSize);
                    }
                    else
                    {
                        stream.Read(chunkBytes, 0, (int)remaining);
                    }


                    base64StrinBuilder.Append(Convert.ToBase64String(chunkBytes));
                }
            }
            var temp = base64StrinBuilder.ToString();
            return base64StrinBuilder.ToString();
        }
    }
}