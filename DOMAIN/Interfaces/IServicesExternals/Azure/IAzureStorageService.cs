﻿using DOMAIN.Helper.Enums.AppsExternals;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IServicesExternals.Azure
{
    public interface IAzureStorageService
    {/// <summary>
     /// This method uploads a file submitted with the request
     /// </summary>
     /// <param name="file">File for upload</param>
     /// <param name="container">Container where to submit the file</param>
     /// <param name="blobName">Blob name to update</param>
     /// <returns>File name saved in Blob contaienr</returns>
        Task<string> UploadAsync(IFormFile file, ContainerEnum container, string blobName = null);

        /// <summary>
        /// This method deleted a file with the specified filename
        /// </summary>
        /// <param name="container">Container where to delete the file</param>
        /// <param name="blobFilename">Filename</param>
        Task DeleteAsync(ContainerEnum container, string blobFilename);
    }
}
