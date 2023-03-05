using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Interfaces
{
    public interface IEngineer:ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs{ get; }
    }
}
