using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ShooppyMegaMall.UI.Helpers
{
    public class AWS_Helper
    {
        private readonly IConfiguration _config;
        public AWS_Helper(IConfiguration config)
        {
            _config = config;
        }
        /* public async Task<string> uploadfile(IFormFile FileUpload1, string uploadFileName = "")
         {
             string returnfilename = "";
             try
             {
                 if (string.IsNullOrEmpty(uploadFileName))
                 {
                     uploadFileName = @"Common/files/" + FileUpload1.FileName;
                 }
                     if (FileUpload1 != null)
                     {
                          var bucketName = _config.GetSection("AWSAppSettings")["awsBucketName"];
                          var outputStream = FileUpload1.OpenReadStream();
                          IAmazonS3 client = new AmazonS3Client(_config.GetSection("AWSAppSettings")["awsAccessKey"], _config.GetSection("AWSAppSettings")["awsSecretKey"], RegionEndpoint.USEast2);
                         string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
                         PutObjectRequest request = new PutObjectRequest()
                         {
                             InputStream = outputStream,
                             BucketName = bucketName,
                             ContentType = GetContentType(ext),
                             CannedACL = S3CannedACL.PublicRead,
                             Key = uploadFileName// <-- in S3 key represents a path
                         };

                          PutObjectResponse response = await client.PutObjectAsync(request);

                         returnfilename = "https://ShooppyMegaMall.s3.us-east-2.amazonaws.com/" + uploadFileName;
                     }
                 return returnfilename;
             }
             catch(Exception ex)
             {
                 throw ex;
             }



         }

 */
        public async Task<string> uploadfile(IFormFile productModel, string uploadFileName = "")
        {
            try
            {
                if (string.IsNullOrEmpty(uploadFileName))
                {
                    uploadFileName = "Markets\\Common\\files\\";
                }
                string returnfilename = "";

                if (productModel != null)
                {
                    using (var outputStream = productModel.OpenReadStream())
                    {
                        MultipartFormDataContent multipartContent = new MultipartFormDataContent();
                        var imageContent = new StreamContent(outputStream);
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);
                        multipartContent.Add(imageContent, "CloudImage", productModel.FileName);
                        multipartContent.Add(new StringContent(uploadFileName, Encoding.UTF8, MediaTypeNames.Text.Plain), "CloudPath");
                        HttpClient _httpClient = new HttpClient();
                        using var response = await _httpClient.PostAsync("http://atmart.ShooppyMegaMall.in/FileServer/api/FileServer", multipartContent);
                        returnfilename = "http://atmart.ShooppyMegaMall.in/images/" + uploadFileName.Replace("\\", @"/") + productModel.FileName;
                    }
                }
                return returnfilename;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<string> uploadfilemulti(IFormFile postedfile, string uploadfilename = "")
        {
            try
            {
                if (string.IsNullOrEmpty(uploadfilename))
                {
                    uploadfilename = @"markets/common/files/" + postedfile.FileName;
                }
                string returnfilename = "";
                if (postedfile != null)
                {
                    string ext = Path.GetExtension(postedfile.FileName).ToLower();
                    var outputStream = postedfile.OpenReadStream();
                    var bucketName = _config.GetSection("AWSAppSettings")["awsBucketName"];
                    IAmazonS3 client = new AmazonS3Client(_config.GetSection("AWSAppSettings")["awsAccessKey"], _config.GetSection("AWSAppSettings")["awsSecretKey"], RegionEndpoint.APSouth1);


                    PutObjectRequest request = new PutObjectRequest()
                    {
                        InputStream = outputStream,
                        BucketName = bucketName,
                        ContentType = GetContentType(ext),
                        CannedACL = S3CannedACL.PublicRead,
                        Key = uploadfilename // <-- in s3 key represents a path
                    };

                    PutObjectResponse response = await client.PutObjectAsync(request);

                    returnfilename = "https://ShooppyMegaMall.s3.us-east-2.amazonaws.com/" + uploadfilename;
                }

                return returnfilename;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string GetContentType(string fileExtension)
        {
            string contentType = string.Empty;
            switch (fileExtension)
            {
                case ".bmp": contentType = "image/bmp"; break;
                case ".jpeg": contentType = "image/jpeg"; break;
                case ".jpg": contentType = "image/jpg"; break;
                case ".gif": contentType = "image/gif"; break;
                case ".tiff": contentType = "image/tiff"; break;
                case ".png": contentType = "image/png"; break;
                case ".plain": contentType = "text/plain"; break;
                case ".rtf": contentType = "text/rtf"; break;
                case ".msword": contentType = "application/msword"; break;
                case ".zip": contentType = "application/zip"; break;
                case ".mpeg": contentType = "audio/mpeg"; break;
                case ".pdf": contentType = "application/pdf"; break;
                case ".xgzip": contentType = "application/x-gzip"; break;
                case ".xcompressed": contentType = "application/x-compressed"; break;
            }
            return contentType;
        }

        private string path = "";

        public string checkfilesize(IFormFile FileUpload1, int imgheight, int imgwidth)
        {

            System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.OpenReadStream());
            int height = img.Height;
            int width = img.Width;
            decimal size = Math.Round(((decimal)FileUpload1.Length / (decimal)1024), 2);
            //if (size > 100)
            //{
            //    path = "File size must not exceed 100 KB.";

            //}
            if (height > imgheight || width > imgwidth)
            {
                path = "Height and Width must be matched selected option.";
            }
            else
            {
                path = "Success";
            }
            return path;
        }
    }
}

