
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;
using Portfolio.Business.Helpers.DTOs.FileUpload;
using Portfolio.Business.Services.Interfaces;
using Portfolio.Core.Settings;

namespace Portfolio.Business.Services.Implementations
{
    public class AWSImageService : IAWSImageService
    {
        private readonly AmazonS3Client _client;
        private readonly AmazonSettings _amazon;

        public AWSImageService(IOptions<AmazonSettings> amazon)
        {
            _amazon = amazon.Value;

            var s3Config = new AmazonS3Config
            {
                ServiceURL = _amazon.EndPointUrl,
                ForcePathStyle = true
            };

            _client = new AmazonS3Client(
                _amazon.AccessKeyId,
               _amazon.SecretAccessKey,
                s3Config);
        }


        public async Task<ImageUrlDrto> UploadFileAsync(CreateImageUploadDto fileUploadDto)
        {
            var fileName = $"{fileUploadDto.FolderName}/{Guid.NewGuid()}_{fileUploadDto.File.FileName}";

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = fileUploadDto.File.OpenReadStream(),
                Key = fileName,
                BucketName = _amazon.BucketName
            };

            var transferUtility = new TransferUtility(_client);
            await transferUtility.UploadAsync(uploadRequest);

            var imageUrl = $"{_amazon.EndPointUrl}/{_amazon.BucketName}/{fileName}";

            return new ImageUrlDrto
            {
                ImgUrl = imageUrl
            };
        }
    }
}
