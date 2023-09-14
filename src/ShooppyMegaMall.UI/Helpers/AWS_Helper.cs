namespace ShooppyMegaMall.UI.Helpers
{
    using Amazon;
    using Amazon.S3;
    using Amazon.S3.Model;
    using ImageProcessor;
    using ImageProcessor.Imaging;
    using ImageProcessor.Plugins.WebP.Imaging.Formats;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Buffers.Text;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Drawing;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    /// <summary>
    /// Defines the <see cref="AWS_Helper" />.
    /// </summary>
    public class AWS_Helper
    {
        /// <summary>
        /// Defines the _config.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Defines the hostingEnvironment.
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AWS_Helper"/> class.
        /// </summary>
        /// <param name="config">The config<see cref="IConfiguration"/>.</param>
        /// <param name="environment">The environment<see cref="IHostingEnvironment"/>.</param>
        public AWS_Helper(IConfiguration config, IHostingEnvironment environment)
        {
            _config = config;
            hostingEnvironment = environment;
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
        /// <summary>
        /// The uploadfile.
        /// </summary>
        /// <param name="productModel">The productModel<see cref="IFormFile"/>.</param>
        /// <param name="uploadFileName">The uploadFileName<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{string}"/>.</returns>
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
                        var ServerImageName =
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);
                        var fileName = "File_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(productModel.FileName);
                        multipartContent.Add(imageContent, "CloudImage", fileName);
                        multipartContent.Add(new StringContent(uploadFileName, Encoding.UTF8, MediaTypeNames.Text.Plain), "CloudPath");
                        HttpClientHandler clientHandler = new HttpClientHandler();
                        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                        // Pass the handler to httpclient(from you are calling api)
                        HttpClient _httpClient = new HttpClient(clientHandler);
                        using var response = await _httpClient.PostAsync("https://markets.shooppy.in/FileServer/api/FileServer", multipartContent);
                        returnfilename = "https://markets.shooppy.in/images/" + uploadFileName.Replace("\\", @"/") + fileName;
                    }
                }
                return returnfilename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The imageProccessor.
        /// </summary>
        /// <param name="ImageFile">The ImageFile<see cref="IFormFile"/>.</param>
        /// <returns>The <see cref="Task{IFormFile}"/>.</returns>
        public async Task<IFormFile> imageProccessor(IFormFile ImageFile)
        {
            try
            {
                string imagesPath = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                string webPFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + ".webp";
                string WebpImagePath = Path.Combine(imagesPath, webPFileName);

                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }
                var ms = new MemoryStream();

                using (var webpImageStream = new FileStream(WebpImagePath, FileMode.Create))
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(ImageFile.OpenReadStream())
                           .Format(new WebPFormat())
                           .Quality(90)
                           .Brightness(5)
                           .GaussianSharpen(5)
                           .Saturation(5)
                       .Save(webpImageStream);
                    }

                    webpImageStream.CopyTo(ms);

                }
                System.IO.File.Delete(WebpImagePath);
                return new FormFile(ms, 0, ms.Length, "name", webPFileName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// The uploadfilemulti.
        /// </summary>
        /// <param name="postedfile">The postedfile<see cref="IFormFile"/>.</param>
        /// <param name="uploadfilename">The uploadfilename<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{string}"/>.</returns>
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

        /// <summary>
        /// The GetContentType.
        /// </summary>
        /// <param name="fileExtension">The fileExtension<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
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

        /// <summary>
        /// Defines the path.
        /// </summary>
        private string path = "";

        /// <summary>
        /// The checkfilesize.
        /// </summary>
        /// <param name="FileUpload1">The FileUpload1<see cref="IFormFile"/>.</param>
        /// <param name="imgheight">The imgheight<see cref="int"/>.</param>
        /// <param name="imgwidth">The imgwidth<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
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
