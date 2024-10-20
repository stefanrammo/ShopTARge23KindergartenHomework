using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using System.Xml;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IFileServices
    {
    void UploadFilesToDatabase(KindergartenDto dto, Kindergarten domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
    }
}
