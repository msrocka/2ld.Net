using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openLCA.Schema
{
    public class Ref : RootEntity
    {
        private readonly String type;
        public override string Type => type;

        public Ref(String type, String id, String name)
        {
            this.type = type;
            ID = id;
            Name = name;
        }

        public static Ref Of(RootEntity e)
        {
            if (e == null)
                return null;
            return new Ref(e.Type, e.ID, e.Name);
        }

    }
}
