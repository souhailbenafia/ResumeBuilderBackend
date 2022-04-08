using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        ICertificationRepository certificationRepository { get; }
        IEducationRepository educationRepository { get; }
        IExperianceRepository experianceRepository { get; }
        IInterestRepository interestRepository { get; }
        ILanguageRepository languageRepository { get; }
        IProjectRepository projectRepository { get; }
        ISkillRepository skillRepository { get; }
        ISocialNetworkRepository socialNetworkRepository { get; }
        IUserRepository userRepository { get; }
        IInfoRepository infoRepository { get; }
        Task Save();

        // <summary>
        /// Saves changes to all objects that have changed within the unit of work.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
