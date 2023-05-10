using Drugstore.Shared.
Entities;

namespace Drugstore.Shared.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; } = null!; 

        public DateTime Expiration { get; set; }
    }

}
