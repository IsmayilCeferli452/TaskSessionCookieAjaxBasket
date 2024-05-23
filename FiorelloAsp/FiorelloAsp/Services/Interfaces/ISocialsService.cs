using FiorelloAsp.Models;

namespace FiorelloAsp.Services.Interfaces
{
    public interface ISocialsService
    {
        Task<List<FooterSocials>> GetAllAsync();
    }
}
