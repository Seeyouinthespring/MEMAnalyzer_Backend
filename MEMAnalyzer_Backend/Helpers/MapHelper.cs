using AutoMapper;

namespace MEMAnalyzer_Backend.Helpers
{
    public static class MapHelper
    {
        public static TDestination MapTo<TDestination>(this object source) 
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
