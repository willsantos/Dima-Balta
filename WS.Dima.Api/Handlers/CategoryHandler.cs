using Microsoft.EntityFrameworkCore;
using WS.Dima.Api.Data;
using WS.Dima.Core.Handlers;
using WS.Dima.Core.Models;
using WS.Dima.Core.Requests.Categories;
using WS.Dima.Core.Responses;

namespace WS.Dima.Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var Category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };


                await context.Categories.AddAsync(Category);
                await context.SaveChangesAsync();

                return new Response<Category?>(Category, 201, "Categoria Criada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);//TODO: serilog
                return new Response<Category?>(null, 500, "Falha ao criar a Categoria");
            }
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category == null)
                    return new Response<Category?>(null, 404, "Categoria não encontrada");

                category.Description = request.Description;
                category.Title = request.Title;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Categoria Atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);//TODO:serilog
                return new Response<Category?>(null, 500, "Falha ao Atualizar a Categoria");
            }

        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category == null)
                    return new Response<Category?>(null, 404, "Categoria não encontrada");

                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return new Response<Category?>(category, 204, "Categoria removida com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);//TODO:serilog
                return new Response<Category?>(null, 500, "Falha ao remover a Categoria");
            }

        }

        public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {
                var query = context
                .Categories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId);

                var count = await query.CountAsync();

                var categories = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

                return new PagedResponse<List<Category>>(categories, count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);//TODO:serilog
                return new PagedResponse<List<Category>>(null, 500, "Falha ao localizar as Categorias");
            }
        }

        public async Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
        {
            try
            {
                var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return category is null
                    ? new Response<Category?>(null, 404, "Categoria não encontrada")
                    : new Response<Category?>(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);//TODO:serilog
                return new Response<Category?>(null, 500, "Falha ao localizar a Categoria");
            }

        }
    }
}