namespace Mapper
{
    public class MapHelper
    {
        public TDestination DynamicMap<TSource, TDestination>(TSource sourceObj) where TDestination : class
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(sourceObj);
        }

        public List<TDestination> DynamicMapList<TSource, TDestination>(IEnumerable<TSource> sourceObj)
        {
            var listDes = new List<TDestination>();
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            var mapper = config.CreateMapper();

            sourceObj.ToList().ForEach(x => listDes.Add(mapper.Map<TDestination>(x)));

            return listDes;
        }
    }

}