using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace DemoApplication;

public static class AwsSecrets
{
    public static async Task<string> GetDatabaseConnectionString()
    {
        IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.USEast1);
        GetSecretValueRequest secretRequest = new GetSecretValueRequest
        {
            SecretId = "production_DemoApplication_ConnectionStrings__DefaultConnection"
        };
        GetSecretValueResponse secretResponse = await client.GetSecretValueAsync(secretRequest);
        return secretResponse.SecretString;
    }
}
