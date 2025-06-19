using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.Analytics.Domain.Services
{
    public interface IMachinesFailureCountQueryService
    {
        /// <summary>Lista todos los conteos de fallos</summary>
            Task<IEnumerable<MachineFailureCount>> ListAsync();
            /// <summary>Trae el conteo de fallos de una máquina en concreto</summary>
            Task<MachineFailureCount?> FindByMachineIdAsync(Guid machineId);
    }
}