using System;
using _33kits.Contracts.Poco;

namespace _33Kits.DataRepository
{
    public class DuplicateFileException : Exception
    {
        public FileInfo FileInfo { get; }

        public DuplicateFileException(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
    }
}