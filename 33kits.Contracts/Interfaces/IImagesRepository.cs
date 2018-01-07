using System;
using System.Collections.Generic;
using _33kits.Contracts.Poco;

namespace _33kits.Contracts.Interfaces
{
    public interface IImagesRepository
    {
        IEnumerable<BinaryDataModel> GetResizeTo70Images(params string[] extensions);
        IEnumerable<FileInfo> GetImagesInfo(params string[] extensions);
        IEnumerable<FileInfo> GetImagesInfo(Guid[] ids);
        BinaryDataModel GetResizeImage(Guid id, int height, int width);
    }
}