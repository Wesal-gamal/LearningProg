using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Attendleave.Erp.Core.APIUtilities
{
    public interface ISaveAllImage
    {

        string SaveImage(string imgStr,string folderName, string imgName);
        bool IsBase64Encoded(String str);



    }
}
