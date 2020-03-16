using Architecture.CrossCutting;
using Architecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedUsers();
        }

        private static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<UserEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Status = Status.Active,
                    AuthId = 1L
                });

                x.OwnsOne(y => y.FullName).HasData(new
                {
                    UserEntityId = 1L,
                    Name = "Administrator",
                    Surname = "Administrator"
                });

                x.OwnsOne(y => y.Email).HasData(new
                {
                    UserEntityId = 1L,
                    Address = "administrator@administrator.com"
                });
            });

            builder.Entity<AuthEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Login = "admin",
                    Password = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK8=",
                    Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9",
                    Roles = Roles.User | Roles.Admin
                });
            });
        }
    }
}
