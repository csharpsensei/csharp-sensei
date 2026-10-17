public static void Map(WebApplication app)
{
    app.MapGet("/levels/{id:int}",
        (int id) => Results.Ok(new StockLevel(id, 4)));
}
