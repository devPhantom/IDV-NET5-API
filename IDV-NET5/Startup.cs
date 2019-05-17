﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDVNET5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IDV_NET5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProductContext>(opt =>
            opt.UseInMemoryDatabase("ProductList"));
            services.AddDbContext<CategoryContext>(opt =>
            opt.UseInMemoryDatabase("CategoryList"));
            services.AddDbContext<OrderContext>(opt =>
            opt.UseInMemoryDatabase("OrdertList"));
            services.AddDbContext<ProductOrderContext>(opt =>
            opt.UseInMemoryDatabase("ProductOrderList"));
            services.AddDbContext<UserContext>(opt =>
            opt.UseInMemoryDatabase("UserList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
