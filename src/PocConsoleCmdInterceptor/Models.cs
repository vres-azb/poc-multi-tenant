namespace PocConsoleCmdInterceptor
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}