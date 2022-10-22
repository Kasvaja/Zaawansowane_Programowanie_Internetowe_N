using WebStore.DAL.DatabaseContext;
using WebStore.Services.Interfaces;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class OrderServiceUnitTests : BaseUnitTests
{
    private readonly IOrderService _orderService;
    public OrderServiceUnitTests(WSDbContext dbContext,
        IOrderService orderService) : base(dbContext)
    {
        _orderService = orderService;
    }

    [Fact]
    public void GetAllOrdersTest()
    {
        var orders = _orderService.GetOrders();
        Assert.NotNull(orders);
        Assert.NotEmpty(orders);
        Assert.Equal(orders.Count(), orders.Count());
    }

    [Fact]
    public void GetOrderById()
    {
        int id = 2;
        var order = _orderService.GetOrderById(id);
        Assert.NotNull(order);
        Assert.Equal(order.Result.Id, id);
    }
}
