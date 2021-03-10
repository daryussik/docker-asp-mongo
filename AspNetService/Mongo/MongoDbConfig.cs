using Microsoft.Extensions.Configuration;

namespace AspNetService.Mongo
{
    public interface IMongoDbConfig
    {
        string Database { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string ConnectionString { get; }
    }

    public class MongoDbConfig : IMongoDbConfig
    {
        public MongoDbConfig(IConfiguration config)
        {
            if (config != null)
            {
                Database = config["MongoDB:Database"];
                Port = int.Parse(config["MongoDB:Port"]);
                Host = config["MongoDB:Host"];
                User = config["MongoDB:User"];
                Password = config["MongoDB:Password"];
            }
        }

        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                {
                    return $@"mongodb://{Host}:{Port}";
                }

                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}