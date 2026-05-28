using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackEP26.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhotosController(IConfiguration config) : ControllerBase
{
    [HttpGet("{filename}")]
    [ResponseCache(Duration = 86400)]
    public async Task<IActionResult> Get(string filename)
    {
        var serviceUrl  = config["Storage:ServiceUrl"]!;
        var bucket      = config["Storage:BucketName"]!;
        var accessKey   = config["Storage:AccessKey"]!;
        var secretKey   = config["Storage:SecretKey"]!;

        var s3Config = new AmazonS3Config
        {
            ServiceURL           = serviceUrl,
            ForcePathStyle       = true,
            AuthenticationRegion = "us-east-1"
        };

        using var s3 = new AmazonS3Client(
            new BasicAWSCredentials(accessKey, secretKey), s3Config);

        try
        {
            var response = await s3.GetObjectAsync(new GetObjectRequest
            {
                BucketName = bucket,
                Key        = filename
            });

            var contentType = filename.EndsWith(".webp") ? "image/webp"
                            : filename.EndsWith(".avif") ? "image/avif"
                            : filename.EndsWith(".png")  ? "image/png"
                            : "image/jpeg";

            return File(response.ResponseStream, contentType);
        }
        catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return NotFound();
        }
    }
}
