
namespace WarehouseApp.Classes
{
    /// <summary>
    /// Сервис проверки контрагента.
    /// </summary>
    public interface IContractorCheckService
    {
        /// <summary>
        /// Проверяет контрагента по ИНН и типу юридического лица.
        /// </summary>
        Task<ContractorCheckResult> CheckAsync(string inn, string legalStatus);
    }
}
