using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
        using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
        using TinteX.DyeText.Platform.Profiles.Domain.Repositories;
        using TinteX.DyeText.Platform.Profiles.Domain.Services;
        using TinteX.DyeText.Platform.Shared.Domain.Repositories;
        
        namespace TinteX.DyeText.Platform.Profiles.Application.Internal.CommandServices;
        
        /// <summary>
        /// Servicio de comandos para perfiles
        /// </summary>
        /// <param name="profileRepository">
        /// Repositorio de perfiles
        /// </param>
        /// <param name="unitOfWork">
        /// Unidad de trabajo
        /// </param>
        public class ProfileCommandService(
            IProfileRepository profileRepository, 
            IUnitOfWork unitOfWork) 
            : IProfileCommandService
        {
            /// <inheritdoc />
            public async Task<Profile?> Handle(CreateProfileCommand command)
            {
                var profile = new Profile(command);
                try
                {
                    await profileRepository.AddAsync(profile);
                    await unitOfWork.CompleteAsync();
                    return profile;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        
            /// <inheritdoc />
            public async Task<Profile?> Handle(UpdateProfileCommand command)
            {
                var profile = await profileRepository.FindByIdAsync(command.Id);
                if (profile is null) return null;
        
                profile.Update(
                    command.FirstName,
                    command.LastName,
                    command.Email,
                    command.Phone,
                    command.MembershipActive,
                    command.Theme
                );
        
                try
                {
                    await unitOfWork.CompleteAsync();
                    return profile;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }