namespace RMMobileApp.Mediators;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDisplayModel>>
{
    private readonly IProductEndPoint _productEndPoint;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IProductEndPoint productEndPoint, IMapper mapper)
    {
        _productEndPoint = productEndPoint;
        _mapper = mapper;
    }
    public async Task<List<ProductDisplayModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var products = await _productEndPoint.GetAll();

        return _mapper.Map<List<ProductDisplayModel>>(products);
    }
}
