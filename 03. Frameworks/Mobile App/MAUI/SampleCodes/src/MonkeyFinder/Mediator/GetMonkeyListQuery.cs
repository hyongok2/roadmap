using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Mediator
{
    public record GetMonkeyListQuery : IRequest<List<Monkey>> { }

}
