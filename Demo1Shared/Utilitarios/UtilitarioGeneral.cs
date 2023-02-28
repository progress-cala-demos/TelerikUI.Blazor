
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Demo1Shared.Utilitarios
{
    public class UtilitarioGeneral
    {
        public UtilitarioGeneral() { }

        public static TD MapearObjetos<TO, TD>(TO oo, IConfigurationProvider conf = null)
            where TO : class, new()
            where TD : class, new()
        {
            var mapper = new Mapper(conf != null ? conf : new MapperConfiguration(cfg => cfg.CreateMap<TO, TD>()));
            TD od = mapper.Map<TO, TD>(oo);

            return od;
        }

        public static List<TD> MapearObjetos<TO, TD>(List<TO> oo, IConfigurationProvider conf = null)
            where TO : class, new()
            where TD : class, new()
        {
            var mapper = new Mapper(conf != null ? conf : new MapperConfiguration(cfg => cfg.CreateMap<TO, TD>()));
            List<TD> od = mapper.Map<List<TO>, List<TD>>(oo);

            return od;
        }
    }
}
