using MediatR;
using MonkeyFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Mediator
{
    public class GetMonkeyListQueryHandler : IRequestHandler<GetMonkeyListQuery, List<Monkey>>
    {
        IMonkeyService _monkeyService;

        public GetMonkeyListQueryHandler(IMonkeyService monkeyService)
        {
            _monkeyService = monkeyService;
        }

        public Task<List<Monkey>> Handle(GetMonkeyListQuery request, CancellationToken cancellationToken)
        {
            return _monkeyService.GetMonkeys();
        }
    }
}
