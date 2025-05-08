namespace NTS.ApplicationServices.Packagess
{
    using AutoMapper;
    using System.Collections.Generic;
    using X.PagedList;

    public class PagedListConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>> where TSource : class where TDestination : class
    {

        public IPagedList<TDestination> Convert(IPagedList<TSource> source, IPagedList<TDestination> destination, ResolutionContext context)
        {
            var _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationServicesAMConfiguration());
            });
            IEnumerable<TDestination> sourceList = _mapperConfiguration.CreateMapper().Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
            IPagedList<TDestination> pagedResult = sourceList == null ? null : new StaticPagedList<TDestination>(sourceList, source?.GetMetaData());

            return pagedResult;
        }
    }
}
