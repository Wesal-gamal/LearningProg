using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Attendleave.Erp.Core.APIUtilities
{
    public interface ISaveFiles //: ISaveAllImage
    {
        string SaveFile(string imgStr, string folderName, string FileName,string oldFileName);
    }
}
