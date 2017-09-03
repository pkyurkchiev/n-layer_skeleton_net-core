namespace NTS.ApplicationServices.Implementations.Shared
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories.Interfaces;
    using System;

    public abstract class BaseService
    {
        #region Fields
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        public BaseService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        #endregion
    }
}
